using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugInfo.Common;

namespace IniTeamView.UserControls
{
    public class JIRAImportController
    {
        private IItemImporter mItemImporter;
        public JIRAImportController(IItemImporter itemImporter)
        {
            mItemImporter = itemImporter;
        }

        public IEnumerable<string> ImportedList
        {
            get
            { return mItemImporter.ImportedList; }
        }
        public void Import(JIRAImportModel model)
        {
            mItemImporter.Import(model.ImportFile,
                model.Version,
                model.Reporter,
                model.Handler);
        }
    }
}
