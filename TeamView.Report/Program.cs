using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Threading;
using FxLib.Algorithms;
using System.IO;
using Dev3Lib;

namespace TeamView.Report
{
    class Program
    {
        /*
         *report committed:\week:thisweek \u:czy thisWeekCommitted \commithistory
         * 
         */
        static void Main(string[] args)
        {
            Builder builder = new Builder();

            Regex regFileName = new Regex(@"^[\w][\w\s:.\\]+", RegexOptions.IgnoreCase);
            Regex option = new Regex(@"^\\(\w+)(:[^\s]+)?", RegexOptions.IgnoreCase);

            string outFileName = string.Empty;
            string userNames = string.Empty;
            DateTime start = DateTime.MinValue;
            DateTime end = DateTime.MinValue;
            bool sortByBugNum = false;
            bool includePast = true;
            bool onlyTask = false;
            bool taskHistory = false;
            bool commitHistory = false;
            bool reportSummary = false;
            bool doSummary = false;
            string summaryFileName = null;

            string versionnumber = string.Empty;

            foreach (var arg in args)
            {
                if (regFileName.IsMatch(arg))
                    outFileName = arg;
                else if (option.IsMatch(arg))
                {
                    var match = option.Match(arg);
                    if (match.Groups[1].Value == "version")
                    {
                        versionnumber = match.Groups[2].Value.Substring(1);
                        continue;
                    }
                    else if (match.Groups[1].Value.ToLower() == "taskhistory")
                    {
                        taskHistory = true;
                        continue;
                    }
                    else if (match.Groups[1].Value.ToLower() == "commithistory")
                    {
                        commitHistory = true;
                        continue;
                    }
                    else if (match.Groups[1].Value == "onlyTask")
                    {
                        onlyTask = true;
                        continue;
                    }
                    else if (match.Groups[1].Value.OrdinalIngoreCaseCompare("reportsummary"))
                    {
                        reportSummary = true;
                        continue;
                    }
                    else if (match.Groups[1].Value == "u")
                    {
                        userNames = match.Groups[2].Value.Substring(1);
                        continue;
                    }
                    else if (match.Groups[1].Value == "sort")
                    {
                        sortByBugNum = match.Groups[2].Value.Substring(1) == "bugNum";
                    }
                    else if (match.Groups[1].Value == "past")
                    {
                        includePast = match.Groups[2].Value.Substring(1) == "true";
                    }
                    else if (match.Groups[1].Value == "s")
                    {
                        start = Convert.ToDateTime(match.Groups[2].Value.Substring(1));
                    }
                    else if (match.Groups[1].Value == "e")
                    {
                        end = Convert.ToDateTime(match.Groups[2].Value.Substring(1));
                    }
                    else if (match.Groups[1].Value == "week")
                    {
                        if (match.Groups[2].Value.Substring(1) == "previousweek")
                        {
                            start = DateTime.Today.AddDays(
                                -((int)DateTime.Today.DayOfWeek - (int)DayOfWeek.Sunday))
                                .AddDays(-7);
                            end = DateTime.Today.AddDays(-((int)DateTime.Today.DayOfWeek - (int)DayOfWeek.Monday))
                                .AddDays(1);

                        }
                        else
                        {
                            start = DateTime.Today.AddDays(
                                -((int)DateTime.Today.DayOfWeek - (int)DayOfWeek.Monday));
                            end = DateTime.Today.AddDays(
                                (int)DayOfWeek.Saturday - (int)DateTime.Today.DayOfWeek).AddDays(1);
                        }
                    }
                    else if (match.Groups[1].Value.OrdinalIngoreCaseCompare("sum"))
                    {
                        doSummary = true;
                        summaryFileName = match.Groups[2].Value.Substring(1);
                    }
                }
            }

#if DEBUG
            //Console.WriteLine("waiting for debug");
            //Thread.Sleep(20000);
#endif

            if (taskHistory)
            {
                Console.WriteLine("parsing");
                var s = builder.Resolve<TaskRecordManager>();

                outFileName += ".csv";
                if (File.Exists(outFileName))
                    File.Delete(outFileName);
                s.ParseTask(outFileName,
                    start,
                    end,
                    string.IsNullOrEmpty(userNames) ? null : userNames.Split(new char[] { ',' }),
                    sortByBugNum,
                    includePast,
                    onlyTask,
                    reportSummary);
                Console.WriteLine("parsing completed");
            }
            else if (commitHistory)
            {
                outFileName += ".csv";
                if (File.Exists(outFileName))
                    File.Delete(outFileName);
                builder.Resolve<TaskRecordManager>().ParseCompleteTasksHistory(outFileName, userNames, start, end);
            }
            else if (doSummary)
            {
                new SummaryTaskParser(summaryFileName).Parse();
            }

            Console.WriteLine("press any key to quit");
            Console.ReadKey();
        }

    }
}
