using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Reflection.Emit;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;
using System.Linq.Expressions;
using System.Text;
using System.Data;
using System.Security.Principal;
using System.Xml;
using System.Diagnostics;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

namespace LeaveManagementSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

      protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
               
                builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

                
                
                
            }

       
       public DbSet<LeaveType> LeaveTypes {get; set;}

       public DbSet<Period> Periods {get; set;}

       public DbSet<LeaveAllocation> LeaveAllocations {get; set;}

       public DbSet<LeaveRequest> LeaveRequests {get; set;}

       public DbSet<LeaveRequestStatus> LeaveRequestStatuses {get; set;}
       
    }
}
