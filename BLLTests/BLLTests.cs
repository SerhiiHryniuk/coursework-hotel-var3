using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coursework_BLL_;

namespace BLLTests
{
    [TestClass]
    public class BLLTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            int pl = 1;
            int exp = 1;
            Room room = new Room(pl, 1, 150);

            int actual = room.PlaceInRoom;
            Assert.AreEqual(exp, actual, 0, "Nope");
        }
    }
}
