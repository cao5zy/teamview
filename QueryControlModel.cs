using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FxLib.Algorithms;
using TeamView.Abstracts;

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
            mSelectedProgrammers.Add(mDealMen.CurrentLogin);
            SelectedPriorities = new List<int> { 
                0
            };
        }
        public IEnumerable<string> AllProgrammers
        {
            get
            {
                return mDealMen.DealMen.ConvertAll(n => n.Name);
            }
        }

        public IEnumerable<int> PriorityNumbers
        {
            get
            {
                return new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
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

        public IEnumerable<string> SelectedStates { get; set; }

        public IEnumerable<int> SelectedPriorities { get; set; }

        public string BugNum { get; set; }

        public string Description { get; set; }

        public string Version { get; set; }


    }
}
