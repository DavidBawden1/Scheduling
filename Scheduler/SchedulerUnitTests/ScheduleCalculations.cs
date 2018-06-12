using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SchedulerUnitTests
{
    [TestClass]
    public class ScheduleCalculations
    {
        [TestMethod]
        public void CalculateTimeToRunInSeconds()
        {
            //arrange 
            Scheduler.Scheduler scheduler = new Scheduler.Scheduler();
            DateTime currentDateTime = new DateTime(2018, 06, 11, 21, 30, 00);
            DateTime expectedDateTime = new DateTime(2018, 06, 11, 21, 30, 30);
            int interval = 30; 

            //act
            var actualDateTime = scheduler.CalculateTimeToRunInSeconds(interval, currentDateTime);

            //assert
            Assert.AreEqual(expectedDateTime, actualDateTime);
        }

        [TestMethod]
        public void CalculateTimeToRunInMinutes()
        {
            //arrange 
            Scheduler.Scheduler scheduler = new Scheduler.Scheduler();
            DateTime currentDateTime = new DateTime(2018, 06, 11, 21, 30, 00);
            DateTime expectedDateTime = new DateTime(2018, 06, 11, 21, 31, 00);
            int interval = 1;

            //act
            var actualDateTime = scheduler.CalculateTimeToRunInMinutes(interval, currentDateTime);

            //assert
            Assert.AreEqual(expectedDateTime, actualDateTime);
        }

        [TestMethod]
        public void CalculateTimeToRunInHours()
        {
            //arrange 
            Scheduler.Scheduler scheduler = new Scheduler.Scheduler();
            DateTime currentDateTime = new DateTime(2018, 06, 11, 21, 30, 00);
            DateTime expectedDateTime = new DateTime(2018, 06, 11, 22, 30, 00);
            int interval = 1;

            //act
            var actualDateTime = scheduler.CalculateTimeToRunInHours(interval, currentDateTime);

            //assert
            Assert.AreEqual(expectedDateTime, actualDateTime);
        }

        [TestMethod]
        public void CalculateTimeToRunInDays()
        {
            //arrange 
            Scheduler.Scheduler scheduler = new Scheduler.Scheduler();
            DateTime currentDateTime = new DateTime(2018, 06, 11, 21, 30, 00);
            DateTime expectedDateTime = new DateTime(2018, 06, 12, 21, 30, 00);
            int interval = 1;

            //act
            var actualDateTime = scheduler.CalculateTimeToRunInDays(interval, currentDateTime);

            //assert
            Assert.AreEqual(expectedDateTime, actualDateTime);
        }

        [TestMethod]
        public void CalculateTimeToRunWeeks()
        {
            //arrange 
            Scheduler.Scheduler scheduler = new Scheduler.Scheduler();
            DateTime currentDateTime = new DateTime(2018, 06, 11, 21, 30, 00);
            DateTime expectedDateTime = new DateTime(2018, 06, 18, 21, 30, 00);
            int interval = 1;

            //act
            var actualDateTime = scheduler.CalculateTimeToRunInWeeks(interval, currentDateTime);

            //assert
            Assert.AreEqual(expectedDateTime, actualDateTime);
        }
    }
}
