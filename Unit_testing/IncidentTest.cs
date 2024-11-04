using ClassLibrary;

namespace Unit_testing
{
    [TestClass]
    public class IncidentTests
    {
        [TestMethod]
        public void Test_Incident_IncidentID_Property()
        {
            // Arrange
            var incident = new Incident();
            int expectedIncidentID = 1;

            // Act
            incident.incident = expectedIncidentID;
            int actualIncidentID = incident.incident;

            // Assert
            Assert.AreEqual(expectedIncidentID, actualIncidentID);
        }

        [TestMethod]
        public void Test_Incident_Description_Property()
        {
            // Arrange
            var incident = new Incident();
            string expectedDescription = "Floodig due to heavy rain";

            // Act
            incident.description = expectedDescription;
            string actualDescription = incident.description;

            // Assert
            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [TestMethod]
        public void Test_Incident_Date_Property()
        {
            // Arrange
            var incident = new Incident();
            DateOnly expectedDate = DateOnly.FromDateTime(DateTime.Now);

            // Act
            incident.date = expectedDate;
            DateOnly actualDate = incident.date;

            // Assert
            Assert.AreEqual(expectedDate, actualDate);
        }

        [TestMethod]
        public void Test_Incident_Location_Property()
        {
            // Arrange
            var incident = new Incident();
            string expectedLocation = "Downtown";

            // Act
            incident.location = expectedLocation;
            string actualLocation = incident.location;

            // Assert
            Assert.AreEqual(expectedLocation, actualLocation);
        }

        [TestMethod]
        public void Test_Incident_Nature_Property()
        {
            // Arrange
            var incident = new Incident();
            string expectedNature = "Natural Disaster";

            // Act
            incident.nature = expectedNature;
            string actualNature = incident.nature;

            // Assert
            Assert.AreEqual(expectedNature, actualNature);
        }
    }
}

