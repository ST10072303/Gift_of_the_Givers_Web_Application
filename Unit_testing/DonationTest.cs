using ClassLibrary;

namespace Unit_testing
{
    [TestClass]
    public class DonationTests
    {
        [TestMethod]
        public void Test_Donation_DonationID_Property()
        {
            // Arrange
            var donation = new Donation();
            int expectedDonationID = 1;

            // Act
            donation.donationID = expectedDonationID;
            int actualDonationID = donation.donationID;

            // Assert
            Assert.AreEqual(expectedDonationID, actualDonationID);
        }

        [TestMethod]
        public void Test_Donation_DonorID_Property()
        {
            // Arrange
            var donation = new Donation();
            int expectedDonorID = 12345;

            // Act
            donation.donorID = expectedDonorID;
            int actualDonorID = donation.donorID;

            // Assert
            Assert.AreEqual(expectedDonorID, actualDonorID);
        }

        [TestMethod]
        public void Test_Donation_ResourceType_Property()
        {
            // Arrange
            var donation = new Donation();
            string expectedResourceType = "Food Supplies";

            // Act
            donation.resouceType = expectedResourceType;
            string actualResourceType = donation.resouceType;

            // Assert
            Assert.AreEqual(expectedResourceType, actualResourceType);
        }

        [TestMethod]
        public void Test_Donation_Quantity_Property()
        {
            // Arrange
            var donation = new Donation();
            int expectedQuantity = 500;

            // Act
            donation.quantity = expectedQuantity;
            int actualQuantity = donation.quantity;

            // Assert
            Assert.AreEqual(expectedQuantity, actualQuantity);
        }

        [TestMethod]
        public void Test_Donation_Date_Property()
        {
            // Arrange
            var donation = new Donation();
            DateOnly expectedDate = DateOnly.FromDateTime(DateTime.Now);

            // Act
            donation.date = expectedDate;
            DateOnly actualDate = donation.date;

            // Assert
            Assert.AreEqual(expectedDate, actualDate);
        }

        [TestMethod]
        public void Test_Donation_Destination_Property()
        {
            // Arrange
            var donation = new Donation();
            string expectedDestination = "Yemen Adan";

            // Act
            donation.destination = expectedDestination;
            string actualDestination = donation.destination;

            // Assert
            Assert.AreEqual(expectedDestination, actualDestination);
        }
    }

}
