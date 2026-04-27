using System.ComponentModel.DataAnnotations;
using LeaveManagementSystem.Web.Models.LeaveAllocations;



namespace LeaveManagementSystem.Web.Models.LeaveAllocations
{
    public class EmployeeAllocationVM : EmployeeListVM
    {
        

        [Display(Name = "Date Joined")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth {set; get;}

       public bool IsCompletedAllocation {get; set;}

        public List<LeaveAllocationVM> LeaveAllocations {set; get;}
    }
}