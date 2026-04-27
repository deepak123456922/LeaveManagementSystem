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
    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
                    
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "3f61b8e5-3ebd-4fd9-9790-2450ca560688",
                    UserId = "f2bf8027-b6a5-4f21-8d96-f618898ca6fa"
                }
             );
        }
    }
}