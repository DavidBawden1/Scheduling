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
    }
}
