using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Report.Abstracts
{
    abstract class LineParser<T>
    {
        private ILineReader _reader;
        public LineParser(ILineReader reader)
        {
            _reader = reader;
        }

        public List<T> Parse()
        {
            return DoParse(_reader);
        }

        protected abstract List<T> DoParse(ILineReader reader);
    }
}
