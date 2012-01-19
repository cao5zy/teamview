﻿using System;
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

namespace TeamView
{
    partial class MainForm : Form
    {
        public IDealMen DealMen { get; set; }
        public IBugStates BugStates { get; set; }
        public IBugInfoManagement BugInfoManagement { get; set; }
        private EditBugInfoManager.Factiory EditBugInfoManagerFactory { get; set; }
        private CreateBugInfoManager.Factory CreateBugInfoManagerFactory { get; set; }
        private BugInfoForm.Factory CreateBugInfoForm { get; set; }
        private QueryControl mQueryControl;
        private AddNewForm.Factory _addFormFactory;
        public MainForm(
            BugInfoForm.Factory createBugInfoForm,
            EditBugInfoManager.Factiory createEditBugInfoManager,
            CreateBugInfoManager.Factory createCreateBugInfoManager, 
            QueryControl queryControl,
            AddNewForm.Factory addFormFactory)
        {
            InitializeComponent();
            CreateBugInfoForm = createBugInfoForm;
            EditBugInfoManagerFactory = createEditBugInfoManager;
            CreateBugInfoManagerFactory = createCreateBugInfoManager;
            _addFormFactory = addFormFactory;
           
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
            var results = BugInfoManagement.QueryByParameter(
                model.SelectedProgrammers,
                model.BugNum,
                model.Version,
                model.Description,
                model.Priority,
                model.SelectedState
                );

            mBugInfoSet.BugInfoTable.Clear();
            results.SafeForEach(
                n => {
                    var row = mBugInfoSet.BugInfoTable.NewBugInfoTableRow();
                    row.bugNum = n.BugNum;
                    row.bugStatus = n.BugStatus;
                    row.dealMan = n.DealMan;
                    row.description = n.Description;
                    row.Version = n.Version;
                    row.size = n.Size;
                    row.Priority = n.Priority;
                    row.fired = Math.Round((double)n.TimeConsumptionInMins / 60, 2);
                    mBugInfoSet.BugInfoTable.Rows.Add(row);
                }
                );

            ShowSummary(results.Count, results.Sum(n => n.Size), results.Sum(n => n.TimeConsumptionInMins / 60));
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

        //删除按钮事件处理
        private void mDeleteButton_Click(object sender, EventArgs e)
        {
            if (this.mBugInfoListDataGridView.CurrentRow != null)
            {
                if (MessageBox.Show(BugInfoManagement_Resource.Message5, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BugInfoManagement.DeleteByBugNum(mBugInfoListDataGridView.CurrentRow.Cells[1].Value.ToString());
                    LoadBugInfos();
                    MessageBox.Show(BugInfoManagement_Resource.Message6, BugInfoManagement_Resource.Message7, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(BugInfoManagement_Resource.Message8);
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
            var editBugInfoManager = EditBugInfoManagerFactory();
            editBugInfoManager.Initialize(CurrentSelectedItem.bugNum);
            editBugInfoManager.MoveState((StatesEnum)Enum.Parse(typeof(StatesEnum), e.ClickedItem.Text));
            LoadBugInfos();
        }

    }
}
