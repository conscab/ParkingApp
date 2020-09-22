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
            string displayText_01 = "Current parking status:";

            string displayText_02 = string.Join("\r\n", pp.DisplaySpaces());

            Assert.AreEqual(displayText_01, displayText_02);
        }

        [TestMethod]
        public void CheckInTest()
        {

        }

        [TestMethod]
        public void CheckOutTest()
        {

        }
    }
}
