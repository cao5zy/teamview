using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TeamView.Report2.GeneralView
{
    sealed class ReportEntity
    {
        public string Programmer { get; set; }
        public string BugNum { get; set; }
        public string Description { get; set; }
        public int _sizeInMins;
        public int _burnedMins;
        private readonly double[] _calList = new double[] { 1, 0.7, 0.5, 0.2, 0.1 };
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

        public int Points { get; set; }
        public double ResultPoint { get; set; }

        public void Cal()
        {
            int len = _calList.Length;
            Trace.Assert(len > 1);

            int remainingBurnedMins = _burnedMins;
            bool completed = false;
            for (int i = 0; i < len - 1; i++)
            {
                int temp = _sizeInMins * i - remainingBurnedMins;
                if (temp > 0)
                {
                    ResultPoint += remainingBurnedMins * Points * _calList[i];
                    completed = true;
                    break;
                }
                else
                {
                    ResultPoint += _sizeInMins * Points * _calList[i];
                    remainingBurnedMins = Math.Abs(temp);
                }
            }

            if (!completed)
            {
                ResultPoint += remainingBurnedMins * Points * _calList[len - 1];
            }

            ResultPoint = ResultPoint / 100;
        }
    }
}
