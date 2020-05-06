using NUnit.Framework;
using System;

namespace BabySitting.Tests
{
    [TestFixture]
    public class ShiftTests
    {
        [Test]
        public void CalculatePay_FlatRate_FullShift_Hours17To4()
        {
            int pay20 = 20;
            FamilyRate testFamily = new FamilyRate();
            testFamily.SetHourlyRates(17, 4, pay20);

            Shift shift = new Shift(17, 4);
            int pay = shift.CalculatePay(17, 4, testFamily);

            Assert.AreEqual(pay, 240);
        }

        [Test]
        public void CalculatePay_2Rates_17To22At20_23To4At15_FullShift_Hours17To4()
        {
            int pay20 = 20, pay15 = 15;
            FamilyRate testFamily = new FamilyRate();
            testFamily.SetHourlyRates(17, 22, pay20);
            testFamily.SetHourlyRates(23, 4, pay15);

            Shift shift = new Shift(17, 4);
            int pay = shift.CalculatePay(17, 4, testFamily);

            Assert.AreEqual(pay, 210);
        }

        [Test]
        public void CalculatePay_1HourShift_1HourWorked()
        {
            int pay20 = 20;
            FamilyRate testFamily = new FamilyRate();
            testFamily.SetHourlyRates(17, 17, pay20);

            Shift shift = new Shift(17, 17);
            int pay = shift.CalculatePay(17, 17, testFamily);

            Assert.AreEqual(pay, pay20);
        }

        [Test]
        public void CalculatePay_InvalidInput_16To17_FullShift_Hours17To4()
        {
            int pay20 = 20;
            FamilyRate testFamily = new FamilyRate();
            testFamily.SetHourlyRates(17, 22, pay20);

            Shift shift = new Shift(17, 4);
            try {
                shift.CalculatePay(16, 17, testFamily);
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
