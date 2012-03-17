using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TeamView.Common;

namespace TeamView
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
            mStartButton.Enabled = state == StatesEnum.Suspend || state == StatesEnum.Complete || state == StatesEnum.Pending;
            mAbortButton.Enabled = state == StatesEnum.Start;
            mCompleteButton.Enabled = state == StatesEnum.Start;
        }

        public event EventHandler<StateChangedArgs> StateChanged;

        private bool OnStateChanged(StatesEnum oldState, StatesEnum newState)
        {
            if (StateChanged != null)
            {
                var arg = new StateChangedArgs(oldState, newState);
                StateChanged(this, arg);

                if (arg.Canceled)
                    return false;
            }
            return true;

            
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

            public bool Canceled
            {
                get;
                set;
            }
        }

        private void mStartButton_Click(object sender, EventArgs e)
        {
            if(OnStateChanged(CurrentState, StatesEnum.Start))
                CurrentState = StatesEnum.Start;
        }

        private void mAbortButton_Click(object sender, EventArgs e)
        {
            if(OnStateChanged(CurrentState, StatesEnum.Suspend))
                CurrentState = StatesEnum.Suspend;
        }

        private void mCompleteButton_Click(object sender, EventArgs e)
        {
            if(OnStateChanged(CurrentState, StatesEnum.Complete))
                CurrentState = StatesEnum.Complete;
        }


    }
}
