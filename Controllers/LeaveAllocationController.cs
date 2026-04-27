using System.ComponentModel.Design;
using LeaveManagementSystem.Web.Service.LeaveAllocations;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LeaveManagementSystem.Web.Models.LeaveAllocations;
using LeaveManagementSystem.Web.Service.LeaveTypes;


namespace LeaveManagementSystem.Web.Controllers
{
    public class LeaveAllocationController : Controller
    {
        private readonly ILeaveAllocationService _leaveAllocationService;

        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveAllocationController(ILeaveAllocationService leaveAllocation, ILeaveTypeService leaveTypeService)
        {
            this._leaveAllocationService = leaveAllocation;
            this._leaveTypeService = leaveTypeService;
        }
        

        public async Task<IActionResult> Index()
        {

            var Data = await _leaveAllocationService.GetEmployees();
            return View(Data);
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
         public async Task<IActionResult> AllocateLeave(string? id)
        {

             await _leaveAllocationService.AllocateLeave(id);
            return RedirectToAction(nameof(Details),new {userId = id});
        }

        public async Task<IActionResult> Details(string? userId)
        {

            var employeeVm = await _leaveAllocationService.GetEmployeeAllocation(userId);
            return View(employeeVm);
        }

        public async Task<IActionResult> EditAllocation(int? id)
        {
          if(id == null)
            {
                return NotFound();
            }  

            var allocation = await _leaveAllocationService.GetEmployeeAllocations(id.Value);
            if(allocation == null)
            {
                return NotFound();
            }
            return View(allocation);
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllocation(LeaveAllocationEditVM allocation)
        {

            if(await _leaveTypeService.DaysExceedMaximum(allocation.LeaveType.Id, allocation.Days))
            {
                ModelState.AddModelError("Days","The allocation exceeds the maximum leave type value");
            }
            if (ModelState.IsValid)
            {
                await _leaveAllocationService.EditAllocation(allocation);
            return RedirectToAction(nameof(Details), new {userId = allocation.Employee.Id});
                
            }

            var days = allocation.Days;
            allocation = await _leaveAllocationService.GetEmployeeAllocations(allocation.Id);
            allocation.Days = days;
            return View(allocation);


            
            
        }
        
        
    }
}