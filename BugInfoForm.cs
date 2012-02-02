using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TeamView.DaoImpl;
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
            BITakeTime.Text = BugInfoManagement_Resource.BITakeTime;
            BIPriority.Text = BugInfoManagement_Resource.BIPriority;
            BIBugDescription.Text = BugInfoManagement_Resource.BIBugDescription;
            BIAssessment.Text = BugInfoManagement_Resource.BIAssessment;
            mDoAddButton.Text = BugInfoManagement_Resource.mDoAddButton;
            mQuitButton.Text = BugInfoManagement_Resource.mQuitButton;

        }

        private AssignPointsControl mAssignPointsControl;

        BugInfoViewModel _model;
        IBugInfoRepository _repository;
        public BugInfoForm(AssignPointsControl assignPointsControl,
            IDealMen dealMen,
            IBugStates bugStates,
            BugInfoViewModel bugInfoMoel,
            IBugInfoRepository repository)
            : this()
        {
            mAssignPointsControl = assignPointsControl;
            mAssignPointsControlContainer.Controls.Add(assignPointsControl);
            assignPointsControl.Dock = DockStyle.Fill;
            DealMen = dealMen;
            BugStates = bugStates;
            _model = bugInfoMoel;
            _repository = repository;
        }

        public void Init(string itemId, int moveSequence)
        {
            _model.Load(itemId, moveSequence);
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
            mDealMenBindingSource.DataSource = this.DealMen.DealMen;
            mCreatedManBindingSource.DataSource = this.DealMen.DealMen;

            mDataSource.Add(_model.Current);

            mSimpleEditor.Load(_model.LoadDoc(_model.Current.bugNum));

            mStateControl.CurrentState = StatesConverter.ToStateEnum(_model.Current.bugStatus);


            //if (BugInfoManager is CreateBugInfoManager)
            //{
            //    mDealManComboBox.SelectedIndex = 0;
            //    mStateControl.Visible = false;
            //    //do nothing here
            //}
            //else if (BugInfoManager is EditBugInfoManager)
            //{
            //    mBugNumTextBox.Enabled = false;
            //    mCreatedComboBox.Enabled = false;

            //    if (BugInfoManager.BugInfo.BugStatus == States.Pending
            //        || BugInfoManager.BugInfo.BugStatus == States.Abort)
            //    {
            //        if (MessageBox.Show("Click Yes，start task right now!", "Start the tast?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //        {
            //            var oldBugStatus = BugInfoManager.BugInfo.BugStatus;
            //            ((EditBugInfoManager)BugInfoManager).MoveState(StatesEnum.Start);

            //            ((CurrencyManager)BindingContext[mDataSource]).Refresh();
            //        }
            //    }

            //}
            //else
            //{
            //    throw new ApplicationException("invalid type");
            //}

            //BugInfoManager.LoadDetail(mSimpleEditor);

        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void mStateControl_StateChanged(object sender, StateControl.StateChangedArgs e)
        {
            string oldStatus = _model.Current.bugStatus;
            _model.Current.bugStatus = StatesConverter.ToStateString(e.NewState);
            var checkResult = _model.ChangeStatusCheck();
            if (!string.IsNullOrEmpty(checkResult))
            {
                e.Canceled = true;
                MessageBox.Show(checkResult);
                _model.Current.bugStatus = oldStatus;
                mStateControl.CurrentState = StatesConverter.ToStateEnum(_model.Current.bugStatus);
                return;
            }

            var changeResult = _model.CommitStatus();
                using (TransactionScope trans = new TransactionScope())
                {
                    _repository.UpdateItem(_model.Current);
                    _repository.AddLog(_model.Current.bugNum, _model.Current.moveSequence, string.Empty, changeResult.LogTypeId);
                    trans.Complete();

                    mStateControl.CurrentState = StatesConverter.ToStateEnum(_model.Current.bugStatus);
                }


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
