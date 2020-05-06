using NUnit.Framework;

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
    }
}
