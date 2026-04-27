using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
    public class LeaveTypeEditVM : BaseLeaveTypeVM
    {

        [Required]
        [Length(5,150,ErrorMessage ="Enter valid name")]
        public string Name {get; set;} = string.Empty;

       [Required]
       [Range(5,10)]
       [Display(Name ="Maximum Allocation of Days")]
        public int NumberOfDays {get; set;}
    }
}