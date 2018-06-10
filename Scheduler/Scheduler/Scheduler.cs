using Scheduler.SchedulerUnits;
using System;

namespace Scheduler
{
    public class Scheduler
    {
        private DateTime _calculatedNextRun;
        public DateTime CalculatedNextRun
        {
            get
            {
                return _calculatedNextRun;
            }
        }
        private UnitsOfTime _unitOfTime; 
        public UnitsOfTime UnitOfTime
        {
            get
            {
                return _unitOfTime;
            }
        }
        private int _interval;
        public int Interval
        {
            get
            {
                return _interval;
            }
        }

        public DateTimeKind DateTimeLocalisation { get; set; }
        public Scheduler()
        {
            DateTimeLocalisation = DateTimeKind.Local;
        }

        public bool IsTimeToRun()
        {
            _calculatedNextRun = CalculateTimeToRun(Interval, UnitOfTime, DateTimeLocalisation);
            if(CalculatedNextRun < DateTime.Now)
            {
                do
                {
                    return true;
                }
                while (CalculateTimeToRun(Interval, UnitOfTime, DateTimeLocalisation) == DateTime.Now);
            }
            else
            {
                return false;
            }
        }

        private DateTime CalculateTimeToRun(int interval, UnitsOfTime unitOfTime, DateTimeKind dateTimeLocalisation)
        {
            DateTime calculatedDateTime; 
            switch(UnitOfTime)
            {
                case UnitsOfTime.Seconds:
                    calculatedDateTime = DateTime.Now;
                    break;
                case UnitsOfTime.Minutes:
                    calculatedDateTime = DateTime.Now;
                    break;
                case UnitsOfTime.Hours:
                    calculatedDateTime = DateTime.Now;
                    break;
                case UnitsOfTime.Days:
                    calculatedDateTime = DateTime.Now;
                    break;
                case UnitsOfTime.Weeks:
                    calculatedDateTime = DateTime.Now;
                    break;
                case UnitsOfTime.Months:
                    calculatedDateTime = DateTime.Now;
                    break;
                case UnitsOfTime.Years:
                    calculatedDateTime = DateTime.Now;
                    break;
                default:
                    throw new ArgumentException("The supplied unit of time was not valid!");
            }
            return calculatedDateTime;
        }
    }
}
