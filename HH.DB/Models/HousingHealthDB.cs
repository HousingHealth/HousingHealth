using HH.DB.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace HH.DB.Models
{
    public class HousingHealthDB : IdentityDbContext<ApplicationUser>
    {
        public HousingHealthDB() : base("name= HousingHealthDB")
        {
        }

        public DbSet<Properties> Properties { get; set; }
        public DbSet<RentalRegistrations> RentalRegistrations { get; set; }
        public DbSet<OwnershipFreq> OwnershipFreq { get; set; }
        public DbSet<SavedProperties> Property { get; set; }
    }
}
