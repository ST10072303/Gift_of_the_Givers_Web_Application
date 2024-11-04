using Disaster_Alleviation_Foundation;
using Disaster_Alleviation_Foundation.Data;
using Disaster_Alleviation_Foundation.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace DonationTest
{
    public class DonationsControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly OrganizationContext _context;

        public DonationsControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();

            // Configure in-memory database for the OrganizationContext
            var options = new DbContextOptionsBuilder<OrganizationContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new OrganizationContext(options);

            // Seed the in-memory database with test data if necessary
            SeedDatabase();
        }

        private void SeedDatabase()
        {
            // Optional: Add initial data to the in-memory database for testing
            _context.Donation.Add(new Donation { DonationID = 1, DonorID = 100, ResourceType = "Food", Quantity = 10, Date = DateOnly.FromDateTime(System.DateTime.Today), Destination = "City Center" });
            _context.SaveChanges();
        }

        [Fact]
        public async Task Index_ReturnsSuccessAndCorrectView()
        {
            // Act
            var response = await _client.GetAsync("/Donations");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains("Index", responseContent);
        }

        [Fact]
        public async Task Details_ReturnsDonation_WhenDonationExists()
        {
            // Arrange
            var donation = new Donation { DonationID = 2, DonorID = 101, ResourceType = "Clothing", Quantity = 5, Date = DateOnly.FromDateTime(System.DateTime.Today), Destination = "Shelter" };
            _context.Donation.Add(donation);
            await _context.SaveChangesAsync();

            // Act
            var response = await _client.GetAsync($"/Donations/Details/{donation.DonationID}");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.Contains("Clothing", responseContent);
        }

        [Fact]
        public async Task Create_AddsNewDonation_WhenModelIsValid()
        {
            // Arrange
            var donation = new Donation { DonationID = 3, DonorID = 102, ResourceType = "Clothing", Quantity = 5, Date = DateOnly.FromDateTime(System.DateTime.Today), Destination = "Community Center" };

            // Act
            var response = await _client.PostAsJsonAsync("/Donations/Create", donation);

            // Assert
            response.EnsureSuccessStatusCode();
            var createdDonation = await _context.Donation.FirstOrDefaultAsync(d => d.DonationID == donation.DonationID);
            Assert.NotNull(createdDonation);
            Assert.Equal("Clothing", createdDonation.ResourceType);
        }

        [Fact]
        public async Task Edit_UpdatesDonation_WhenModelIsValid()
        {
            // Arrange
            var donation = new Donation { DonationID = 4, DonorID = 103, ResourceType = "Medicine", Quantity = 20, Date = DateOnly.FromDateTime(System.DateTime.Today), Destination = "Clinic" };
            _context.Donation.Add(donation);
            await _context.SaveChangesAsync();

            donation.ResourceType = "Medical Supplies";

            // Act
            var response = await _client.PostAsJsonAsync($"/Donations/Edit/{donation.DonationID}", donation);

            // Assert
            response.EnsureSuccessStatusCode();
            var updatedDonation = await _context.Donation.FirstOrDefaultAsync(d => d.DonationID == donation.DonationID);
            Assert.NotNull(updatedDonation);
            Assert.Equal("Medical Supplies", updatedDonation.ResourceType);
        }

        [Fact]
        public async Task Delete_RemovesDonation_WhenDonationExists()
        {
            // Arrange
            var donation = new Donation { DonationID = 5, DonorID = 104, ResourceType = "Blankets", Quantity = 30, Date = DateOnly.FromDateTime(System.DateTime.Today), Destination = "Camp" };
            _context.Donation.Add(donation);
            await _context.SaveChangesAsync();

            // Act
            var response = await _client.PostAsync($"/Donations/DeleteConfirmed/{donation.DonationID}", null);

            // Assert
            response.EnsureSuccessStatusCode();
            var deletedDonation = await _context.Donation.FirstOrDefaultAsync(d => d.DonationID == donation.DonationID);
            Assert.Null(deletedDonation);
        }
    }
}
