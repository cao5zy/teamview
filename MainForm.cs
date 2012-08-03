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
using TeamView.Entity;
using TeamView.Utility;
using System.Configuration;
using TeamView.Common;
using FxLib.Algorithms;
using TeamView.Common.Models;
using TeamView.Common.Dao;
using System.Transactions;
using TeamView.Abstracts;
using System.Threading;
using TeamView.Common.Abstracts;
using TeamView.UIComponents;

namespace TeamView
{
    sealed partial class MainForm : Form
    {
        private DataView _bindingView;
        public IDealMen DealMen { get; set; }
        public IBugStates BugStates { get; set; }
        private BugInfoForm.Factory CreateBugInfoForm { get; set; }
        private QueryControl mQueryControl;
        private AddNewForm.Factory _addFormFactory;
        private BugInfoViewModel _bugInfoModel;
        private IBugInfoRepository _repository;
        private IQuery _query;
        private IDealMen _dealMen;
        private CurrentTaskListControl.Factory _currentTaskListControlFac;
        public MainForm(
            BugInfoForm.Factory createBugInfoForm,
            QueryControl queryControl,
            AddNewForm.Factory addFormFactory,
            BugInfoViewModel bugInfoModel,
            IBugInfoRepository repository,
            IQuery bugQuery,
            IDealMen dealMen,
            CurrentTaskListControl.Factory currentTaskListControlFac)
        {
            InitializeComponent();
            _currentTaskListControlFac = currentTaskListControlFac;
            CreateBugInfoForm = createBugInfoForm;
            _addFormFactory = addFormFactory;
            _bugInfoModel = bugInfoModel;
            _repository = repository;
            _query = bugQuery;
            _dealMen = dealMen;
            _bindingView = new DataView(mBugInfoSet.BugInfoTable);
            mBugInfoListDataGridView.DataSource = _bindingView;
            mAddButton.Text = BugInfoManagement_Resource.mAddButton;
            mEditButton.Text = BugInfoManagement_Resource.mEditButton;


            mQueryControl = queryControl;
            mQueryControlContainer.Controls.Add(queryControl);
            queryControl.Dock = DockStyle.Fill;
            queryControl.Query += (s, e) =>
            {
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

            LoadDealManMenu();
        }

        private void LoadDealManMenu()
        {
            ToolStripMenuItem issueHandlerMenu = new ToolStripMenuItem("Issue Handlers");

            issueHandlerMenu.DropDownItemClicked += new ToolStripItemClickedEventHandler(issueHandlers_DropDownItemClicked);
            _dealMen.DealMen.Where(n => n.Name != _dealMen.CurrentLogin && !string.IsNullOrEmpty(n.Name))
                .Select(n => n.Name)
                .SafeForEach(n =>
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = n;
                    issueHandlerMenu.DropDownItems.Add(item);
                });

            mFlowMenu.Items.Add(issueHandlerMenu);
        }

        private void issueHandlers_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var item = _bugInfoModel.Load(CurrentSelectedItem.bugNum);
            item.timeStamp = CurrentSelectedItem.timeStamp;
            string newIssueHandler = e.ClickedItem.Text;

            if (_bugInfoModel.HasLog(CurrentSelectedItem.bugNum))
            {

                using (TransactionScope trans = new TransactionScope())
                {
                    var checkMoveState = _bugInfoModel.CheckMoveDealMan(newIssueHandler);
                    if (!string.IsNullOrEmpty(checkMoveState))
                    {
                        MessageBox.Show(checkMoveState);
                        return;
                    }

                    var result = _bugInfoModel.MoveDealMan(newIssueHandler);

                    _repository.UpdateItem(result.NewItem);

                    trans.Complete();
                }
            }
            else
            {
                using (TransactionScope trans = new TransactionScope())
                {
                    item.dealMan = newIssueHandler;
                    var checkResult = _bugInfoModel.SaveCheck();
                    if (!string.IsNullOrEmpty(checkResult))
                    {
                        MessageBox.Show(checkResult);
                        return;
                    }

                    var result = _bugInfoModel.Save();

                    _repository.UpdateItem(result.Object);

                    trans.Complete();
                }
            }

        }

        private void LoadBugInfos()
        {
            var model = mQueryControl.Model;
            var results = _query.QueryByParameters(
                model.SelectedProgrammers,
                model.BugNum,
                model.Version,
                model.Description,
                model.SelectedPriorities,
                model.SelectedStates
                );

            mBugInfoSet.BugInfoTable.Clear();
            int itemCount = 0;
            decimal totalSize = 0;
            decimal totalHours = 0;


            results.SafeForEach(
                n =>
                {
                    var row = mBugInfoSet.BugInfoTable.NewBugInfoTableRow();
                    row.bugNum = n.bugNum;
                    row.bugStatus = n.bugStatus;
                    row.dealMan = n.dealMan;
                    row.description = n.description;
                    row.Version = n.version;
                    row.size = Math.Round((double)n.size / 60, 2);
                    row.Priority = n.priority;
                    row.fired = n.bugStatus == States.Start
                        ? Math.Round((double)n.fired / 60, 2) + Math.Round(DateTime.Now.Subtract(n.latestStartTime).TotalMinutes / 60, 2)
                        : Math.Round((double)n.fired / 60, 2);
                    row.timeStamp = n.timeStamp;
                    mBugInfoSet.BugInfoTable.Rows.Add(row);
                    itemCount++;
                    totalHours += (decimal)row.fired;
                    totalSize += (decimal)row.size;
                }
                );

            if (_smartPlan.Checked)
                _bindingView.Sort = "Priority, size";
            else
                _bindingView.Sort = "";

            ShowSummary(itemCount, totalSize, totalHours);

            ShowColorStatus();

            AsyncShowBugFeedbacks();
        }

        private void ShowColorStatus()
        {
            (from DataGridViewRow row in mBugInfoListDataGridView.Rows
             select row)
             .ToList()
             .ForEach(
             n =>
             {
                 if (n.DataBoundItem != null)
                 {
                     BugInfoSet.BugInfoTableRow row = ((DataRowView)n.DataBoundItem).Row as BugInfoSet.BugInfoTableRow;
                     if (row != null)
                     {
                         if (row.bugStatus == "Processing")
                         {
                             n.Cells["bugStatus"].Style.BackColor = Color.Green;
                             n.Cells["bugStatus"].Style.ForeColor = Color.White;
                         }
                         else
                         {
                             n.Cells["bugStatus"].Style.BackColor = Color.White;
                             n.Cells["bugStatus"].Style.ForeColor = Color.Black;
                         }

                         if (row.fired > row.size / 2 && row.fired <= row.size)
                         {
                             n.Cells["fired"].Style.BackColor = Color.Yellow;
                             n.Cells["fired"].Style.ForeColor = Color.Black;
                         }
                         else if (row.fired > row.size && row.fired <= row.size * 2)
                         {
                             n.Cells["fired"].Style.BackColor = Color.Red;
                             n.Cells["fired"].Style.ForeColor = Color.White;
                         }
                         else if (row.fired > row.size * 2)
                         {
                             n.Cells["fired"].Style.BackColor = Color.Purple;
                             n.Cells["fired"].Style.ForeColor = Color.White;
                         }
                         else
                         {
                             n.Cells["fired"].Style.BackColor = Color.White;
                             n.Cells["fired"].Style.ForeColor = Color.Black;
                         }
                     }
                 }
             }
             );
        }

        private object mLockObj = new object();
        private volatile Thread mCalFeedbackThread = null;
        private void AsyncShowBugFeedbacks()
        {
            if (mCalFeedbackThread != null)
                mCalFeedbackThread.Abort();
            else
            {
                lock (mLockObj)
                {
                    if (mCalFeedbackThread != null)
                        mCalFeedbackThread.Abort();
                }
            }

            mCalFeedbackThread = new Thread(() => CalFeedbak());
            mCalFeedbackThread.Start();

        }

        private object CalFeedbak()
        {
            (from BugInfoSet.BugInfoTableRow r in mBugInfoSet.BugInfoTable.Rows
             select r)
             .ToList()
             .ForEach(
                n =>
                {
                    int i = _query.CountFeedbacks(n.bugNum);
                    n.FeedBackCount = i;
                }
             );
            mBugInfoListDataGridView.RefreshEdit();


            return null;
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
                f.Init(bugNum);
                f.Text = BugInfoManagement_Resource.EditBugInfoFormName + " " + bugNum;
                f.Show();
            }
            else
            {
                MessageBox.Show(BugInfoManagement_Resource.Message4);
            }
        }

        private void ShowSummary(int count, decimal totalHours, decimal totalFired)
        {
            this.Text = "TeamView:" + BugInfoManagement_Resource.TotalRecord + " " + count.ToString() + "/estimated " + totalHours.ToString() + " hours" + "/fired " + totalFired.ToString() + " hours";
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
            mBugInfoListDataGridView.RefreshEdit();

            if (CurrentSelectedItem == null)
            {
                mFlowMenu.Items[0].Enabled = false;
                mFlowMenu.Items[1].Enabled = false;
                mFlowMenu.Items[2].Enabled = false;
                mFlowMenu.Items[3].Enabled = false;
                return;
            }

            var currentSelectedItem = CurrentSelectedItem;
            mFlowMenu.Items[0].Enabled = currentSelectedItem.bugStatus == States.Abort
                || currentSelectedItem.bugStatus == States.Pending;
            mFlowMenu.Items[1].Enabled = currentSelectedItem.bugStatus == States.Start;
            mFlowMenu.Items[2].Enabled = currentSelectedItem.bugStatus == States.Start;
            mFlowMenu.Items[3].Enabled = currentSelectedItem.bugStatus == States.Complete;
        }

        private void mBugInfoListDataGridView_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            mBugInfoListDataGridView.CurrentCell = mBugInfoListDataGridView[e.ColumnIndex, e.RowIndex];

        }

        private void mFlowMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Issue Handlers")
                return;

            var currentSelected = CurrentSelectedItem;
            var item = this._bugInfoModel.Load(currentSelected.bugNum);
            if (item == null)
                return;

            item.timeStamp = currentSelected.timeStamp;

            item.bugStatus = StatesConverter.ToStateString((StatesEnum)Enum.Parse(typeof(StatesEnum), e.ClickedItem.Text));

            string error = SaveFlow(item);
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error);
                return;
            }

            currentSelected.fired = Math.Round((double)item.fired / 60, 2);
            currentSelected.bugStatus = item.bugStatus;
            currentSelected.timeStamp = item.timeStamp;

            ShowColorStatus();

        }

        private string SaveFlow(Common.Entity.BugInfoEntity1 item)
        {
            var checkResult = _bugInfoModel.ChangeStatusCheck();
            if (!string.IsNullOrEmpty(checkResult))
            {
                return checkResult;
            }

            var result = _bugInfoModel.CommitStatus();

            using (TransactionScope trans = new TransactionScope())
            {
                _repository.UpdateItem(item);
                _repository.AddLog(item.bugNum, string.Empty, result.LogTypeId);
                trans.Complete();
            }

            return string.Empty;
        }

        private void mBugInfoListDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void mBugInfoListDataGridView_Sorted(object sender, EventArgs e)
        {
            ShowColorStatus();
        }

        private void mBugInfoListDataGridView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (_smartPlan.Checked)
            {
                e.SortResult = 0;
            }
        }

        private void _makePlan_Click(object sender, EventArgs e)
        {
            CommonForm<CurrentTaskListControl> form =
                new CommonForm<CurrentTaskListControl>(_currentTaskListControlFac(), n => n.Load("曹宗颖"));

            form.ShowDialog();
        }

    }
}
