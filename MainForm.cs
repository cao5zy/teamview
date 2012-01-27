using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using TeamView.Dao;
using TeamView.DaoImpl;
using TeamView.Entity;
using TeamView.Utility;
using System.Configuration;
using TeamView.Common;
using FxLib.Algorithms;
using TeamView.Common.Models;
using TeamView.Common.Dao;
using System.Transactions;

namespace TeamView
{
    partial class MainForm : Form
    {
        public IDealMen DealMen { get; set; }
        public IBugStates BugStates { get; set; }
        private EditBugInfoManager.Factiory EditBugInfoManagerFactory { get; set; }
        private CreateBugInfoManager.Factory CreateBugInfoManagerFactory { get; set; }
        private BugInfoForm.Factory CreateBugInfoForm { get; set; }
        private QueryControl mQueryControl;
        private AddNewForm.Factory _addFormFactory;
        private BugInfoViewModel _bugInfoModel;
        private IBugInfoRepository _repository;
        private IQuery _query;
        public MainForm(
            BugInfoForm.Factory createBugInfoForm,
            EditBugInfoManager.Factiory createEditBugInfoManager,
            CreateBugInfoManager.Factory createCreateBugInfoManager, 
            QueryControl queryControl,
            AddNewForm.Factory addFormFactory,
            BugInfoViewModel bugInfoModel,
            IBugInfoRepository repository,
            IQuery bugQuery)
        {
            InitializeComponent();
            CreateBugInfoForm = createBugInfoForm;
            EditBugInfoManagerFactory = createEditBugInfoManager;
            CreateBugInfoManagerFactory = createCreateBugInfoManager;
            _addFormFactory = addFormFactory;
            _bugInfoModel = bugInfoModel;
            _repository = repository;
            _query = bugQuery;

            mAddButton.Text = BugInfoManagement_Resource.mAddButton;
            mEditButton.Text = BugInfoManagement_Resource.mEditButton;

            mQueryControl = queryControl;
            mQueryControlContainer.Controls.Add(queryControl);
            queryControl.Dock = DockStyle.Fill;
            queryControl.Query += (s, e) => {
                LoadBugInfos();
            };
        }

        private BugInfoSet.BugInfoTableRow CurrentSelectedItem
        {
            get
            {
                if (mBugInfoSet.BugInfoTable.Rows.Count == 0 || mBugInfoListDataGridView.CurrentRow == null)
                    return null;

                if (mBugInfoSet.BugInfoTable.Rows.Count <= mBugInfoListDataGridView.CurrentRow.Index)
                    return null;

                return (BugInfoSet.BugInfoTableRow)((DataRowView)mBugInfoListDataGridView.CurrentRow.DataBoundItem).Row;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            mBugInfoListDataGridView.AutoGenerateColumns = false;

            var model = mQueryControl.Model;
           

            mQueryControl.Init();

            LoadBugInfos();

        }

        private void LoadBugInfos()
        {
            var model = mQueryControl.Model;
            var results = _query.QueryByParameters(
                model.SelectedProgrammers,
                model.BugNum,
                model.Version,
                model.Description,
                model.Priority,
                model.SelectedState
                );

            mBugInfoSet.BugInfoTable.Clear();
            int itemCount = 0;
            decimal totalSize = 0;
            decimal totalHours = 0;
            results.SafeForEach(
                n => {
                    var row = mBugInfoSet.BugInfoTable.NewBugInfoTableRow();
                    row.bugNum = n.bugNum;
                    row.bugStatus = n.bugStatus;
                    row.dealMan = n.dealMan;
                    row.description = n.description;
                    row.Version = n.version;
                    row.size = n.size;
                    row.Priority = n.priority;
                    row.fired = Math.Round((double)n.fired / 60, 2);
                    row.order = n.moveSequence;
                    mBugInfoSet.BugInfoTable.Rows.Add(row);
                    itemCount++;
                    totalHours += (decimal)row.fired;
                    totalSize += (decimal)row.size;
                }
                );

            //ShowSummary(results.Count, (decimal)results.Sum(n => n.size), results.Sum(n => n.fired / 60));
            ShowSummary(itemCount, totalSize, totalHours);
        }


        //新增按钮事件处理
        private void mAddButton_Click(object sender, EventArgs e)
        {
            using (var form = _addFormFactory())
            {
                form.ShowDialog();
            }
        }

        //修改按钮事件处理
        private void mEditButton_Click(object sender, EventArgs e)
        {
            if (this.mBugInfoListDataGridView.CurrentRow != null)
            {
                BugInfoForm f = CreateBugInfoForm();
                var bugNum = CurrentSelectedItem.bugNum;
                f.Init(bugNum, 0);
                f.Text = BugInfoManagement_Resource.EditBugInfoFormName +" "+bugNum;
                f.Show();
            }
            else
            {
                MessageBox.Show(BugInfoManagement_Resource.Message4);
            }
        }

        private void ShowSummary(int count, decimal totalHours, decimal totalFired)
        {
            this.Text = "TeamView:" + BugInfoManagement_Resource.TotalRecord + " " + count.ToString() +"/estimated " + totalHours.ToString()+ " hours" + "/fired " + totalFired.ToString() + " hours";
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

        private void mBugInfoListDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (CurrentSelectedItem == null)
            {
                mFlowMenu.Items[0].Enabled = false;
                mFlowMenu.Items[1].Enabled = false;
                mFlowMenu.Items[2].Enabled = false;
                return;
            }

            var currentSelectedItem = CurrentSelectedItem;
            mFlowMenu.Items[0].Enabled = currentSelectedItem.bugStatus == States.Abort
                || currentSelectedItem.bugStatus == States.Complete
                || currentSelectedItem.bugStatus == States.Pending;
            mFlowMenu.Items[1].Enabled = currentSelectedItem.bugStatus == States.Start;
            mFlowMenu.Items[2].Enabled = currentSelectedItem.bugStatus == States.Start;
        }

        private void mBugInfoListDataGridView_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            mBugInfoListDataGridView.CurrentCell = mBugInfoListDataGridView[e.ColumnIndex, e.RowIndex];

        }

        private void mFlowMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var currentSelected = CurrentSelectedItem;
            var item = this._bugInfoModel.Load(currentSelected.bugNum, currentSelected.order);
            if (item == null)
                return;

            item.bugStatus = StatesConverter.ToStateString((StatesEnum)Enum.Parse(typeof(StatesEnum), e.ClickedItem.Text));

            var checkResult = _bugInfoModel.ChangeStatusCheck();
            if(!string.IsNullOrEmpty(checkResult))
            {
                MessageBox.Show(checkResult);
                return;
            }

            var result = _bugInfoModel.CommitStatus();

            var commitStatusResult = _bugInfoModel.CommitStatus();

            using (TransactionScope trans = new TransactionScope())
            {
                _repository.UpdateItem(item);
                _repository.AddLog(item.bugNum, item.moveSequence, string.Empty, result.LogTypeId);
                trans.Complete();
            }

            currentSelected.fired = item.fired;
            currentSelected.bugStatus = item.bugStatus;

            mBugInfoListDataGridView.RefreshEdit();
        }

    }
}
