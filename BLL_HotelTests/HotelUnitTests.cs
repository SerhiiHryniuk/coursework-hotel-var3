using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coursework_BLL_;

namespace BLL_HotelTests
{
    [TestClass]
    public class HotelUnitTests
    {
        [TestMethod]
        public void PriceForOneNightUnitTests()
        {
            //Arrange
            int priceForOneNightPeople = 50;
            int expected = 50;
            //Act
            Hotel hotel = new Hotel("TEST", 0, priceForOneNightPeople);
            //Assert
            int actual = hotel.PriceForOneNightPeople;
            Assert.AreEqual(expected, actual, 0, "Price doesnt right");
        }
        [TestMethod]
        public void RoomsUnitTests()
        {
            //Arrange
            string nameOfHotel = "VOLYN";
            int numberOfRooms = 10;
            int priceForOneNight = 150;
            //Act
            Hotel hotel = new Hotel(nameOfHotel, numberOfRooms, priceForOneNight);
            //Assert
            Assert.IsNotNull(hotel.Rooms);
        }
        [TestMethod]
        public void NumberOfRoomsUnitTests()
        {
            //Arrange
            int numberOfRooms = 50;
            int expected = 50;
            //Act
            Hotel hotel = new Hotel("TEST", numberOfRooms, 0);
            //Assert
            int actual = hotel.NumberOfRooms;
            Assert.AreEqual(expected, actual, 0, "Number of room doesnt right");
        }
        [TestMethod]
        public void NameOfHotelUnitTests()
        {
            //Arrange
            string nameOFHotel = "VOLYN";
            string expected = "VOLYN";
            //Act
            Hotel hotel = new Hotel(nameOFHotel, 0, 0);
            //Assert
            string actual = hotel.NameOfHotel;
            Assert.AreEqual(expected, actual, "Name of hotel doesnt right");
        }
    }
}
