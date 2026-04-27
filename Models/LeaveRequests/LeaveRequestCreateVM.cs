using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace LeaveManagementSystem.Web.Models.LeaveRequests
{
    public class LeaveRequestCreateVM : IValidatableObject
    {
        [DisplayName("Start Name")]
        [Required]
        public DateOnly StartDate {get; set;}
       
        [DisplayName("End Name")]
        [Required]
        public DateOnly EndDate {get; set;}
        
         [DisplayName("Desired Leave Type")]
         [Required]
        public int LeaveTypeId {get; set;}

         [DisplayName("Additional Information")]
         [StringLength(250)]
        public string? RequestComments {get; set;}

        public SelectList? LeaveTypes {get; set;}

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate > EndDate)
            {
                yield return new ValidationResult("The Start Date Must Be Before the End Date", [nameof(StartDate), nameof(EndDate)]);
            }
        }
    }
}