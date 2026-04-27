using LeaveManagementSystem.Web.Models.LeaveTypes;

namespace LeaveManagementSystem.Web.Service.LeaveTypes
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeReadOnlyVM>> getAll();

        Task CreateLeave(LeaveTypeCreateVM leaveCreate);

        Task<T?> Get<T>(int id) where T : class;

        Task Edit(LeaveTypeEditVM leaveTypeEditVM);

        Task Remove(int id);

        Task<bool> DaysExceedMaximum(int leaveTypeId, int days);

        bool LeaveTypeExists(int id);

        Task<bool> IsLeaveTypeExists(string name);
        
        Task<bool> CheckNameExistsToEdit(LeaveTypeEditVM leaveTypeEditVM);
    }
}