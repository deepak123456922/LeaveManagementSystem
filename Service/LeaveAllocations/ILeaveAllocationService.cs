using System.Runtime.CompilerServices;
using LeaveManagementSystem.Web.Models.LeaveAllocations;
namespace LeaveManagementSystem.Web.Service.LeaveAllocations
{
    public interface  ILeaveAllocationService
    {
        public  Task AllocateLeave(string employeeId);

        //public Task<List<LeaveAllocation>> GetAllocations(string? userId);

        Task<EmployeeAllocationVM> GetEmployeeAllocation(string? userId);

        Task<List<EmployeeListVM>> GetEmployees();

        Task<LeaveAllocationEditVM> GetEmployeeAllocations(int allocationId);

        Task EditAllocation(LeaveAllocationEditVM allocationEditVM);

        Task<LeaveAllocation> GetCurrentAllocation(int leaveTypeId, string employeeId);
    }
}