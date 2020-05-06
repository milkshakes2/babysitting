using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BabySitting.Tests
{
    [TestFixture]
    public class FamilyRateTests
    {
        [Test]
        public void SetHourlyRates_FlatRate_Hours17To4()
        {
            int pay20 = 20;
            List<int> onHours = new List<int>( new int[]{ 17, 18, 19, 20, 21, 22, 23, 0, 1, 2, 3, 4 });
            List<int> offHours = new List<int>( new int[]{ 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });

            FamilyRate testFamily = new FamilyRate();
            testFamily.SetHourlyRates(17, 4, pay20);

            foreach (int hour in onHours)
                if (testFamily.HourlyRates[hour] != pay20)
                    Assert.Fail();

            foreach (int hour in offHours)
                if (testFamily.HourlyRates[hour] != 0)
                    Assert.Fail();

            Assert.Pass();
        }

        [Test]
        public void SetHourlyRates_2Rates_17To22At20_23To4At15()
        {
            int pay20 = 20, pay15 = 15;
            List<int> pay20Hours = new List<int>(new int[] { 17, 18, 19, 20, 21, 22 });
            List<int> pay15Hours = new List<int>(new int[] { 23, 0, 1, 2, 3, 4 });
            List<int> offHours = new List<int>(new int[] { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });

            FamilyRate testFamily = new FamilyRate();
            testFamily.SetHourlyRates(17, 22, pay20);
            testFamily.SetHourlyRates(23, 4, pay15);

            foreach (int hour in pay20Hours)
                if (testFamily.HourlyRates[hour] != pay20)
                    Assert.Fail();

            foreach (int hour in pay15Hours)
                if (testFamily.HourlyRates[hour] != pay15)
                    Assert.Fail();

            foreach (int hour in offHours)
                if (testFamily.HourlyRates[hour] != 0)
                    Assert.Fail();

            Assert.Pass();
        }

        [Test]
        public void SetHourlyRates_Hours0To24_InvalidInput_ThrowError()
        {
            FamilyRate testFamily = new FamilyRate();
            try
            {
                testFamily.SetHourlyRates(0, 24, 20);
                Assert.Fail("An exception should have been thrown.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Pass();
            }
            catch (Exception)
            {
                Assert.Fail("An exception of type 'ArgumentOutOfRangeException' was expected.");
            }
        }
    }
}
