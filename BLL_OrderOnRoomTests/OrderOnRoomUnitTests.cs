using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coursework_BLL_;
using System.Collections.Generic;
using System.Globalization;
using System;

namespace BLL_OrderOnRoomTests
{
    [TestClass]
    public class OrderOnRoomUnitTests
    {
        [TestMethod]
        public void AddInfoUnitTests()
        {
            //Arrange
            Client client = new Client("Serhii", "Hryniuk", "+380931214766");
            Hotel hotel = new Hotel("VOLYN", 3, 150);
            List<int> roomsNumber = new List<int>();
            roomsNumber.Add(1);
            roomsNumber.Add(2);
            roomsNumber.Add(3);
            DateTime dateIn, dateOut;
            DateTime.TryParseExact("01/01/2022", "dd/MM/yyyy", null, DateTimeStyles.None, out dateIn);
            DateTime.TryParseExact("05/01/2022", "dd/MM/yyyy", null, DateTimeStyles.None, out dateOut);
            bool breakfast = true;
            string addInfo = "none";

            string expected = "none";
            //Act
            OrderOnRoom order = new OrderOnRoom(client, hotel, roomsNumber, dateIn, dateOut, breakfast, addInfo);
            //Assert
            string actual = order.AddInfo;
            Assert.AreEqual(expected, actual, "Additional info doesnt right");
        }
        [TestMethod]
        public void BreakfastUnitTests()
        {
            //Arrange
            Client client = new Client("Serhii", "Hryniuk", "+380931214766");
            Hotel hotel = new Hotel("VOLYN", 3, 150);
            List<int> roomsNumber = new List<int>();
            roomsNumber.Add(1);
            roomsNumber.Add(2);
            roomsNumber.Add(3);
            DateTime dateIn, dateOut;
            DateTime.TryParseExact("01/01/2022", "dd/MM/yyyy", null, DateTimeStyles.None, out dateIn);
            DateTime.TryParseExact("05/01/2022", "dd/MM/yyyy", null, DateTimeStyles.None, out dateOut);
            bool breakfast = true;
            string addInfo = "none";

            bool expected = true;
            //Act
            OrderOnRoom order = new OrderOnRoom(client, hotel, roomsNumber, dateIn, dateOut, breakfast, addInfo);
            //Assert
            bool actual = order.Breakfast;
            Assert.AreEqual(expected, actual, "Breakfast doesnt right");
        }
        [TestMethod]
        public void DateOutUnitTests()
        {
            //Arrange
            Client client = new Client("Serhii", "Hryniuk", "+380931214766");
            Hotel hotel = new Hotel("VOLYN", 3, 150);
            List<int> roomsNumber = new List<int>();
            roomsNumber.Add(1);
            roomsNumber.Add(2);
            roomsNumber.Add(3);
            DateTime dateIn, dateOut;
            DateTime.TryParseExact("01/01/2022", "dd/MM/yyyy", null, DateTimeStyles.None, out dateIn);
            DateTime.TryParseExact("05/01/2022", "dd/MM/yyyy", null, DateTimeStyles.None, out dateOut);
            bool breakfast = true;
            string addInfo = "none";

            DateTime expected;
            DateTime.TryParseExact("05/01/2022", "dd/MM/yyyy", null, DateTimeStyles.None, out expected);
            //Act
            OrderOnRoom order = new OrderOnRoom(client, hotel, roomsNumber, dateIn, dateOut, breakfast, addInfo);
            //Assert
            DateTime actual = order.DateOut;
            Assert.AreEqual(expected, actual, "Date out doesnt right");
        }
        [TestMethod]
        public void DateInUnitTests()
        {
            //Arrange
            Client client = new Client("Serhii", "Hryniuk", "+380931214766");
            Hotel hotel = new Hotel("VOLYN", 3, 150);
            List<int> roomsNumber = new List<int>();
            roomsNumber.Add(1);
            roomsNumber.Add(2);
            roomsNumber.Add(3);
            DateTime dateIn, dateOut;
            DateTime.TryParseExact("01/01/2022", "dd/MM/yyyy", null, DateTimeStyles.None, out dateIn);
            DateTime.TryParseExact("05/01/2022", "dd/MM/yyyy", null, DateTimeStyles.None, out dateOut);
            bool breakfast = true;
            string addInfo = "none";

            DateTime expected;
            DateTime.TryParseExact("01/01/2022", "dd/MM/yyyy", null, DateTimeStyles.None, out expected);
            //Act
            OrderOnRoom order = new OrderOnRoom(client, hotel, roomsNumber, dateIn, dateOut, breakfast, addInfo);
            //Assert
            DateTime actual = order.DateIn;
            Assert.AreEqual(expected, actual, "Date in doesnt right");
        }
        [TestMethod]
        public void RoomsNumberUnitTests()
        {
            //Arrange
            Client client = new Client("Serhii", "Hryniuk", "+380931214766");
            Hotel hotel = new Hotel("VOLYN", 3, 150);
            List<int> roomsNumber = new List<int>();
            roomsNumber.Add(1);
            roomsNumber.Add(2);
            roomsNumber.Add(3);
            DateTime dateIn, dateOut;
            DateTime.TryParseExact("01/01/2022", "dd/MM/yyyy", null, DateTimeStyles.None, out dateIn);
            DateTime.TryParseExact("05/01/2022", "dd/MM/yyyy", null, DateTimeStyles.None, out dateOut);
            bool breakfast = true;
            string addInfo = "none";
            //Act
            OrderOnRoom order = new OrderOnRoom(client, hotel, roomsNumber, dateIn, dateOut, breakfast, addInfo);
            //Assert
            Assert.IsNotNull(order.RoomsNumber);
        }
        [TestMethod]
        public void HotelUnitTests()
        {
            //Arrange
            Client client = new Client("Serhii", "Hryniuk", "+380931214766");
            Hotel hotel = new Hotel("VOLYN", 3, 150);
            List<int> roomsNumber = new List<int>();
            roomsNumber.Add(1);
            roomsNumber.Add(2);
            roomsNumber.Add(3);
            DateTime dateIn, dateOut;
            DateTime.TryParseExact("01/01/2022", "dd/MM/yyyy", null, DateTimeStyles.None, out dateIn);
            DateTime.TryParseExact("05/01/2022", "dd/MM/yyyy", null, DateTimeStyles.None, out dateOut);
            bool breakfast = true;
            string addInfo = "none";
            //Act
            OrderOnRoom order = new OrderOnRoom(client, hotel, roomsNumber, dateIn, dateOut, breakfast, addInfo);
            //Assert
            Assert.IsNotNull(order.Hotel);
        }
        [TestMethod]
        public void ClientUnitTests()
        {
            //Arrange
            Client client = new Client("Serhii", "Hryniuk", "+380931214766");
            Hotel hotel = new Hotel("VOLYN", 3, 150);
            List<int> roomsNumber = new List<int>();
            roomsNumber.Add(1);
            roomsNumber.Add(2);
            roomsNumber.Add(3);
            DateTime dateIn, dateOut;
            DateTime.TryParseExact("01/01/2022", "dd/MM/yyyy", null, DateTimeStyles.None, out dateIn);
            DateTime.TryParseExact("05/01/2022", "dd/MM/yyyy", null, DateTimeStyles.None, out dateOut);
            bool breakfast = true;
            string addInfo = "none";
            //Act
            OrderOnRoom order = new OrderOnRoom(client, hotel, roomsNumber, dateIn, dateOut, breakfast, addInfo);
            //Assert
            Assert.IsNotNull(order.Client);
        }
        [TestMethod]
        public void PriceUnitTests()
        {
            //Arrange
            Client client = new Client("Serhii", "Hryniuk", "+380931214766");
            Hotel hotel = new Hotel("VOLYN", 3, 150);
            List<int> roomsNumber = new List<int>();
            roomsNumber.Add(1);
            roomsNumber.Add(2);
            roomsNumber.Add(3);
            DateTime dateIn, dateOut;
            DateTime.TryParseExact("01/01/2022", "dd/MM/yyyy", null, DateTimeStyles.None, out dateIn);
            DateTime.TryParseExact("05/01/2022", "dd/MM/yyyy", null, DateTimeStyles.None, out dateOut);
            bool breakfast = true;
            string addInfo = "none";
            //Act
            OrderOnRoom order = new OrderOnRoom(client, hotel, roomsNumber, dateIn, dateOut, breakfast, addInfo);
            //Assert
            Assert.IsNotNull(order.Price);
        }
        [TestMethod]
        public void HowManyDaysUnitTests()
        {
            //Arrange
            Client client = new Client("Serhii", "Hryniuk", "+380931214766");
            Hotel hotel = new Hotel("VOLYN", 3, 150);
            List<int> roomsNumber = new List<int>();
            roomsNumber.Add(1);
            roomsNumber.Add(2);
            roomsNumber.Add(3);
            DateTime dateIn, dateOut;
            DateTime.TryParseExact("01/01/2022", "dd/MM/yyyy", null, DateTimeStyles.None, out dateIn);
            DateTime.TryParseExact("05/01/2022", "dd/MM/yyyy", null, DateTimeStyles.None, out dateOut);
            bool breakfast = true;
            string addInfo = "none";

            int expected = 4;
            //Act
            OrderOnRoom order = new OrderOnRoom(client, hotel, roomsNumber, dateIn, dateOut, breakfast, addInfo);
            //Assert
            int actual = order.HowManyDays;
            Assert.AreEqual(expected, actual, "Days doesnt right");
        }
    }
}
