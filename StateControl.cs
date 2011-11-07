using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugInfoManagement.Common;

namespace BugInfoManagement
{
    public partial class StateControl : UserControl
    {
        public StateControl()
        {
            InitializeComponent();
            mStartButton.Text = BugInfoManagement_Resource.mStartButton;
            mAbortButton.Text = BugInfoManagement_Resource.mAbortButton;
            mCompleteButton.Text = BugInfoManagement_Resource.mCompleteButton;
        }

        private StatesEnum mCurrentState;
        public StatesEnum CurrentState
        {
            get
            {
                return mCurrentState;
            }
            set
            {
                mCurrentState = value;
                SetState(value);
            }
        }

        private void SetState(StatesEnum state)
        {
            mStartButton.Enabled = state == StatesEnum.Abort || state == StatesEnum.Complete || state == StatesEnum.Pending;
            mAbortButton.Enabled = state == StatesEnum.Start;
            mCompleteButton.Enabled = state == StatesEnum.Start;
        }

        public event EventHandler<StateChangedArgs> StateChanged;

        private void OnStateChanged(StatesEnum oldState, StatesEnum newState)
        {
            if (StateChanged != null)
                StateChanged(this, new StateChangedArgs(oldState, newState));
        }

        public class StateChangedArgs : EventArgs
        {
            private StatesEnum mOldState;
            private StatesEnum mNewState;
            public StateChangedArgs(StatesEnum oldState, StatesEnum newState)
            {
                mOldState = oldState;
                mNewState = newState;
            }

            public StatesEnum NewState
            {
                get
                {
                    return mNewState;
                }
            }

            public StatesEnum OldState
            {
                get
                {
                    return mOldState;
                }
            }
        }

        private void mStartButton_Click(object sender, EventArgs e)
        {
            OnStateChanged(CurrentState, StatesEnum.Start);
            CurrentState = StatesEnum.Start;
        }

        private void mAbortButton_Click(object sender, EventArgs e)
        {
            OnStateChanged(CurrentState, StatesEnum.Abort);
            CurrentState = StatesEnum.Abort;
        }

        private void mCompleteButton_Click(object sender, EventArgs e)
        {
            OnStateChanged(CurrentState, StatesEnum.Complete);
            CurrentState = StatesEnum.Complete;
        }


    }
}
