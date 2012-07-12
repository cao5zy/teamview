using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FxLib.Algorithms;
using TeamView.Common;
using TeamView.Common.Logs;

namespace TeamView.Report
{
    class FileProvider : IFileProvider
    {
        #region IFileProvider Members

        public void WriteSnapShot(string fileName, IEnumerable<DbItem> items)
        {
            string format = "{0}\t{1}\t{2}\t{3}\t{4}\t{5}";
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    sw.WriteLine(string.Format(format, new object[]{ DateTime.Now,
                        string.Empty,
                        string.Empty,
                        string.Empty,
                        string.Empty,
                    string.Empty}));
                    foreach (var item in items)
                    {
                        sw.WriteLine(string.Format(format, new object[]{
                            item.dealMan,
                            item.version,
                            item.priority,
                            item.bugStatus,
                            item.bugNum,
                            item.description}));
                    }
                    sw.Flush();
                }
            }
        }

        #endregion

        #region IFileProvider Members


        public void WriteLogs(string filename, IEnumerable<TaskRecord> items)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    items.SafeForEach(n => sw.WriteLine(n.ToRecordString()));

                    sw.Flush();
                }
            }
        }

        #endregion


        public void WriteCompleteTaskLogs(string fileName, IEnumerable<CompleteTaskLogEntity> items)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    items.SafeForEach(n => sw.WriteLine(FromCompleteTaskLockEntity(n)));

                    sw.Flush();
                }
            }
        }

        private string FromCompleteTaskLockEntity(CompleteTaskLogEntity record)
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}",
                new object[]{
                record.ItemId,
                record.Order,
                record.Dealman,
                record.Description.RemoveNewLine(),
                record.CompleteTime,
                Math.Round((double)record.Estimate/60, 2),
                Math.Round((double)record.Burned/60, 2),
                record.Version
                });
        }
    }
}
