using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FxLib.Algorithms;

namespace TeamView
{
    class QueryControlModel
    {
        private IBugStates mBugStates;
        private IDealMen mDealMen;
        private List<string> mSelectedProgrammers = new List<string>();

        public QueryControlModel(
            IBugStates bugStates,
            IDealMen dealMen)
        {
            mBugStates = bugStates;
            mDealMen = dealMen;
        }
        public IEnumerable<string> AllProgrammers
        {
            get
            {
                return mDealMen.DealMen.ConvertAll(n => n.Name);
            }
        }

        public IEnumerable<string> SelectedProgrammers
        {
            get
            {
                return mSelectedProgrammers;
            }
            set
            {
                mSelectedProgrammers.Clear();
                if (value.SafeCount() != 0)
                    mSelectedProgrammers.AddRange(value);
            }
        }

        public IEnumerable<string> BugStates
        {
            get
            {
                return mBugStates.States.SafeConvertAll(n => n.StateInfo);
            }
        }

        private int ? mPrioirty = 1;
        public string SelectedState { get; set; }

        public string BugNum { get; set; }

        public string Description { get; set; }

        public string Version { get; set; }

        public int? Priority
        {
            get
            { return mPrioirty; }
            set
            {
                mPrioirty = value;
            }
        }

    }
}
