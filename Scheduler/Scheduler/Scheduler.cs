using Scheduler.SchedulerUnits;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

[assembly: InternalsVisibleTo("SchedulerUnitTests")]
namespace Scheduler
{
    public class Scheduler
    {
        private DateTime _calculatedNextRun;
        private UnitsOfTime _unitOfTime; 
        private int _interval;

        public Scheduler()
        {

        }

        public bool IsTimeToRun()
        {
            _calculatedNextRun = CalculateTimeToRun(_interval, _unitOfTime);
            if (DateTime.Now < _calculatedNextRun)
            {
                TimeSpan timeToWait = DateTime.Now - _calculatedNextRun;
                int timeToSleep = timeToWait.Milliseconds;
                while(DateTime.Now < _calculatedNextRun)
                {
                    Thread.Sleep(timeToSleep - 1000);
                    return true ? DateTime.Now == _calculatedNextRun : false;
                }
                _calculatedNextRun = CalculateTimeToRun(_interval, _unitOfTime);
                return false;
            }
            else
            {
                _calculatedNextRun = CalculateTimeToRun(_interval, _unitOfTime);
                return false;
            }
        }

        internal DateTime CalculateTimeToRun(int interval, UnitsOfTime unitOfTime)
        {
            DateTime calculatedDateTime; 
            switch(_unitOfTime)
            {
                case UnitsOfTime.Seconds:
                    calculatedDateTime = CalculateTimeToRunInSeconds(interval, DateTime.Now);
                    break;
                case UnitsOfTime.Minutes:
                    calculatedDateTime = CalculateTimeToRunInMinutes(interval, DateTime.Now);
                    break;
                case UnitsOfTime.Hours:
                    calculatedDateTime = CalculateTimeToRunInHours(interval, DateTime.Now);
                    break;
                case UnitsOfTime.Days:
                    calculatedDateTime = CalculateTimeToRunInDays(interval, DateTime.Now);
                    break;
                case UnitsOfTime.Weeks:
                    calculatedDateTime = CalculateTimeToRunInWeeks(interval, DateTime.Now);
                    break;
                case UnitsOfTime.Months:
                    calculatedDateTime = CalculateTimeToRunInMonths(interval, DateTime.Now);
                    break;
                case UnitsOfTime.Years:
                    calculatedDateTime = CalculateTimeToRunInYears(interval, DateTime.Now);
                    break;
                default:
                    throw new ArgumentException("The supplied unit of time was not valid!");
            }
            return calculatedDateTime;
        }

        internal DateTime CalculateTimeToRunInYears(int interval, DateTime now)
        {
            if (interval > 0)
            {
                DateTime fromDate = now;
                DateTime toDate = now.AddYears(interval);
                int daysInMonth = DateTime.DaysInMonth(toDate.Year, toDate.Month);
                int day = Math.Min(fromDate.Day, daysInMonth);
                return toDate = new DateTime(toDate.Year, toDate.Month, day, toDate.Hour, toDate.Minute, toDate.Second);
            }
            else
            {
                throw new ArgumentException("Interval cannot be 0!");
            }
        }

        internal DateTime CalculateTimeToRunInMonths(int interval, DateTime now)
        {
            if (interval > 0)
            {
                DateTime fromDate = now;
                DateTime toDate = now.AddMonths(interval);
                int daysInMonth = DateTime.DaysInMonth(toDate.Year, toDate.Month);
                int day = Math.Min(fromDate.Day, daysInMonth);
                return toDate = new DateTime(toDate.Year, toDate.Month, day, toDate.Hour, toDate.Minute, toDate.Second);
            }
            else
            {
                throw new ArgumentException("Interval cannot be 0!");
            }
        }

        internal DateTime CalculateTimeToRunInWeeks(int interval, DateTime now)
        {
            if (interval > 0)
            {
                int intervalInDays = interval * 7;
                return now.AddDays(intervalInDays);
            }
            else
            {
                throw new ArgumentException("Interval cannot be 0!");
            }
        }

        internal DateTime CalculateTimeToRunInDays(int interval, DateTime now)
        {
            if (interval > 0)
            {
                return now.AddDays(interval);
            }
            else
            {
                throw new ArgumentException("Interval cannot be 0!");
            }
        }

        internal DateTime CalculateTimeToRunInHours(int interval, DateTime now)
        {
            if (interval > 0)
            {
                DateTime calculatedTimeToRunInHours;
                calculatedTimeToRunInHours = now.AddHours(interval);
                return calculatedTimeToRunInHours;
            }
            else
            {
                throw new ArgumentException("Interval cannot be 0!");
            }
        }

        internal DateTime CalculateTimeToRunInMinutes(int interval, DateTime now)
        {
            if (interval > 0)
            {
                return now.AddMinutes(interval);
            }
            else
            {
                throw new ArgumentException("Interval cannot be 0!");
            }
        }

        /// <summary>
        /// Returns a scheduled DateTime calculated by second intervals. 
        /// Defaults to Local time unless UTC is specified. 
        /// </summary>
        /// <param name="interval">Interval in seconds</param>
        /// <param name="dateTimeLocalisation">The localisation of the DateTime. i.e. UTC or Local.</param>
        /// <returns></returns>
        internal DateTime CalculateTimeToRunInSeconds(int interval, DateTime now)
        {
            if(interval > 0)
            {
                return now.AddSeconds(interval);
            }
            else
            {
                throw new ArgumentException("Interval cannot be 0!");
            }
        }
    }
}
