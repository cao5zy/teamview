using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FxLib.Algorithms;

namespace TeamView
{
    partial class QueryControl : UserControl
    {
        public event EventHandler Query;

        private void OnQuery()
        {
            if (Query != null)
                Query(this, null);
        }
        public QueryControl()
        {
            InitializeComponent();
        }

        private QueryControlModel mModel;

        public QueryControlModel Model
        {
            get
            {
                return mModel;
            }
        }
        public QueryControl(QueryControlModel model)
            : this()
        {
            mModel = model;
        }

        public void Init()
        {
            mModel.AllProgrammers
                .SafeForEach(
                n => mProgrammerCheckList.Items.Add(n)
                );


            mProgrammerCheckList.SetItemChecked(
                new List<string>(mModel.AllProgrammers)
                .IndexOf(mModel.SelectedProgrammers.First()), true);

            mModel.BugStates.SafeForEach(n => 
                mSatesCheckList.Items.Add(n));

            mModel.PriorityNumbers.SafeForEach(n =>
                mPrioirtyCheckList.Items.Add(n.ToString()));

            mPrioirtyCheckList.SetItemChecked(
                0, true);
        }
        private void mQueryButton_Click(object sender, EventArgs e)
        {
            List<string> selectedProgrammers = new List<string>();

            mModel.SelectedProgrammers = (from string n in mProgrammerCheckList.CheckedItems
                                          select n).ToArray();

            mModel.SelectedPriorities = (from string n in mPrioirtyCheckList.CheckedItems
                                         select n)
                                         .ToList()
                                         .ConvertAll(n => Convert.ToInt32(n));

            mModel.Description = mDescriptionTextBox.Text;

            mModel.SelectedStates = (from string n in mSatesCheckList.CheckedItems
                                     select n).ToArray();
                                       

            mModel.BugNum = mBugNumTextBox.Text;

            if (!string.IsNullOrEmpty(mVersionTextBox.Text))
                mModel.Version = mVersionTextBox.Text;
            else
                mModel.Version = string.Empty;

            OnQuery();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
