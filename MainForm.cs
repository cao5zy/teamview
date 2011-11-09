using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BugInfoManagement.Dao;
using BugInfoManagement.DaoImpl;
using BugInfoManagement.Entity;
using BugInfoManagement.Utility;
using System.Configuration;
using BugInfoManagement.Common;

namespace BugInfoManagement
{
    public partial class MainForm : Form
    {
        ListOrder lo = new ListOrder();

        public IDealMen DealMen { get; set; }
        public IBugStates BugStates { get; set; }
        public IBugInfoManagement BugInfoManagement { get; set; }
        public INotificationSetting NotificationSetting { get; set; }
        public INotificationManager NotificationManager { get; set; }
        private EditBugInfoManager.Factiory EditBugInfoManagerFactory { get; set; }
        private CreateBugInfoManager.Factory CreateBugInfoManagerFactory { get; set; }
        private BugInfoForm.Factory CreateBugInfoForm { get; set; }

        private QueryParameter mQueryParameter = new QueryParameter();
        public MainForm(
            BugInfoForm.Factory createBugInfoForm,
            EditBugInfoManager.Factiory createEditBugInfoManager,
            CreateBugInfoManager.Factory createCreateBugInfoManager)
        {
            InitializeComponent();
            CreateBugInfoForm = createBugInfoForm;
            EditBugInfoManagerFactory = createEditBugInfoManager;
            CreateBugInfoManagerFactory = createCreateBugInfoManager;
            mQueryGroupBox.Text = BugInfoManagement_Resource.mQueryGroupBox;
            mDealManlabel.Text = BugInfoManagement_Resource.mDealManlabel;
            mBugNumberLabel.Text = BugInfoManagement_Resource.mBugNumberLabel;
            mDescriptionLabel.Text = BugInfoManagement_Resource.mDescriptionLabel;
            mStateLabel.Text = BugInfoManagement_Resource.mStateLabel;
            mVersionNumber.Text = BugInfoManagement_Resource.mVersionNumber;
            mQueryButton.Text = BugInfoManagement_Resource.mQueryButton;
            mAddButton.Text = BugInfoManagement_Resource.mAddButton;
            mEditButton.Text = BugInfoManagement_Resource.mEditButton;
        }

        private BugInfoEntity CurrentSelectedItem
        {
            get
            {
                if (mBugInfoListDataGridView.CurrentRow == null)
                    return null;

                return ((List<BugInfoEntity>)mBugInfoListDataGridView.DataSource)[mBugInfoListDataGridView.CurrentRow.Index];
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            mBugInfoListDataGridView.AutoGenerateColumns = false;
            mDealManBindingSource.DataSource = DealMen.DealMen;
            mStatesBindingSource.DataSource = BugStates.States;
            mQueryBindingSource.Add(mQueryParameter);

            mDealManComboBox.SelectedValue = NotificationSetting.ProgrammerName;
            mQueryBindingSource.EndEdit();

            //DataGridView绑定List排序
            this.mBugInfoListDataGridView.DataSource = BugInfoManagement.QueryByParameter(mQueryParameter); ;




            mTimer.Interval = NotificationSetting.FrequenceInMinutes * 1000 * 60;
            mTimer.Start();

            NotificationManager.Refresh();
        }

        //查询按钮事件处理
        private void mQueryButton_Click(object sender, EventArgs e)
        {
            LoadBugInfos();
        }

        private void LoadBugInfos()
        {
            var results = BugInfoManagement.QueryByParameter(mQueryParameter);
            this.mBugInfoListDataGridView.DataSource = results;

            SetQueryCount(mBugInfoListDataGridView.Rows.Count, results.Sum(b => b.Size));
        }

        //新增按钮事件处理
        private void mAddButton_Click(object sender, EventArgs e)
        {
            BugInfoForm f = CreateBugInfoForm();
            f.Text = BugInfoManagement_Resource.AddBugInfoFormName;
            f.BugInfoManager = CreateBugInfoManagerFactory();
            f.Show();
            //f.Dispose();
            //GC.Collect();
        }

        //修改按钮事件处理
        private void mEditButton_Click(object sender, EventArgs e)
        {
            if (this.mBugInfoListDataGridView.CurrentRow != null)
            {
                BugInfoForm f = CreateBugInfoForm();
                f.BugInfoManager = EditBugInfoManagerFactory();
                ((EditBugInfoManager)f.BugInfoManager).Initialize(((BugInfoEntity)mBugInfoListDataGridView.BindingContext[mBugInfoListDataGridView.DataSource].Current).BugNum);
                f.Text = BugInfoManagement_Resource.EditBugInfoFormName +" "+((BugInfoEntity)mBugInfoListDataGridView.BindingContext[mBugInfoListDataGridView.DataSource].Current).BugNum;
                f.Show();
                //f.Dispose();
                //GC.Collect();
            }
            else
            {
                MessageBox.Show(BugInfoManagement_Resource.Message4);
            }

            mQueryButton_Click(null, null);
        }

        //删除按钮事件处理
        private void mDeleteButton_Click(object sender, EventArgs e)
        {
            if (this.mBugInfoListDataGridView.CurrentRow != null)
            {
                if (MessageBox.Show(BugInfoManagement_Resource.Message5, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BugInfoManagement.DeleteByBugNum(mBugInfoListDataGridView.CurrentRow.Cells[1].Value.ToString());
                    mQueryButton_Click(null, null);
                    MessageBox.Show(BugInfoManagement_Resource.Message6, BugInfoManagement_Resource.Message7, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(BugInfoManagement_Resource.Message8);
            }
        }

        private void SetQueryCount(int count, decimal totalHours)
        {
            mQueryGroupBox.Text = string.Format("{0}:{1}-{2}:{3}", BugInfoManagement_Resource.TotalRecord, count, BugInfoManagement_Resource.TotalTime, totalHours);
        }

        private void mNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!mIsClose)
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }

        private void mShowMenu_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private bool mIsClose = false;
        private void mExitMenu_Click(object sender, EventArgs e)
        {
            mIsClose = true;
            this.Close();
        }

        private void mTimer_Tick(object sender, EventArgs e)
        {
            NotificationManager.Refresh();

            if (NotificationManager.HasIncommingList)
            {
                mNotifyIcon.ShowBalloonTip(0);
            }
        }

        private void mBugInfoListDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (CurrentSelectedItem == null)
                return;

            var currentSelectedItem = CurrentSelectedItem;
            mFlowMenu.Items[0].Enabled = currentSelectedItem.BugStatus == States.Abort
                || currentSelectedItem.BugStatus == States.Complete
                || currentSelectedItem.BugStatus == States.Pending;
            mFlowMenu.Items[1].Enabled = currentSelectedItem.BugStatus == States.Start;
            mFlowMenu.Items[2].Enabled = currentSelectedItem.BugStatus == States.Start;
        }

        private void mBugInfoListDataGridView_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            mBugInfoListDataGridView.CurrentCell = mBugInfoListDataGridView[e.ColumnIndex, e.RowIndex];

        }

        private void mFlowMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var editBugInfoManager = EditBugInfoManagerFactory();
            editBugInfoManager.Initialize(CurrentSelectedItem.BugNum);
            editBugInfoManager.MoveState((StatesEnum)Enum.Parse(typeof(StatesEnum), e.ClickedItem.Text));
            LoadBugInfos();
        }

    }
}
