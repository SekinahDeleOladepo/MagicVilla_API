using MagicVilla_VillaAPI.Model;
using MagicVilla_VillaAPI.Model.Dto;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Data
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) 
        {
                
        }
        public DbSet<Villa> Villas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Name = "Jannah",
                    ImageUrl = "",
                    Details = "",
                    Rate = 100,
                    Sqft = 1000,
                    Occupancy = 3,
                    Amenity = "",
                },
                new Villa
                {
                    Id = 2,
                    Name = "Bliss",
                    ImageUrl = "",
                    Details = "",
                    Rate = 50,
                    Sqft = 1050,
                    Occupancy = 5,
                    Amenity = "",
                    DateCreated = DateTime.Now,
                },
                new Villa
                {
                    Id = 3,
                    Name = "Pure",
                    ImageUrl = "",
                    Details = "",
                    Rate = 100,
                    Sqft = 1000,
                    Occupancy = 3,
                    Amenity = "",
                    DateCreated = DateTime.Now,
                },
                new Villa
                {
                    Id = 4,
                    Name = "Kingdom",
                    ImageUrl = "",
                    Details = "",
                    Rate = 500,
                    Sqft = 5000,
                    Occupancy = 1,
                    Amenity = "",
                    DateCreated = DateTime.Now,
                },
                new Villa
                {
                    Id = 5,
                    Name = "Salamah",
                    ImageUrl = "",
                    Details = "",
                    Rate = 500,
                    Sqft = 10000,
                    Occupancy = 1,
                    Amenity = "",
                    DateCreated = DateTime.Now,
                }
           );
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
