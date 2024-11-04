using Disaster_Alleviation_Foundation.Controllers;
using Disaster_Alleviation_Foundation.Data;
using Disaster_Alleviation_Foundation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace VolunteerTest
{
    [TestClass]
    public class VolunteersControllerTest
    {
        private OrganizationContext _context;
        private VolunteersController _controller;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<OrganizationContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new OrganizationContext(options);
            _controller = new VolunteersController(_context);
        }

        [TestMethod]
        public async Task Index_Returns_View_With_VolunteerList()
        {
            // Arrange
            _context.Volunteer.Add(new Volunteer { ID = 1, Name = "John Doe", Contact = "1234567890", Address = "123 Test St", HPS_Registration_Number = "HPS123", Reason_to_Volunteer = "Help people" });
            _context.SaveChanges();

            // Act
            var result = await _controller.Index() as ViewResult;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(result.Model, typeof(System.Collections.Generic.List<Volunteer>));
        }

        [TestMethod]
        public async Task Details_Returns_View_With_Volunteer()
        {
            // Arrange
            var volunteer = new Volunteer { ID = 1, Name = "John Doe", Contact = "1234567890", Address = "123 Test St", HPS_Registration_Number = "HPS123", Reason_to_Volunteer = "Help people" };
            _context.Volunteer.Add(volunteer);
            _context.SaveChanges();

            // Act
            var result = await _controller.Details(1) as ViewResult;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(result.Model, typeof(Volunteer));
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("John Doe", ((Volunteer)result.Model).Name);
        }

        [TestMethod]
        public async Task Create_Post_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var newVolunteer = new Volunteer { ID = 2, Name = "Jane Doe", Contact = "0987654321", Address = "456 Test Ave", HPS_Registration_Number = "HPS456", Reason_to_Volunteer = "Make a difference" };

            // Act
            var result = await _controller.Create(newVolunteer) as RedirectToActionResult;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Index", result.ActionName);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, await _context.Volunteer.CountAsync());
        }

        [TestMethod]
        public async Task Edit_Post_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var volunteer = new Volunteer { ID = 1, Name = "John Doe", Contact = "1234567890", Address = "123 Test St", HPS_Registration_Number = "HPS123", Reason_to_Volunteer = "Help people" };
            _context.Volunteer.Add(volunteer);
            _context.SaveChanges();

            // Modify volunteer details
            volunteer.Name = "John Doe Updated";

            // Act
            var result = await _controller.Edit(1, volunteer) as RedirectToActionResult;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Index", result.ActionName);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("John Doe Updated", _context.Volunteer.Find(1).Name);
        }

        [TestMethod]
        public async Task DeleteConfirmed_Removes_Volunteer()
        {
            // Arrange
            var volunteer = new Volunteer { ID = 1, Name = "John Doe", Contact = "1234567890", Address = "123 Test St", HPS_Registration_Number = "HPS123", Reason_to_Volunteer = "Help people" };
            _context.Volunteer.Add(volunteer);
            _context.SaveChanges();

            // Act
            var result = await _controller.DeleteConfirmed(1) as RedirectToActionResult;

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Index", result.ActionName);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, await _context.Volunteer.CountAsync());
        }
    }
}