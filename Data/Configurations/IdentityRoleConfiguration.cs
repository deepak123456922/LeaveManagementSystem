using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Web.Models;
using System.Reflection.Metadata;
using System.Reflection.Emit;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Web.Data.Configurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            // Roles
                builder.HasData(

                    new IdentityRole
                    {
                        Id = "450c8bef-99a1-4533-ac74-aec5466032d4",
                        Name = "Employee",
                        NormalizedName = "EMPLOYEE",
                        ConcurrencyStamp = "1"
                    },
                    new IdentityRole
                    {
                        Id = "c498bdfc-9c3f-4329-b93e-0b47afd0f008",
                        Name = "Supervisor",
                        NormalizedName = "SUPERVISOR",
                        ConcurrencyStamp = "2"
                    },
                    new IdentityRole
                    {
                        Id = "3f61b8e5-3ebd-4fd9-9790-2450ca560688",
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR",
                        ConcurrencyStamp = "3"
                    }
                );
        }
    }
}