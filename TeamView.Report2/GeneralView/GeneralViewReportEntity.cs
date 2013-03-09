using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TeamView.Report2.GeneralView
{
    public sealed class GeneralViewReportEntity
    {
        public string Programmer { get; set; }
        public string BugNum { get; set; }
        public string Description { get; set; }
        public int _sizeInMins;
        public int _burnedMins;
        private readonly double[] _calList = new double[] { 1, 0.6, 0.2, 0.05 };
        public string SizeInHours
        {
            get
            {
                return Math.Round((decimal)_sizeInMins / 60, 2).ToString();
            }
        }
        public string BurnedHours
        {
            get
            {
                return Math.Round((decimal)_burnedMins / 60, 2).ToString();
            }
        }

        public double Points { get; set; }
        public double FixedPoint { get; set; }
        public double ResultPoint { get; set; }
        
        public void Cal()
        {
            if (FixedPoint != 0)
            {
                ResultPoint = FixedPoint;
                return;
            }
            else
                ResultPoint = 0;

            int len = _calList.Length;
            Trace.Assert(len > 1);

            double remainingBurnedHours = CellHours((double)_burnedMins / 60);
            double sizeInHours = _sizeInMins / 60;
            bool completed = false;
            for (int i = 0; i < len - 1; i++)
            {
                double temp = sizeInHours - remainingBurnedHours;
                if (temp > 0)
                {
                    ResultPoint += remainingBurnedHours * Points * _calList[i];
                    completed = true;
                    break;
                }
                else
                {
                    ResultPoint += sizeInHours * Points * _calList[i];
                    remainingBurnedHours = Math.Abs(temp);
                }
            }

            if (!completed)
            {
                ResultPoint += remainingBurnedHours * Points * _calList[len - 1];
            }
        }

        private static double CellHours(double hourValue)
        {
            if (hourValue <= 0.5)
                return 0.5;
            else
                return hourValue;
        }

        public int CurrentBurnedMins { get; set; }
    }
}
