using System.Reflection.Metadata;
using System.Reflection.Emit;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Web.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Web.Data.Configurations
{
    public class LeaveRequestStatusConfiguration : IEntityTypeConfiguration<LeaveRequestStatus>
    {
        public void Configure(EntityTypeBuilder<LeaveRequestStatus> builder)
        {
            builder.HasData(
                new LeaveRequestStatus
                {
                    Id = 1,
                    Name = "Pending"
                },
                new LeaveRequestStatus
                {
                    Id = 2,
                    Name = "Approved"
                },
                new LeaveRequestStatus
                {
                    Id = 3,
                    Name = "Declined"
                },
                new LeaveRequestStatus
                {
                    Id = 4,
                    Name = "Canceled"
                }

            );
        }
    }
}