using LeaveManagementSystem.Web.Models.LeaveRequests;


namespace LeaveManagementSystem.Web.Service.LeaveRequests
{
    public interface ILeaveRequestService
    {
         Task CreateLeaveRequest(LeaveRequestCreateVM model);
         Task<bool> RequestedDatesExceedAllocation(LeaveRequestCreateVM model);
         Task<List<LeaveRequestReadOnlyVM>> GetEmployeeLeaveRequests();
         Task CancelLeaveRequest(int leaveRequestId);

         Task<EmployeeLeaveRequestListVM> AdminGetAllLeaveRequests();

         Task ReviewLeaveRequest(int leaveRequestId, bool approved);

          Task<ReviewLeaveRequestVM> GetLeaveRequestForReview(int id);
        
        
    }
}