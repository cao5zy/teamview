using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugInfoManagement.DaoImpl;
using BugInfoManagement.Dao;
using BugInfoManagement.Entity;
using BugInfoManagement.Common;

namespace BugInfoManagement
{
    public partial class BugInfoForm : Form
    {
        public delegate BugInfoForm Factory();
        private IDealMen DealMen { get; set; }

        private IBugStates BugStates { get; set; }

        private SimpleEditor mSimpleEditor;
        public BugInfoManager BugInfoManager { get; set; }
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
            BICreater.Text = BugInfoManagement_Resource.BICreater;
            BIBugDealMan.Text = BugInfoManagement_Resource.BIBugDealMan;
            BIBugState.Text = BugInfoManagement_Resource.BIBugState;
            BIPreTakeTime.Text = BugInfoManagement_Resource.BIPreTakeTime;
            BITakeTime.Text = BugInfoManagement_Resource.BITakeTime;
            BIPriority.Text = BugInfoManagement_Resource.BIPriority;
            BIBugDescription.Text = BugInfoManagement_Resource.BIBugDescription;
            BIDealRecord.Text = BugInfoManagement_Resource.BIDealRecord;
            BIAssessment.Text = BugInfoManagement_Resource.BIAssessment;
            mDoAddButton.Text = BugInfoManagement_Resource.mDoAddButton;
            mQuitButton.Text = BugInfoManagement_Resource.mQuitButton;

        }

        private AssignPointsControl mAssignPointsControl;
        public BugInfoForm(AssignPointsControl assignPointsControl,
            IDealMen dealMen,
            IBugStates bugStates)
            : this()
        {
            mAssignPointsControl = assignPointsControl;
            mAssignPointsControlContainer.Controls.Add(assignPointsControl);
            assignPointsControl.Dock = DockStyle.Fill;
            DealMen = dealMen;
            BugStates = bugStates;
        }

        private void mQuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateData()
        {
            bool result = !mAssignPointsControl.IsChanged || mAssignPointsControl.CanAssign;
            if (!result)
            {
                MessageBox.Show("Please set the estimatedValue completely");
            }

            return result;
        }
        private void mDoAddButton_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
                return;

            var programmerPoint = mAssignPointsControl.GetProgrammerPoint();

            programmerPoint.Assignee = BugInfoManager.BugInfo.DealMan;

            BugInfoManager.BugInfo.EstimatedValue = PointsParser.ToParseString(programmerPoint);

            if (BugInfoManager.Save())
            {
                BugInfoManager.SaveDetail(mSimpleEditor);
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Concurrency issue occurs");
            }
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            mDealMenBindingSource.DataSource = this.DealMen.DealMen;
            mCreatedManBindingSource.DataSource = this.DealMen.DealMen;

            mDataSource.Add(BugInfoManager.BugInfo);

            if (BugInfoManager is CreateBugInfoManager)
            {
                mDealManComboBox.SelectedIndex = 0;
                mStateControl.Visible = false;
                //do nothing here
            }
            else if (BugInfoManager is EditBugInfoManager)
            {
                mBugNumTextBox.Enabled = false;
                mCreatedComboBox.Enabled = false;

                if (BugInfoManager.BugInfo.BugStatus == States.Pending
                    || BugInfoManager.BugInfo.BugStatus == States.Abort)
                {
                    if (MessageBox.Show("Click Yes，start task right now!", "Start the tast?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var oldBugStatus = BugInfoManager.BugInfo.BugStatus;
                        ((EditBugInfoManager)BugInfoManager).MoveState(StatesEnum.Start);

                        ((CurrencyManager)BindingContext[mDataSource]).Refresh();
                    }
                }

                mStateControl.CurrentState = StatesConverter.ToStateEnum(BugInfoManager.BugInfo.BugStatus);
            }
            else
            {
                throw new ApplicationException("invalid type");
            }

            BugInfoManager.LoadDetail(mSimpleEditor);

        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void mStateControl_StateChanged(object sender, StateControl.StateChangedArgs e)
        {
            var bugEditManager = BugInfoManager as EditBugInfoManager;
            if (bugEditManager == null)
                throw new Exception("Invalid eidt type");

            bugEditManager.MoveState(e.NewState);
            ((CurrencyManager)BindingContext[mDataSource]).Refresh();
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
