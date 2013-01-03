using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TeamView.Report.Abstracts;
using TeamView.Report.Entities;

namespace TeamView.Report
{
    sealed class SummaryTaskParser : LineParser<SummaryEntity>
    {
        private string _outputFile;
        public SummaryTaskParser(string csvfile) : base(new CSVLineReader(csvfile)) {
            _outputFile = csvfile + ".csv";
        }

        static Regex _regex = new Regex(@"([\d.]+)\s+(.+)");
        protected override List<SummaryEntity> DoParse(ILineReader reader)
        {
            List<SummaryEntity> list = new List<SummaryEntity>();
            string line = reader.Read();

            while (line != null)
            {
                var match = _regex.Match(line);
                if (match.Success)
                {
                    try
                    {
                        list.Add(new SummaryEntity
                        {
                            Amount = decimal.Parse(match.Groups[1].Value),
                            Task = match.Groups[2].Value,
                        });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(line);
                        Console.WriteLine(ex.Message);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(line);
                    break;
                }

                line = reader.Read();
            }

            var sum = from item in list
                      group item by item.Task into g
                      select new SummaryEntity { Task = g.Key, Amount = g.Sum(item => item.Amount) };

            using (var fs = new FileStream(_outputFile, FileMode.Create))
            {
                using (var sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    foreach (var item in sum)
                    {

                        sw.WriteLine(string.Format("{0}\t{1}", item.Task, item.Amount));
                    }

                }
            }
            return sum.ToList();

        }
    }
}
