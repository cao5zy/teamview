using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TeamView.Common.Abstracts;

namespace TeamView.Report2.GeneralView
{
    partial class GeneralViewControl : UserControl
    {
        private Report.Factory _reportFactory;
        private IDealMen _dealMen;
        public GeneralViewControl()
        {
            InitializeComponent();
        }

        public GeneralViewControl(Report.Factory reportFactory,
            IDealMen dealMen
            )
            : this()
        {
            _reportFactory = reportFactory;
            _dealMen = dealMen;

            _programmerDropdownlist.DataSource = _dealMen.DealMen;
            _programmerDropdownlist.DisplayMember = "Name";
            _programmerDropdownlist.ValueMember = "ID";
        }

        private void _searchButton_Click(object sender, EventArgs e)
        {
            Report report = _reportFactory(
                _programmerDropdownlist.Text,
                _searchStart.Value,
                _searchEnd.Value);

            _bindingSource.DataSource = report._list;

        }
    }
}
