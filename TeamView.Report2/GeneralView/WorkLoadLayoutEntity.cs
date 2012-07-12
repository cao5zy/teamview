using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Report2.GeneralView
{
    sealed class WorkLoadLayoutEntity
    {
        public TimeSpan PreviousRemainTime { get; set; }
        public TimeSpan CurrentRoundAddedTime { get; set; }
        public TimeSpan CurrentRoundUsedTime { get; set; }
        public TimeSpan PreviousRoundUsedTime { get; set; }
        public TimeSpan CurrentRoundEvalTime { get; set; }
        public TimeSpan PreviousRoundEvalTime { get; set; }
    }
}
