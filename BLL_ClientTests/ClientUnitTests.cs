using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coursework_BLL_;

namespace BLL_ClientTests
{
    [TestClass]
    public class ClientUnitTests
    {
        [TestMethod]
        public void FirstnameUnitTests()
        {
            //Arrange
            string firstname = "Serhii";
            string expected = "Serhii";
            //Act
            Client client = new Client(firstname, "TEST", "TEST");
            //Assert
            string actual = client.Firstname;
            Assert.AreEqual(expected, actual, "Firstname doesnt return right");
        }
        [TestMethod]
        public void LastnameUnitTests()
        {
            //Arrange
            string lastname = "Hryniuk";
            string expected = "Hryniuk";
            //Act
            Client client = new Client("TEST", lastname, "TEST");
            //Assert
            string actual = client.Lastname;
            Assert.AreEqual(expected, actual, "Lastname doesnt return right");
        }
        [TestMethod]
        public void PhoneUnitTests()
        {
            //Arrange
            string phone = "+380931214766";
            string expected = "+380931214766";
            //Act
            Client client = new Client("TEST", "TEST", phone);
            //Assert
            string actual = client.Phone;
            Assert.AreEqual(expected, actual, "Phone doesnt return right");
        }
    }
}
