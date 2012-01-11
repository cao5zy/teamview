using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamView.Common.Entity;
using TeamView.Common;

namespace TeamView.Common.Logs
{
    public class PointsLogReader
    {
        public List<ProgrammerPoint> GetPointList(string bugNum)
        {
            return null;
            //return new DAL.PointslogCollection()
            //    .Where("bugnum", bugNum)
            //    .Load()
            //    .Select(n => {
            //        var p = PointsParser.ToPoint(n.Log);
            //        p.EstimatedTime = n.Createdtime;
            //        return p;
            //    })
            //    .ToList();
        }
    }
}
