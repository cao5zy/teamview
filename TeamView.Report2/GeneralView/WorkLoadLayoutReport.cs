using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Report2.GeneralView
{
    sealed class WorkLoadLayoutReport
    {
        public WorkLoadLayoutEntity[] _entities;

        public WorkLoadLayoutReport()
        {
            List<WorkLoadLayoutEntity> list = new List<WorkLoadLayoutEntity>();

            list.Add(new WorkLoadLayoutEntity { 
                PreviousRemainTime = GetPreviousRemainTime(),
                CurrentRoundAddedTime = GetCurrentRountAddedTime(),
                CurrentRoundUsedTime = GetCurrentRoundUsedTime(),
                PreviousRoundUsedTime = GetPreviousRoundUsedTime(),
                CurrentRoundEvalTime = GetCurrentRoundEvalTime(),
                PreviousRoundEvalTime = GetPreviousRoundEvalTime(),
            });
        }

        private TimeSpan GetPreviousRoundEvalTime()
        {
            throw new NotImplementedException();
        }

        private TimeSpan GetCurrentRoundEvalTime()
        {
            throw new NotImplementedException();
        }

        private TimeSpan GetPreviousRoundUsedTime()
        {
            throw new NotImplementedException();
        }

        private TimeSpan GetCurrentRoundUsedTime()
        {
            throw new NotImplementedException();
        }

        private TimeSpan GetCurrentRountAddedTime()
        {
            throw new NotImplementedException();
        }

        private TimeSpan GetPreviousRemainTime()
        {
            throw new NotImplementedException();
        }
    }
}
