﻿using Scheduler.SchedulerUnits;
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
                TimeSpan timeToWait;
                timeToWait = _calculatedNextRun - DateTime.Now;
                //set up timer and make it tick until time to wait is 0. 
                return true;
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

        internal DateTime CalculateTimeToRunInWeeks(int interval, DateTime now)
        {
            if (interval > 0)
            {
                int intervalInDays = interval * 7;
                DateTime calculatedTimeToRunInWeeks;
                calculatedTimeToRunInWeeks = now.AddDays(intervalInDays);
                return calculatedTimeToRunInWeeks;
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
                DateTime calculatedTimeToRunInDays;
                calculatedTimeToRunInDays = now.AddDays(interval);
                return calculatedTimeToRunInDays;
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
                DateTime calculatedTimeToRunInMinutes;
                calculatedTimeToRunInMinutes = now.AddMinutes(interval);
                return calculatedTimeToRunInMinutes;
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
                DateTime calculatedTimeToRunInSeconds;
                calculatedTimeToRunInSeconds = now.AddSeconds(interval);
                return calculatedTimeToRunInSeconds;
            }
            else
            {
                throw new ArgumentException("Interval cannot be 0!");
            }
        }
    }
}
