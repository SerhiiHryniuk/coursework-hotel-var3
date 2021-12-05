using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coursework_BLL_;

namespace BLL_RoomTests
{
    [TestClass]
    public class RoomUnitTests
    {
        [TestMethod]
        public void PlaceInRoomUnitTests()
        {
            // Arrange
            int placeInRoom = 1;
            int expected = 1;
            // Act
            Room room = new Room(placeInRoom, 1, 150);
            // Assert
            int actual = room.PlaceInRoom;
            Assert.AreEqual(expected, actual, 0, "Place in a room not corrected");
        }

        [TestMethod]
        public void RoomNumberUnitTests()
        {
            // Arrange
            int roomNumber = 1;
            int expected = 1;
            // Act
            Room room = new Room(1, roomNumber, 150);
            // Assert
            int actual = room.RoomNumber;
            Assert.AreEqual(expected, actual, 0, "Room's number not corrected");
        }

        [TestMethod]
        public void PriceForRoomUnitTests()
        {
            // Arrange
            int priceForOneNight = 150;
            int placeInRoom = 3;
            int expected = 450;
            // Act
            Room room = new Room(placeInRoom, 1, priceForOneNight);
            // Assert
            int actual = room.PriceForRoom;
            Assert.AreEqual(expected, actual, 0, "Price is not calculate right");
        }

        [TestMethod]
        public void IsRoomOccupiedUnitTests()
        {
            // Arrange
            bool IsRoomOccupiedTest1 = true;
            bool expected1 = true;
            bool IsRoomOccupiedTest2 = false;
            bool expected2 = false;
            // Act
            Room room1 = new Room(1, 1, IsRoomOccupiedTest1, 1);
            Room room2 = new Room(1, 1, IsRoomOccupiedTest2, 1);
            // Assert
            bool actual1 = room1.ISRoomOccupied;
            Assert.AreEqual(expected1, actual1, "Room occupied doesnt right calculate");
            bool actual2 = room2.ISRoomOccupied;
            Assert.AreEqual(expected2, actual2, "Room occupied doesnt right calculate");
        }
    }
}
