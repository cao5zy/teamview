using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Common.Dao;
using FxLib.Algorithms;

namespace TeamView.Common.DaoImpl
{
    class BugInfoQuery : IQuery
    {
        public IEnumerable<Entity.BugInfoEntity1> QueryByParameters(IEnumerable<string> programmers, string bugNum, string version, string description, int? priority, string bugState)
        {
            SubSonic.Query query = DAL.BugInfo.CreateQuery();
            query.QueryType = SubSonic.QueryType.Select;

            if (programmers.SafeCount() != 0)
                query = query.WHERE(
                    DAL.BugInfo.Columns.DealMan, SubSonic.Comparison.In, programmers
                    );

            if (!string.IsNullOrEmpty(bugNum))
                query = query.WHERE(DAL.BugInfo.Columns.BugNum, SubSonic.Comparison.Like, bugNum + "%");

            if (!string.IsNullOrEmpty(version))
                query = query.WHERE(
                    DAL.BugInfo.Columns.Version, version);

            if (!string.IsNullOrEmpty(description))
                query = query.WHERE(
                    DAL.BugInfo.Columns.Description,
                     SubSonic.Comparison.Like,
                     "%" +
                     description + "%");
            if (priority != null)
            {
                query = query.WHERE(
                    DAL.BugInfo.Columns.Priority,
                    SubSonic.Comparison.LessOrEquals,
                    priority.Value);
            }

            if (!string.IsNullOrEmpty(bugState))
            {
                query = query.WHERE(DAL.BugInfo.Columns.BugStatus, bugState);
            }

            using (var reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return new Entity.BugInfoEntity1
                        {
                            bugNum = reader[DAL.BugInfo.Columns.BugNum].ToString(),
                            bugStatus = reader[DAL.BugInfo.Columns.BugStatus].ToString(),
                            dealMan = reader[DAL.BugInfo.Columns.DealMan].ToString(),
                            description = reader[DAL.BugInfo.Columns.Description].ToString(),
                            priority = Convert.ToInt16(reader[DAL.BugInfo.Columns.Priority]),
                            size = reader[DAL.BugInfo.Columns.Size].ToInt32(),
                            timeStamp = Convert.ToDateTime(reader[DAL.BugInfo.Columns.TimeStamp]),
                            version = reader[DAL.BugInfo.Columns.Version].ToString(),
                            lastStateTime = Convert.IsDBNull(reader[DAL.BugInfo.Columns.LatestStartTime]) ? DateTime.MinValue : Convert.ToDateTime(reader[DAL.BugInfo.Columns.LatestStartTime]),
                            fired = reader[DAL.BugInfo.Columns.Fired].ToInt32(),
                        };
                }
            }
        }


        public IEnumerable<Logs.CompleteTaskLogEntity> QueryCompleteTasks(string dealMan, DateTime startDate, DateTime endDate, int completeTaskFlag)
        {
         
            using (var reader = new SubSonic.Select(DAL.ChangeLog.BugNumColumn,
                DAL.ChangeLog.CreateDateColumn,
                DAL.BugInfo.DescriptionColumn,
                DAL.BugInfo.SizeColumn,
                DAL.BugInfo.FiredColumn,
                DAL.BugInfo.DealManColumn).From<DAL.ChangeLog>()
                .InnerJoin<DAL.BugInfo>()
                .Where(DAL.BugInfo.DealManColumn).IsEqualTo(dealMan)
                .And(DAL.ChangeLog.CreateDateColumn).IsGreaterThanOrEqualTo(startDate)
                .And(DAL.ChangeLog.CreateDateColumn).IsLessThanOrEqualTo(endDate)
                .And(DAL.ChangeLog.LogTypeIDColumn).IsEqualTo((int)LogTypeEnum.Submit)
                .ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return new Logs.CompleteTaskLogEntity { 
                        Burned = reader[DAL.BugInfo.Columns.Fired].ToInt32(),
                        CompleteTime = reader[DAL.ChangeLog.Columns.CreateDate].ToDateTime(),
                        Dealman = reader[DAL.BugInfo.Columns.DealMan].ToString(),
                        Description = reader[DAL.BugInfo.Columns.Description].ToString(),
                        Estimate = reader[DAL.BugInfo.Columns.Size].ToInt32(),
                        ItemId = reader[DAL.BugInfo.Columns.BugNum].ToString(),
                    };
                }
            }

        }
    }
}
