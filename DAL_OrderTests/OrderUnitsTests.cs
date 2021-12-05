using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coursework_DAL_;
using System;
using System.Globalization;

namespace DAL_OrderTests
{
    [TestClass]
    public class OrderUnitsTests
    {
        [TestMethod]
        public void HowManyDaysUnitTests()
        {
            //Arrange
            DateTime dateIn, dateOut;
            DateTime.TryParseExact("01/01/2022", "dd/MM/yyyy", null, DateTimeStyles.None, out dateIn);
            DateTime.TryParseExact("05/01/2022", "dd/MM/yyyy", null, DateTimeStyles.None, out dateOut);
            int expected = 4;
            //Act
            DALOrder order = new DALOrder(null, null, null, dateIn, dateOut, false, "none");
            //Assert
            int actual = order.HowManyDays;
            Assert.AreEqual(expected, actual, "Days doesnt right");
        }
    }
}
