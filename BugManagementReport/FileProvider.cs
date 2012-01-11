using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FxLib.Algorithms;
using TeamView.Common;
using TeamView.Common.Logs;

namespace BugManagementReport
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
    }
}
