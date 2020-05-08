using NUnit.Framework;
using System;

namespace BabySitting.Tests
{
    [TestFixture]
    public class ShiftTests
    {
        int pay20 = 20, pay15 = 15;

        [Test]
        public void CalculatePay_FlatRate_FullShift_Hours17To3()
        {
            FamilyRate testFamily = new FamilyRate();
            testFamily.SetHourlyRates(17, 3, pay20);

            Shift shift = new Shift(17, 3);
            int pay = shift.CalculatePay(17, 3, testFamily);

            Assert.AreEqual(pay, 220);
        }

        [Test]
        public void CalculatePay_2Rates_17To22At20_23To4At15_FullShift_Hours17To3()
        {
            FamilyRate testFamily = new FamilyRate();
            testFamily.SetHourlyRates(17, 22, pay20);
            testFamily.SetHourlyRates(23, 3, pay15);

            Shift shift = new Shift(17, 3);
            int pay = shift.CalculatePay(17, 3, testFamily);

            Assert.AreEqual(pay, 195);
        }

        [Test]
        public void CalculatePay_1HourShift_1HourWorked()
        {
            FamilyRate testFamily = new FamilyRate();
            testFamily.SetHourlyRates(17, 17, pay20);

            Shift shift = new Shift(17, 17);
            int pay = shift.CalculatePay(17, testFamily);

            Assert.AreEqual(pay, pay20);
        }

        [Test]
        public void CalculatePay_InvalidInput_16To17_FullShift_Hours17To3()
        {
            FamilyRate testFamily = new FamilyRate();
            testFamily.SetHourlyRates(17, 22, pay20);

            Shift shift = new Shift(17, 3);
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

        [Test]
        public void CalculatePay_StartEnd_VS_1Hour_ConfirmSameResults()
        {
            FamilyRate testFamily = new FamilyRate();
            testFamily.SetHourlyRates(17, 3, pay20);

            Shift shift = new Shift(17, 3);

            int startStopPay = shift.CalculatePay(17, 17, testFamily);
            int oneHourPay = shift.CalculatePay(17, testFamily);

            Assert.AreEqual(startStopPay, oneHourPay);
        }

        [Test]
        public void CalculatePay_StartEnd_VS_FullShift_ConfirmSameResults()
        {
            FamilyRate testFamily = new FamilyRate();
            testFamily.SetHourlyRates(17, 3, pay20);

            Shift shift = new Shift(17, 3);

            int startStopPay = shift.CalculatePay(17, 3, testFamily);
            int fullshiftPay = shift.CalculatePay(testFamily);

            Assert.AreEqual(startStopPay, fullshiftPay);
        }
    }
}
