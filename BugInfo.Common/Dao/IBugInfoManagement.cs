using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BugInfoManagement.Entity;
using System.Collections;
using System.IO;

namespace BugInfoManagement.Dao
{
    public interface IBugInfoManagement
    {
        List<BugInfoEntity> QueryAll();

        List<BugInfoEntity> QueryByDealMan(string dealMan);

        List<BugInfoEntity> Query(string dealMan, string state);

        List<BugInfoEntity> QueryByStates(string state);

        List<BugInfoEntity> QueryByParameter(QueryParameter parameter);

        BugInfoEntity QueryByBugNum(String bugNum);

        void DeleteByBugNum(String bugNum);

        void AddBugInfo(BugInfoEntity bugInfo);

        bool UpdateBugInfoByBugNum(BugInfoEntity bugInfo);

        void UpdateBugDetail(string bugNum, byte[] detailsBuffer);

        void GetBugDetail(string bugNum, MemoryStream memo);

        IEnumerable<string> SearchBugNumByDateRange(DateTime start, DateTime end);

        void AddLog(string bugNum, string Log);

        void AssignPoints(string bugNum, string log);

        bool TryToUpdate(string bugNum, DateTime timeStamp, out DateTime newtimeStamp);
    }
}
