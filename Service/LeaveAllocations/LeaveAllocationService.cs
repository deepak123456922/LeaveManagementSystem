using System.Reflection;
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveAllocations;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using LeaveManagementSystem.Web.Service.LeaveAllocations;
using LeaveManagementSystem.Web.Service.Periods;
using LeaveManagementSystem.Web.Service.LeaveTypes;
using LeaveManagementSystem.Web.Common;




namespace LeaveManagementSystem.Web.Service.LeaveAllocations
{
    public class LeaveAllocationService : ILeaveAllocationService
    {
        public readonly ApplicationDbContext _context;

        public readonly UserManager<ApplicationUser> _userManager;

        public readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IMapper _mapper;

        private readonly ILeaveTypeService _leaveTypeService;

         private readonly IPeriodsService _periodsService;

        public LeaveAllocationService(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
        IHttpContextAccessor httpContextAccessor,IMapper mapper, ILeaveTypeService leaveTypeService, IPeriodsService periodsService)
        {
            this._context = context;
            this._httpContextAccessor = httpContextAccessor;
            this._userManager = userManager;
            this._mapper = mapper;
            this._leaveTypeService = leaveTypeService;
            this._periodsService = periodsService;

        }

        public async Task AllocateLeave(string employeeId){

        var leaveTypes = await _context.LeaveTypes.Where(q => !q.LeaveAllocations.Any(x => x.EmployeeId == employeeId)).ToListAsync();

        var currentDate = DateTime.Now;

        var period = await _context.Periods.SingleAsync(q => q.EndDate.Year == currentDate.Year);

        var monthsRemaining = period.EndDate.Month - currentDate.Month;

        foreach(var leaveType in leaveTypes)
        {
            var accuralRate = decimal.Divide(leaveType.NumberOfDays,12);
           
           var LeaveAllocation = new LeaveAllocation
           {
               EmployeeId = employeeId,
               LeaveTypeId = leaveType.Id,
               PeriodId = period.Id,
               Days = (int)Math.Ceiling(accuralRate*monthsRemaining)
           };

           _context.Add(LeaveAllocation);
        }
          
          await _context.SaveChangesAsync();

        }


        private async Task<List<LeaveAllocation>> GetAllocations(string? userId)
        {

            //string employeeId = string.Empty;
            //if (!string.IsNullOrEmpty(userId))
            //{
                //employeeId = userId;
            //}
            //else
            //{
                //var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
                //employeeId = user.Id;
            //}
             
             var currentDate = DateTime.Now;
             var leaveAllocations = await _context.LeaveAllocations
             .Include(q => q.LeaveType)
             .Include(q => q.Period)
             .Where(q => q.EmployeeId == userId && q.Period.EndDate.Year == currentDate.Year).ToListAsync();

             return leaveAllocations;
            
        }

        public async Task<EmployeeAllocationVM> GetEmployeeAllocation(string? userId)
        {

            var user = string.IsNullOrEmpty(userId)
            ? await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User)
            : await _userManager.FindByIdAsync(userId);

            var allocations = await GetAllocations(user.Id);

            var allocationVmList = _mapper.Map<List<LeaveAllocation>,List<LeaveAllocationVM>>(allocations);

            var leaveTypesCount = await _context.LeaveTypes.CountAsync();

            //var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
            var employeeVm = new EmployeeAllocationVM
            {
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                LeaveAllocations = allocationVmList,
                IsCompletedAllocation = leaveTypesCount == allocations.Count
            };

            return employeeVm;
        }
 
        public async Task<List<EmployeeListVM>> GetEmployees()
        {
            var users = await _userManager.GetUsersInRoleAsync(Roles.Employee);
            var employees = _mapper.Map<List<ApplicationUser>,List<EmployeeListVM>>(users.ToList());

            return employees;
        }


        public async Task<LeaveAllocationEditVM> GetEmployeeAllocations(int allocationId)
        {
            var allocation = await _context.LeaveAllocations
                              .Include(q => q.LeaveType)
                              .Include(q => q.Employee)
                              .FirstOrDefaultAsync(q => q.Id == allocationId);

                              var model = _mapper.Map<LeaveAllocationEditVM>(allocation);

                              return model;
        }


      public  async Task EditAllocation(LeaveAllocationEditVM allocationEditVM)
        {
            await _context.LeaveAllocations.Where(q => q.Id == allocationEditVM.Id)
            .ExecuteUpdateAsync(s => s.SetProperty(e => e.Days, allocationEditVM.Days));
        }


         public async Task<LeaveAllocation> GetCurrentAllocation(int leaveTypeId, string employeeId)
        {
                var period = await _periodsService.GetCurrentPeriod();
                var allocation = await _context.LeaveAllocations
                        .FirstAsync(q => q.LeaveTypeId == leaveTypeId
                        && q.EmployeeId == employeeId
                        && q.PeriodId == period.Id);
                return allocation;
        }
        
    }
}