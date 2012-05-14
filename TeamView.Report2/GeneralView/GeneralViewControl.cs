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
        private Report.Factory _reportFactory;
        private IDealMen _dealMen;
        private ReportEntity[] _reportEntities;
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
            _reportEntities = _reportFactory(
                _programmerDropdownlist.Text,
                _searchStart.Value,
                _searchEnd.Value)._list;

            _bindingSource.DataSource = _reportEntities;

        }

        private void _loadButton_Click(object sender, EventArgs e)
        {
            ReportEntity[] entities;
            if (LoadReport(out entities))
            {

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
            _bindingSource.EndEdit();

            _grid.RefreshEdit();
        }

        private static void Save(ReportEntity[] reportEntities)
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

                    WriteToFile(tempFileName, reportEntities);

                    if (overwrite)
                    {
                        File.Delete(fileName);
                    }

                    File.Move(tempFileName, fileName);
                }
            }
        }

        private static void WriteToFile(string tempFileName, ReportEntity[] reportEntities)
        {
            new XDocument(
                new XElement("ReportEntities",
                reportEntities.Select(
                n => new XElement("ReportEntity",
                    new XElement("BugNum", n.BugNum),
                    new XElement("_burnedMins", n._burnedMins),
                    new XElement("_sizeInMins", n._sizeInMins),
                    new XElement("Programmer", n.Programmer),
                    new XElement("Points", n.Points),
                    new XElement("ResultPoint", n.ResultPoint)
                    )))).Save(tempFileName);
            
        }

        private static bool LoadReport(out ReportEntity[] reportEntities)
        { 
            reportEntities = null;
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    reportEntities = LoadFromFile(dlg.FileName);

                    return true;
                }
                else
                    return false;
            }
        }

        private static ReportEntity[] LoadFromFile(string fileName)
        {
            XDocument doc = XDocument.Load(fileName);

            return (from n in doc.Descendants("ReportEntity")
                   select new ReportEntity {
                       _burnedMins = n.Element("_burnedMins").Value.ToInt32(),
                       _sizeInMins = n.Element("_sizeInMins").Value.ToInt32(),
                       BugNum = n.Element("BugNum").Value,
                       Points = n.Element("Points").Value.ToInt32(),
                       Programmer = n.Element("Programmer").Value,
                       ResultPoint = n.Element("ResultPoint").Value.ToInt32(),
                   }).ToArray();

        }

        
    }
}
