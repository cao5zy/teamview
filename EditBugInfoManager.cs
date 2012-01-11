using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Dao;
using TeamView.DaoImpl;
using System.IO;
using TeamView.Common;
using FxLib.Algorithms;
using System.Data.SqlClient;
using System.Transactions;
using TeamView.Entity;
using System.IO.Compression;
using TeamView.Common;

namespace TeamView
{
    public class EditBugInfoManager : BugInfoManager
    {
        public delegate EditBugInfoManager Factiory();
        public EditBugInfoManager(IBugInfoManagement bugInfoManagement) : base(bugInfoManagement) { }
        protected override bool ValidateCore(IBugInfoManagement bugInfoManagement)
        {
            return true;
        }

        public bool Initialize(string bugNum)
        {
            mBugInfo = BugInfoManagement.QueryByBugNum(bugNum);
            mOriginalBugInfo = BugInfoManagement.QueryByBugNum(bugNum);
            return true;
        }

        protected override bool SaveCore(IBugInfoManagement bugInfoManagement)
        {
            return bugInfoManagement.UpdateBugInfoByBugNum(mBugInfo);
        }

        protected override System.IO.Stream GetDetailStream()
        {
            MemoryStream stream = new MemoryStream();

            BugInfoManagement.GetBugDetail(mBugInfo.BugNum, stream);

            Stream unZipStream;
            if (TryToUnZipStream(stream, out unZipStream))
            {
                stream.Close();
                return unZipStream;
            }
            return stream;
        }

        private bool TryToUnZipStream(MemoryStream stream, out Stream unZipStream)
        {
            unZipStream = null;
            stream.Position = 0;


            using (GZipStream zipStream = new GZipStream(stream, CompressionMode.Decompress, true))
            {

                int readLen = 0;
                int bufferLen = 4096;
                byte[] buffer = new byte[bufferLen];

                try
                {
                    readLen = zipStream.Read(buffer, 0, bufferLen);
                }
                catch (Exception)
                {
                    return false;
                }

                unZipStream = new MemoryStream();

                while (readLen != 0)
                {
                    unZipStream.Write(buffer, 0, readLen);

                    readLen = zipStream.Read(buffer, 0, bufferLen);
                }

                unZipStream.Flush();
                return true;
            }

        }

        public void MoveState(StatesEnum bugStatus)
        {

            using (var trans = new TransactionScope())
            {
                var currentBugInfo = BugInfoManagement.QueryByBugNum(mOriginalBugInfo.BugNum);
                var stateSequence = new StateSequence(currentBugInfo.BugStatus);
                if (!stateSequence.IsNextStateValid(StatesConverter.ToStateString(bugStatus)))
                {
                    ShowMessage("状态已经发生了变化");
                    return;
                }

                DateTime newTimeStamp;
                if (BugInfoManagement.TryToUpdate(mOriginalBugInfo.BugNum, mOriginalBugInfo.TimeStamp, out newTimeStamp))
                {
                    mOriginalBugInfo.TimeStamp = newTimeStamp;
                }
                else
                {
                    ShowMessage("无效数据");
                    return;
                }

                string bugNum = mBugInfo.BugNum;



                if (bugStatus == StatesEnum.Start)
                {
                    BugInfoManagement.AddLog(mBugInfo.BugNum,
                        mOriginalBugInfo.DealMan,
                        (int)LogTypeEnum.MissionStart);

                    var otherProcessingItem = BugInfoManagement.QueryByProgrammerStatus(
                        mOriginalBugInfo.DealMan
                     , States.Start).SafeFind(n => n.BugNum != mBugInfo.BugNum);

                    if (otherProcessingItem != null)
                    {
                        DateTime newTimeStamp1;
                        if (!BugInfoManagement.TryToUpdate(otherProcessingItem.BugNum,
                            otherProcessingItem.TimeStamp,
                            out newTimeStamp1))
                            return;

                        BugInfoManagement.AddLog(otherProcessingItem.BugNum,
                            otherProcessingItem.DealMan,
                            (int)LogTypeEnum.MissionStop);
                        AddStatusChange(BugInfoManagement, otherProcessingItem.BugNum, States.Start, States.Abort);
                        otherProcessingItem.BugStatus = States.Abort;
                        BugInfoManagement.UpdateBugInfoByBugNum(otherProcessingItem);
                    }
                }
                else
                {
                    BugInfoManagement.AddLog(mBugInfo.BugNum,
                        mOriginalBugInfo.DealMan,
                        (int)LogTypeEnum.MissionStop);

                }

                AddStatusChange(BugInfoManagement, mBugInfo.BugNum, mBugInfo.BugStatus, StatesConverter.ToStateString(bugStatus));
                mBugInfo.BugStatus = StatesConverter.ToStateString(bugStatus);
                mBugInfo.DealMan = mOriginalBugInfo.DealMan;//keep the original programmer unchanged.
                mOriginalBugInfo.BugStatus = mBugInfo.BugStatus;
                BugInfoManagement.UpdateBugInfoByBugNum(mBugInfo);
                mBugInfo.TimeStamp = BugInfoManagement.QueryByBugNum(bugNum).TimeStamp;

                trans.Complete();
            }

        }

    }
}
