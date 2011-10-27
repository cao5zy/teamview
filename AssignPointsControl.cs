using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugInfoManagement.Entity;
using BugInfo.Common.Entity;

namespace BugInfoManagement
{
    public partial class AssignPointsControl : UserControl
    {
        
        public AssignPointsControl()
        {
            InitializeComponent();
        }
        public AssignPointsControl(IDealMen dealMen) : this() {

            mEsitmatedByComboBox.DataSource = dealMen.DealMen;
            mEsitmatedByComboBox.DisplayMember = "Name";
            mEsitmatedByComboBox.ValueMember = "Name";

            mPointsCombox.DataSource = new List<string> { 
                string.Empty,
                PointsEnum.Basic.ToString(),
                PointsEnum.BasicPlus.ToString(),
                PointsEnum.Median.ToString(),
                PointsEnum.MedianPlus.ToString(),
                PointsEnum.High.ToString(),
                PointsEnum.HighPlus.ToString()
            };
        }

        public ProgrammerPoint GetProgrammerPoint()
        {
            return new ProgrammerPoint { 
                EstimatedBy = mEsitmatedByComboBox.SelectedValue.ToString(),
                EstimatedLevel = mPointsCombox.Text,
                EstimatedTime = DateTime.Now
            };
        }

        private string EstimatedBy
        {
            get
            {
                return mEsitmatedByComboBox.SelectedValue.ToString();
            }
        }

        private string EstimatedLevel
        {
            get
            {
                return mPointsCombox.Text;
            }
        }
        public bool CanAssign
        {
            get
            {
                return !(string.IsNullOrEmpty(EstimatedBy)
                    || string.IsNullOrEmpty(EstimatedLevel));
            }
        }

        public bool IsChanged
        {
            get
            {
                return !(string.IsNullOrEmpty(EstimatedBy)
                    && string.IsNullOrEmpty(EstimatedLevel));
            }
        }

    }


}
