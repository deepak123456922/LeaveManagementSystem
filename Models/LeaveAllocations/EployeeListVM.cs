using System.ComponentModel.DataAnnotations;
namespace LeaveManagementSystem.Web.Models.LeaveAllocations
{
    public class EmployeeListVM
    {
        public string Id {set; get;} = string.Empty;

        [Display(Name = "First Name")]   
        public string FirstName {set; get;} = string.Empty;

        [Display(Name = "Last Name")]   
        public string LastName {set; get;} = string.Empty;

         [Display(Name = "Email Address")]
        public string Email {set; get;}  = string.Empty;
    }
}