using Disaster_Alleviation_Foundation.Controllers;
using Disaster_Alleviation_Foundation.Data;
using Disaster_Alleviation_Foundation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace IncidentTest
{
    [TestClass]
    public class IncidentsControllerTest
    {
        private OrganizationContext _context;
        private IncidentsController _controller;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<OrganizationContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new OrganizationContext(options);
            _controller = new IncidentsController(_context);
        }

        [TestMethod]
        public async Task Index_Returns_View_With_IncidentList()
        {
            // Arrange
            _context.Incident.Add(new Incident { IncidentID = 1, Description = "Test Incident", Date = new DateOnly(2023, 10, 1), Location = "Test Location", Nature = "Natural" });
            _context.SaveChanges();

            // Act
            var result = await _controller.Index() as ViewResult;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(result.Model, typeof(System.Collections.Generic.List<Incident>));
        }

        [TestMethod]
        public async Task Details_Returns_View_With_Incident()
        {
            // Arrange
            var incident = new Incident { IncidentID = 1, Description = "Test Incident", Date = new DateOnly(2023, 10, 1), Location = "Test Location", Nature = "Natural" };
            _context.Incident.Add(incident);
            _context.SaveChanges();

            // Act
            var result = await _controller.Details(1) as ViewResult;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(result.Model, typeof(Incident));
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Test Incident", ((Incident)result.Model).Description);
        }

        [TestMethod]
        public async Task Create_Post_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var newIncident = new Incident { IncidentID = 2, Description = "New Incident", Date = new DateOnly(2023, 11, 1), Location = "New Location", Nature = "Manmade" };

            // Act
            var result = await _controller.Create(newIncident) as RedirectToActionResult;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Index", result.ActionName);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, _context.Incident.CountAsync().Result);
        }

        [TestMethod]
        public async Task Edit_Post_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var incident = new Incident { IncidentID = 1, Description = "Test Incident", Date = new DateOnly(2023, 10, 1), Location = "Test Location", Nature = "Natural" };
            _context.Incident.Add(incident);
            _context.SaveChanges();

            // Modify the incident details
            incident.Description = "Updated Incident";

            // Act
            var result = await _controller.Edit(1, incident) as RedirectToActionResult;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Index", result.ActionName);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Updated Incident", _context.Incident.Find(1).Description);
        }

        [TestMethod]
        public async Task DeleteConfirmed_Removes_Incident()
        {
            // Arrange
            var incident = new Incident { IncidentID = 1, Description = "Test Incident", Date = new DateOnly(2023, 10, 1), Location = "Test Location", Nature = "Natural" };
            _context.Incident.Add(incident);
            _context.SaveChanges();

            // Act
            var result = await _controller.DeleteConfirmed(1) as RedirectToActionResult;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Index", result.ActionName);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, _context.Incident.CountAsync().Result);
        }
    }
}
