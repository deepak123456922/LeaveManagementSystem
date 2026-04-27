using LeaveManagementSystem.Web.Models.Periods;
using LeaveManagementSystem.Web.Models.LeaveTypes;

using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveAllocations
{
    public class LeaveAllocationVM
    {
        public int Id {get; set;}
         
         [Display(Name = "Number of Days")]
        public int Days {get; set;}

         [Display(Name = "Allocation Period")]
        public PeriodVM Period {get; set;} = new PeriodVM();

        public LeaveTypeReadOnlyVM LeaveType {get; set;} = new LeaveTypeReadOnlyVM();
    }
}