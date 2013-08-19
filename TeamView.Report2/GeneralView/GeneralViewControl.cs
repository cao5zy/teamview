using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TeamView.Common.Abstracts;
using System.IO;
using System.Xml.Linq;
using Dev3Lib.Algorithms;
using Dev3Lib;

namespace TeamView.Report2.GeneralView
{
    partial class GeneralViewControl : UserControl
    {
        private GeneralViewReport.Factory _reportFactory;
        private IDealMen _dealMen;
        private GeneralViewReportEntity[] _reportEntities;
        private BugInfoForm.Factory _bugInfoFormFactory;
        public GeneralViewControl()
        {
            InitializeComponent();
        }

        public GeneralViewControl(GeneralViewReport.Factory reportFactory,
            IDealMen dealMen,
            BugInfoForm.Factory bugInfoFormFactory
            )
            : this()
        {
            _reportFactory = reportFactory;
            _bugInfoFormFactory = bugInfoFormFactory;
            _dealMen = dealMen;

            _programmerDropdownlist.DataSource = _dealMen.DealMen;
            _programmerDropdownlist.DisplayMember = "Name";
            _programmerDropdownlist.ValueMember = "ID";
        }

        private void _searchButton_Click(object sender, EventArgs e)
        {
            _reportEntities = _reportFactory(
                _programmerDropdownlist.Text,
                _searchStart.Value,
                _searchEnd.Value)._list;

            _bindingSource.DataSource = _reportEntities;

        }

        private void _loadButton_Click(object sender, EventArgs e)
        {
            GeneralViewReportEntity[] entities;
            if (LoadReport(out entities))
            {
                _reportEntities = entities;
                _bindingSource.DataSource = entities;
            }
        }

        private void _saveButton_Click(object sender, EventArgs e)
        {
            Save(_reportEntities);
        }

        private void _calButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _reportEntities.Length; i++)
            {
                _reportEntities[i].Cal();
            }

            _totalPointsLabel.Text = Math.Round(_reportEntities.Sum(n => n.ResultPoint), 2).ToString();
            _totalBurned.Text = Math.Round(_reportEntities.Sum(n => (double)n._currentBurnedMins/60), 2).ToString();
            _grid.RefreshEdit();
            _grid.Refresh();
        }

        private static void Save(GeneralViewReportEntity[] reportEntities)
        {
            if (reportEntities.IsNullOrEmpty())
                return;

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var fileName = dlg.FileName;
                    bool overwrite = File.Exists(fileName);

                    string tempFileName = Path.GetTempFileName();

                    ReportFileData.WriteToFile(tempFileName, reportEntities);

                    if (overwrite)
                    {
                        File.Delete(fileName);
                    }

                    File.Move(tempFileName, fileName);
                }
            }
        }


        private static bool LoadReport(out GeneralViewReportEntity[] reportEntities)
        {
            reportEntities = null;
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    reportEntities = ReportFileData.LoadFromFile(dlg.FileName);

                    return true;
                }
                else
                    return false;
            }
        }



        private void _grid_DoubleClick(object sender, EventArgs e)
        {
            if (_grid.SelectedRows.Count != 0)
            {
                var form = _bugInfoFormFactory();
                form.Init(_reportEntities[_grid.SelectedRows[0].Index].BugNum);
                form.Show();
            }
        }


    }
}
