using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamView.Common
{
    public static class StatesConverter
    {
        public static StatesEnum ToStateEnum(string status)
        {
            switch (status)
            {
                case States.Complete:
                    return StatesEnum.Complete;
                case States.Abort:
                    return StatesEnum.Abort;
                case States.Pending:
                    return StatesEnum.Pending;
                case States.Start:
                    return StatesEnum.Start;
                default:
                    throw new FormatException("invalid status " + status);
            }
        }

        public static string ToStateString(StatesEnum status)
        {
            switch (status)
            {
                case StatesEnum.Abort:
                    return States.Abort;
                case StatesEnum.Complete:
                    return States.Complete;
                case StatesEnum.Pending:
                    return States.Pending;
                case StatesEnum.Start:
                    return States.Start;
                default:
                    throw new FormatException("Invalid status enum " + ((int)status).ToString());
            }
        }
    }
}
