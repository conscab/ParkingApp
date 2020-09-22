using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayParkingNS;
using System;

namespace PayParkingUnitTests
{
    [TestClass]
    public class PayParkingUnitTests
    {

        [TestMethod]
        public void DisplaySpacesTest()
        {
            PayParking pp = new PayParking();
            string expectedtext = "Current parking status:\n |1|  |2|  |3|  |4|  |5|  |6|  |7|  |8|  |9|  |10| ";

            string result = pp.DisplaySpaces();

            Assert.AreEqual(expectedtext, result);
        }

        [TestMethod]
        public void CheckInTest()
        {

        }

        [TestMethod]
        public void CheckOutTest()
        {

        }

        [TestMethod]
        public void CheckRandomStringLengthTest()
        {
            string licencePlate = PayParking.RandomString();
            Assert.AreEqual(licencePlate.Length, 7);
        }

        [TestMethod]
        public void CheckScanTest()
        {
            PayParking pp = new PayParking();
            string licencePlateText = pp.Scan();
            string expectedTextFormat = "Licence plate " + licencePlateText + " registered.";
            Assert.AreEqual(expectedTextFormat.Length, 33);
        }

        [TestMethod]
        public void CheckIfAvailableTest()
        {
            PayParking pp = new PayParking();
            bool check = pp.CheckIfAvailable("1");
            Assert.AreEqual(check, true);
        }

        [TestMethod]
        public void CheckIfAvailableNotTrueTest()
        {
            PayParking pp = new PayParking();
            bool check = pp.CheckIfAvailable("12");
            Assert.AreEqual(check, false);
        }

    }
}
