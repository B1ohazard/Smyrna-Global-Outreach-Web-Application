using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using Smyrna_Prototype.Models;

namespace Smyrna_Prototype.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
                  // Parse options to the database 
                  base(options)
        {
        }
        public DbSet<Produce> Products { get; set; }

        public DbSet<Donation> Donations { get; set; }

        public DbSet<Enquiry> Enquiries { get; set; }

        public DbSet<CustomerReview> CustomerReviews { get; set; }

        public DbSet<AddReview> AddReviews { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // prepopulated data --> to place into the Db

            //Seeding a 'Administrator' role to AspNetRoles table
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Administrator", NormalizedName = "ADMINISTRATOR".ToUpper() });

            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<IdentityUser>();

            //Seeding the User to AspNetUsers table
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                    UserName = "admin@smyrna.com",
                    NormalizedUserName = "ADMIN@SMYRNA.COM",
                    PasswordHash = hasher.HashPassword(null, "Admin#123")
                }
            );

            //Seeding the relation between our user and role to AspNetUserRoles table
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }
            );
        }

    }
}
