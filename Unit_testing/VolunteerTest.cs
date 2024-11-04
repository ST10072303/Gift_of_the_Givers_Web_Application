using ClassLibrary;
namespace Unit_testing
{
    [TestClass]
    public class VolunteerTest
    {
        [TestClass]
        public class VolunteerTests
        {
            [TestMethod]
            public void Test_Volunteer_Id_Property()
            {
                // Arrange
                var volunteer = new Volunteer();
                int expectedId = 1;

                // Act
                volunteer.id = expectedId;
                int actualId = volunteer.id;

                // Assert
                Assert.AreEqual(expectedId, actualId);
            }

            [TestMethod]
            public void Test_Volunteer_Name_Property()
            {
                // Arrange
                var volunteer = new Volunteer();
                string expectedName = "John Doe";

                // Act
                volunteer.name = expectedName;
                string actualName = volunteer.name;

                // Assert
                Assert.AreEqual(expectedName, actualName);
            }

            [TestMethod]
            public void Test_Volunteer_Contact_Property()
            {
                // Arrange
                var volunteer = new Volunteer();
                string expectedContact = "+27 12 345 6789";

                // Act
                volunteer.contact = expectedContact;
                string actualContact = volunteer.contact;

                // Assert
                Assert.AreEqual(expectedContact, actualContact);
            }

            [TestMethod]
            public void Test_Volunteer_Address_Property()
            {
                // Arrange
                var volunteer = new Volunteer();
                string expectedAddress = "13 Read Ave Harare";

                // Act
                volunteer.address = expectedAddress;
                string actualAddress = volunteer.address;

                // Assert
                Assert.AreEqual(expectedAddress, actualAddress);
            }

            [TestMethod]
            public void Test_Volunteer_HPS_Registration_Number_Property()
            {
                // Arrange
                var volunteer = new Volunteer();
                string expectedHPSRegistrationNumber = "Reg12345";

                // Act
                volunteer.hPS_Registration_Number = expectedHPSRegistrationNumber;
                string actualHPSRegistrationNumber = volunteer.hPS_Registration_Number;

                // Assert
                Assert.AreEqual(expectedHPSRegistrationNumber, actualHPSRegistrationNumber);
            }

            [TestMethod]
            public void Test_Volunteer_Reason_to_Volunteer_Property()
            {
                // Arrange
                var volunteer = new Volunteer();
                string expectedReason = "The incident occured in my village";

                // Act
                volunteer.Reason_to_volunteer = expectedReason;
                string actualReason = volunteer.Reason_to_volunteer;

                // Assert
                Assert.AreEqual(expectedReason, actualReason);
            }
        }
    }
}