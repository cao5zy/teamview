using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugInfoManagement.Entity;
using System.Windows.Forms;
using BugInfoManagement.Dao;
using BugInfoManagement.DaoImpl;
using System.IO;
using OpenCourse.CommonLibrary.Algorithms;
using BugInfoManagement.Common;
using System.Transactions;
using System.IO.Compression;

namespace BugInfoManagement
{
    public abstract class BugInfoManager
    {
        protected IBugInfoManagement BugInfoManagement { get; private set; }
        public BugInfoManager(IBugInfoManagement bugInfoManagement)
        {
            BugInfoManagement = bugInfoManagement;
        }
        protected BugInfoEntity mBugInfo;
        public BugInfoEntity BugInfo
        {
            get
            {
                return mBugInfo;
            }
        }

        protected BugInfoEntity mOriginalBugInfo;

        protected bool Validate(IBugInfoManagement bugInfoManagement)
        {
            if (string.IsNullOrEmpty(mBugInfo.Version))
            {
                ShowMessage("版本号不能为空!");
                return false;
            }

            if (string.IsNullOrEmpty(mBugInfo.BugNum))
            {
                ShowMessage("Bug编号不能为空!");
                return false;
            }

            if (string.IsNullOrEmpty(mBugInfo.CreatedBy))
            {
                ShowMessage("创建人不能为空!");
                return false;
            }

            if (mOriginalBugInfo != null)
            {
                if (mOriginalBugInfo.DealMan == mBugInfo.DealMan)
                {
                    StateSequence stateSequence = new StateSequence(mOriginalBugInfo.BugStatus);
                    if (!stateSequence.IsNextStateValid(mBugInfo.BugStatus))
                    {
                        ShowMessage("状态变化不允许");
                        return false;
                    }
                }
                else
                {
                    if (mOriginalBugInfo.BugStatus != mBugInfo.BugStatus)
                    {
                        ShowMessage("状态变化不允许");
                        return false;
                    }
                }

                if (mOriginalBugInfo.BugStatus == mBugInfo.BugStatus)
                {
                    if (mOriginalBugInfo.DealMan != mBugInfo.DealMan)
                    {
                        if (!(mOriginalBugInfo.BugStatus == States.Pending
                            || mOriginalBugInfo.BugStatus == States.Complete))
                        {
                            ShowMessage("状态变化不允许");
                            return false;
                        }
                    }
                }
                else
                {
                    if (mOriginalBugInfo.DealMan != mBugInfo.DealMan)
                    {
                        ShowMessage("状态变化不允许");
                        return false;
                    }
                }
            }
            else
            {
                if (mBugInfo.BugStatus != States.Pending)
                {
                    ShowMessage("状态变化不允许");
                    return false;
                }
            }

            if (mBugInfo.BugStatus == States.Start)
            {
                var currents = bugInfoManagement.QueryByParameter(
                    new QueryParameter
                    {
                        Programmer = mBugInfo.DealMan,
                        Status = States.Start,
                    }
                    );
                if (currents.SafeFindAll(n => n.BugNum != mBugInfo.BugNum).SafeCount() != 0)
                {
                    ShowMessage("只允许一项任务处于 正在处理状态");
                    return false;
                }
            }

            return ValidateCore(bugInfoManagement);
        }

        protected abstract bool ValidateCore(IBugInfoManagement bugInfoManagement);

        public bool Save()
        {
            using (var trans = new TransactionScope())
            {
                DateTime currentTimeStamp = DateTime.MinValue;
                DateTime newTimeStamp;

                bool transState = false;
                try
                {
                    if (mOriginalBugInfo != null)
                    {
                        currentTimeStamp = mOriginalBugInfo.TimeStamp;
                        if (BugInfoManagement.TryToUpdate(mOriginalBugInfo.BugNum, mOriginalBugInfo.TimeStamp, out newTimeStamp))
                        {
                            mOriginalBugInfo.TimeStamp = newTimeStamp;
                        }
                        else
                        {
                            ShowMessage("数据已过期");
                            return false;
                        }
                    }

                    AutoChangeStatus(BugInfoManagement);

                    if (!Validate(BugInfoManagement))
                        return false;



                    //save evaluate points
                    if (!string.IsNullOrEmpty(mBugInfo.EstimatedValue) && mBugInfo.EstimatedValue.Length != 0)
                    {
                        BugInfoManagement.AssignPoints(mBugInfo.BugNum, mBugInfo.EstimatedValue);
                    }

                    if (mOriginalBugInfo != null)
                    {
                        SetChangeLog(BugInfoManagement);
                        if (SaveCore(BugInfoManagement))
                        {
                            transState = true;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (SaveCore(BugInfoManagement))
                        {
                            BugInfoManagement.AddLog(mBugInfo.BugNum,
                            string.Format(@"Version:{0};size:{1};S:{2};D:{3}", new object[]{mBugInfo.Version, 
                                    mBugInfo.Size,
                                    mBugInfo.BugStatus,
                                    mBugInfo.DealMan}));

                            transState = true;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (mOriginalBugInfo != null)
                        mOriginalBugInfo.TimeStamp = currentTimeStamp;
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (transState)
                        trans.Complete();
                    else
                        mOriginalBugInfo.TimeStamp = currentTimeStamp;

                }
            }
            return false;
        }

        private void AutoChangeStatus(IBugInfoManagement bugInfoManagement)
        {
            if (mOriginalBugInfo != null)
            {
                if (mOriginalBugInfo.DealMan != mBugInfo.DealMan)
                {
                    if (mOriginalBugInfo.BugStatus == States.Complete)
                    {
                        if (mBugInfo.DealMan != "仓库")
                        {
                            AddStatusChange(bugInfoManagement, mBugInfo.BugNum, States.Complete, States.Pending);
                            mBugInfo.BugStatus = States.Pending;
                            mOriginalBugInfo.BugStatus = States.Pending;
                            bugInfoManagement.UpdateBugInfoByBugNum(mOriginalBugInfo);
                        }
                    }
                }
            }
        }

        protected abstract bool SaveCore(IBugInfoManagement bugInfoManagement);

        protected void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }


        protected void SetChangeLog(IBugInfoManagement bugInfoManagement)
        {
            string log = string.Empty;

            string format = string.Empty;
            if (mBugInfo.Version != mOriginalBugInfo.Version)
            {
                log += string.Format("Version:{0}->{1}", mOriginalBugInfo.Version, mBugInfo.Version);
            }
            if (mBugInfo.DealMan != mOriginalBugInfo.DealMan)
            {
                if (log.Length > 0)
                {
                    log += ";";
                }
                log += string.Format("Deal:{0}->{1}", mOriginalBugInfo.DealMan, mBugInfo.DealMan);
            }
            if (mBugInfo.BugStatus != mOriginalBugInfo.BugStatus)
            {
                if (log.Length > 0)
                {
                    log += ";";
                }
                log += string.Format("Status:{0}->{1}", mOriginalBugInfo.BugStatus, mBugInfo.BugStatus);
            }
            if (mBugInfo.Size != mOriginalBugInfo.Size)
            {
                if (log.Length > 0)
                    log += ";";
                log += string.Format("Size:{0}->{1}", mOriginalBugInfo.Size, mBugInfo.Size);
            }
            if (!string.IsNullOrEmpty(mBugInfo.Comment))
            {
                if (log.Length > 0)
                    log += ";";
                log += mBugInfo.Comment;
            }

            if (!string.IsNullOrEmpty(log))
                bugInfoManagement.AddLog(mBugInfo.BugNum, log);
        }

        protected void AddStatusChange(IBugInfoManagement bugInfoManagement,
            string bugNum,
            string status1,
            string status2)
        {
            bugInfoManagement.AddLog(bugNum,
                string.Format("Status:{0}->{1}", status1, status2));
        }

        public void LoadDetail(SimpleEditor editor)
        {
            using (var stream = GetDetailStream())
            {
                if (stream != null && stream.Length != 0)
                {
                    stream.Position = 0;
                    editor.LoadFile(stream, RichTextBoxStreamType.RichText);
                    stream.Close();
                    stream.Dispose();
                    editor.Reset();
                }
            }
        }

        public void SaveDetail(SimpleEditor editor)
        {
            if (!editor.IsUpdated)
                return;

            string tempFileName = Path.GetTempFileName();
            using (FileStream fs = new FileStream(tempFileName, FileMode.Create))
            {
                editor.SaveFile(fs, RichTextBoxStreamType.RichText);
                fs.Flush();
                editor.Reset();
            }

            using (FileStream fs = new FileStream(tempFileName, FileMode.Open))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);

                MemoryStream zipTargetStream = new MemoryStream();

                using (GZipStream zipStream = new GZipStream(zipTargetStream, CompressionMode.Compress, true))
                {
                    zipStream.Write(buffer, 0, (int)fs.Length);
                }

                BugInfoManagement.UpdateBugDetail(mBugInfo.BugNum, zipTargetStream.ToArray());
                Array.Resize(ref buffer, 0);
            }
            editor.Reset();
        }

        protected abstract System.IO.Stream GetDetailStream();

    }
}
