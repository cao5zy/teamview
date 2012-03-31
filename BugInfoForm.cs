using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TeamView.Dao;
using TeamView.Entity;
using TeamView.Common;
using TeamView.Common.Models;
using TeamView.Common.Dao;
using System.Transactions;
using TeamView.Abstracts;

namespace TeamView
{
    public partial class BugInfoForm : Form
    {
        public delegate BugInfoForm Factory();
        private IDealMen DealMen { get; set; }

        private IBugStates BugStates { get; set; }

        private SimpleEditor mSimpleEditor;
        public BugInfoForm()
        {
            InitializeComponent();
            mSimpleEditor = new SimpleEditor();
            this.components.Add(mSimpleEditor);
            mSimpleEditor.MaxEditor += (s, e) =>
            {
                mEditorPanel.Controls.Clear();
                this.Controls.Add(mSimpleEditor);
                mSimpleEditor.BringToFront();
                mSimpleEditor.Anchor = AnchorStyles.Left;
                mSimpleEditor.Dock = DockStyle.Fill;
            };
            mSimpleEditor.MinEditor += (s, e) =>
            {
                this.Controls.Remove(mSimpleEditor);
                mEditorPanel.Controls.Add(mSimpleEditor);
                mSimpleEditor.BringToFront();
                mSimpleEditor.Anchor = AnchorStyles.Left;
                mSimpleEditor.Dock = DockStyle.Fill;
            };
            mSimpleEditor.Dock = DockStyle.Fill;
            mEditorPanel.Controls.Add(mSimpleEditor);
            BIVersionNum.Text = BugInfoManagement_Resource.BIVersionNum;
            BIBugNum.Text = BugInfoManagement_Resource.BIBugNum;
            BIBugDealMan.Text = BugInfoManagement_Resource.BIBugDealMan;
            BIPreTakeTime.Text = BugInfoManagement_Resource.BIPreTakeTime;
            BIPriority.Text = BugInfoManagement_Resource.BIPriority;
            BIBugDescription.Text = BugInfoManagement_Resource.BIBugDescription;
            BIAssessment.Text = BugInfoManagement_Resource.BIAssessment;
            mDoAddButton.Text = BugInfoManagement_Resource.mDoAddButton;
            mQuitButton.Text = BugInfoManagement_Resource.mQuitButton;

        }

        BugInfoViewModel _model;
        IBugInfoRepository _repository;
        IHardLevel _hardLevel;
        public BugInfoForm(
            IDealMen dealMen,
            IBugStates bugStates,
            BugInfoViewModel bugInfoMoel,
            IBugInfoRepository repository,
            IHardLevel hardLevel)
            : this()
        {
            DealMen = dealMen;
            BugStates = bugStates;
            _model = bugInfoMoel;
            _repository = repository;
            _hardLevel = hardLevel;
        }

        public void Init(string itemId)
        {
            _model.Load(itemId);
        }

        private void mQuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateData()
        {
            string saveMessage = _model.SaveCheck();
            if (!string.IsNullOrEmpty(saveMessage))
            {
                MessageBox.Show(saveMessage);
                return false;
            }

            return true;
        }
        private void mDoAddButton_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
                return;

            var saveResult = _model.Save();

            _repository.UpdateItem(saveResult.Object);

            if (mSimpleEditor.IsUpdated)
            {
                _model.SaveDoc(mSimpleEditor.Save());
            }
            mSimpleEditor.Reset();

            this.Close();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            hardLevelCombo.DataSource = _hardLevel.HardLevels;

            mDataSource.Add(_model.Current);

            mSimpleEditor.Load(_model.LoadDoc(_model.Current.bugNum));
        }

        private void BugInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mSimpleEditor.IsUpdated)
            {
                if (MessageBox.Show("The document has been changed. Are you sure you will close without saving?", "Saving", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            mSimpleEditor.Clear();
        }

    }
}
