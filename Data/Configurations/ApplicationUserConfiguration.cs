using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using LeaveManagementSystem.Web.Models;
using System.Reflection.Metadata;
using System.Reflection.Emit;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LeaveManagementSystem.Web.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            // Admin user
                builder.HasData(
                    new ApplicationUser
                    {
                        Id = "f2bf8027-b6a5-4f21-8d96-f618898ca6fa",
                        Email = "admin@localhost.com",
                        NormalizedEmail = "ADMIN@LOCALHOST.COM",
                        NormalizedUserName = "ADMIN@LOCALHOST.COM",
                        UserName = "admin@localhost.com",
                        EmailConfirmed = true,

                        PasswordHash = "AQAAAAIAAYagAAAAEBf9KA9PCyBLHChSxfo1Wuw/S4ievDq0ehqwrOD9WwdK8x37QCZe31nfoPI9CvdClw==",
                        FirstName = "Default",
                        LastName = "Admin",
                        DateOfBirth = new DateOnly(2002,12,23),
                        SecurityStamp = "SECURITY_STAMP_1",
                        ConcurrencyStamp = "CONCURRENCY_STAMP_1"
                    }
                );

        }
    }
}