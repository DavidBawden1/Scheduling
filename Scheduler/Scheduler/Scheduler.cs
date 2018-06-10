using Scheduler.SchedulerUnits;
using System;

namespace Scheduler
{
    public class Scheduler
    {
        private DateTime _calculatedNextRun;
        private UnitsOfTime _unitOfTime; 
        private int _interval;

        private DateTimeKind _dateTimeLocalisation { get; set; }
        public Scheduler()
        {
            _dateTimeLocalisation = DateTimeKind.Local;
        }

        public bool IsTimeToRun()
        {
            _calculatedNextRun = CalculateTimeToRun(_interval, _unitOfTime, _dateTimeLocalisation);
            if(_calculatedNextRun < DateTime.Now)
            {
                do
                {
                    return true;
                }
                while (_calculatedNextRun == DateTime.Now);
            }
            else
            {
                return false;
            }
        }

        private DateTime CalculateTimeToRun(int interval, UnitsOfTime unitOfTime, DateTimeKind dateTimeLocalisation)
        {
            DateTime calculatedDateTime; 
            switch(_unitOfTime)
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
