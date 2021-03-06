﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Common.Dao;
using Dev3Lib.Algorithms;
using SubSonic;
using TeamView.Common.Entity;
using DAL;
using TeamView.Common.Logs;

namespace TeamView.Common.DaoImpl
{
    class BugInfoQuery : IQuery
    {
        public IEnumerable<Entity.BugInfoEntity1> QueryByParameters(
            IEnumerable<string> programmers,
            string bugNum,
            string version,
            string description,
            IEnumerable<int> selectedPriorities,
            IEnumerable<string> selectedStates
            )
        {
            SubSonic.SqlQuery query = DAL.DB.Select().From<DAL.BugInfo>();

            if (programmers.SafeCount() != 0)
            {
                if (!query.HasWhere)
                    query.Where(DAL.BugInfo.Columns.DealMan).In(programmers);
                else
                    query.And(DAL.BugInfo.Columns.DealMan).In(programmers);
            }

            if (!string.IsNullOrEmpty(bugNum))
            {
                if (!query.HasWhere)
                    query.Where(DAL.BugInfo.Columns.BugNum).Like(bugNum + "%");
                else
                    query.And(DAL.BugInfo.Columns.BugNum).Like(bugNum + "%");
            }


            if (!string.IsNullOrEmpty(version))
            {
                if (!query.HasWhere)
                    query.Where(DAL.BugInfo.Columns.Version).Like(version + "%");
                else
                    query.And(DAL.BugInfo.Columns.Version).Like(version + "%");
            }

            if (!string.IsNullOrEmpty(description))
            {
                if (!query.HasWhere)
                    query.Where(DAL.BugInfo.Columns.Description).Like("%" + description + "%");
                else
                    query.And(DAL.BugInfo.Columns.Description).Like("%" + description + "%");
            }

            if (!selectedPriorities.IsNullOrEmpty())
            {
                if (!query.HasWhere)
                    query.Where(DAL.BugInfo.Columns.Priority).In(selectedPriorities);
                else
                    query.And(DAL.BugInfo.Columns.Priority).In(selectedPriorities);
            }

            if (!selectedStates.IsNullOrEmpty())
            {
                if (!query.HasWhere)
                    query.Where(DAL.BugInfo.Columns.BugStatus).In(selectedStates);
                else
                    query.And(DAL.BugInfo.Columns.BugStatus).In(selectedStates);
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
                            latestStartTime = Convert.IsDBNull(reader[DAL.BugInfo.Columns.LatestStartTime]) ? DateTime.MinValue : Convert.ToDateTime(reader[DAL.BugInfo.Columns.LatestStartTime]),
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
                DAL.BugInfo.DealManColumn,
                DAL.BugInfo.VersionColumn
                ).From<DAL.ChangeLog>()
                .InnerJoin<DAL.BugInfo>()
                .Where(DAL.BugInfo.DealManColumn).IsEqualTo(dealMan)
                .And(DAL.ChangeLog.CreateDateColumn).IsGreaterThanOrEqualTo(startDate)
                .And(DAL.ChangeLog.CreateDateColumn).IsLessThanOrEqualTo(endDate)
                .And(DAL.ChangeLog.LogTypeIDColumn).IsEqualTo((int)LogTypeEnum.Submit)
                .ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return new Logs.CompleteTaskLogEntity
                    {
                        Burned = reader[DAL.BugInfo.Columns.Fired].ToInt32(),
                        CompleteTime = reader[DAL.ChangeLog.Columns.CreateDate].ToDateTime(),
                        Dealman = reader[DAL.BugInfo.Columns.DealMan].ToString(),
                        Description = reader[DAL.BugInfo.Columns.Description].ToString(),
                        Estimate = reader[DAL.BugInfo.Columns.Size].ToInt32(),
                        ItemId = reader[DAL.BugInfo.Columns.BugNum].ToString(),
                        Version = reader[DAL.BugInfo.Columns.Version].ToString(),
                    };
                }
            }

        }


        public int CountFeedbacks(string itemId)
        {
            int count = DAL.DB
                .Select()
                .From<DAL.ChangeLog>()
                .Where(DAL.ChangeLog.Columns.BugNum).IsEqualTo(itemId)
                .And(DAL.ChangeLog.Columns.LogTypeID).IsEqualTo((int)LogTypeEnum.Submit)
                .GetRecordCount() - 1;

            return count < 0
                ? 0
                : count;
        }


        public TaskLogEntity[] QueryTasks(QueryTaskParameter parameter)
        {
            List<string> bugNums = new List<string>(16);
            using (var reader = new SubSonic.Select(DAL.ChangeLog.BugNumColumn
                ).From<DAL.ChangeLog>()
                .InnerJoin<DAL.BugInfo>()
                .Where(DAL.BugInfo.DealManColumn).IsEqualTo(parameter._programmer)
                .And(DAL.ChangeLog.CreateDateColumn).IsGreaterThanOrEqualTo(parameter._searchStart)
                .And(DAL.ChangeLog.CreateDateColumn).IsLessThanOrEqualTo(parameter._searchEnd)
                .Distinct()
                .ExecuteReader())
            {
                while (reader.Read())
                {
                    bugNums.Add(reader[0].ToString());
                }
            }

            TaskLogEntity[] items = new TaskLogEntity[bugNums.Count];
            if (items.Length == 0)
                return items;


            for (int i = 0; i < items.Length; i++)
            {
                BugInfo bugInfo = new BugInfo();
                bugInfo.LoadByKey(bugNums[i]);
                if (bugInfo.IsLoaded)
                {
                    items[i] = new TaskLogEntity
                    {
                        ItemId = bugNums[i],
                        Status = bugInfo.BugStatus,
                        Version = bugInfo.Version,
                        Estimate = bugInfo.Size,
                        Burned = new BurnedHistory(bugNums[i],
                            parameter._searchStart, 
                            parameter._searchEnd)
                                ._burnedTotalMinuts,
                        Description = bugInfo.Description,
                        Dealman = bugInfo.DealMan,
                    };

                }
                else
                    throw new ArgumentException(string.Format("Invalid bugNum {0}", bugNums[i]));
            }

            return items;
        }
    }
}
