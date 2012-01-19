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


            //mProgrammerCheckList.SetItemChecked(new List<string>(mModel.AllProgrammers).IndexOf(mModel.SelectedProgrammers.First()), true);

            mModel.BugStates.SafeForEach(n =>
                mBugStatesComboBox.Items.Add(n));

            mPriorityCombo.Text = Model.Priority.HasValue ? Model.Priority.Value.ToString() : string.Empty;
        }
        private void mQueryButton_Click(object sender, EventArgs e)
        {
            List<string> selectedProgrammers = new List<string>();
            foreach (var n in mProgrammerCheckList.CheckedItems)
            {
                selectedProgrammers.Add(n.ToString());
            }

            mModel.SelectedProgrammers = selectedProgrammers;

            if (!string.IsNullOrEmpty(mPriorityCombo.Text))
                mModel.Priority = int.Parse(mPriorityCombo.Text);
            else
                mModel.Priority = null;

            mModel.Description = mDescriptionTextBox.Text;

            mModel.SelectedState = mBugStatesComboBox.Text;

            mModel.BugNum = mBugNumTextBox.Text;

            if (!string.IsNullOrEmpty(mVersionTextBox.Text))
                mModel.Version = mVersionTextBox.Text;
            else
                mModel.Version = string.Empty;

            OnQuery();
        }
    }
}
