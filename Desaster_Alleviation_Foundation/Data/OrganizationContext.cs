using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Disaster_Alleviation_Foundation.Models;
using Disaster_Alleviation_Foundation.Data;
namespace Disaster_Alleviation_Foundation.Data
{
    public class OrganizationContext : IdentityDbContext
    {
        public OrganizationContext(DbContextOptions options) : base(options) { }


        public DbSet<Donation> Donation { get; set; }
        public DbSet<Incident> Incident { get; set; }

        public DbSet<Volunteer> Volunteer { get; set; }
    }
}
