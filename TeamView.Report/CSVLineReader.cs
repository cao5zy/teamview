using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TeamView.Report.Abstracts;

namespace TeamView.Report
{
    class CSVLineReader : ILineReader
    {
        private StreamReader _sw;
        private bool _isClose;
        public CSVLineReader(string file)
        {
            if (!File.Exists(file))
                throw new FileNotFoundException();

            try
            {
                _sw = new StreamReader(file, Encoding.Unicode);
                _isClose = false;
            }
            catch
            {
                _isClose = true;
                throw;
            }
        }

        ~CSVLineReader()
        {
            if (!_isClose)
                _sw.Close();
        }

        public string Read()
        {
            if (_isClose)
                return null;

            string line = _sw.ReadLine();

            _isClose = line == null;

            return line;
        }
    }
}
