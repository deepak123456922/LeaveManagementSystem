using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using LeaveManagementSystem.Web.Models.LeaveAllocations;
using LeaveManagementSystem.Web.Service.LeaveTypes;
using LeaveManagementSystem.Web.Service.LeaveRequests;
using LeaveManagementSystem.Web.Models.LeaveRequests;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace LeaveManagementSystem.Web.Controllers
{ 
    public class LeaveRequestsController(ILeaveTypeService _leaveTypesService,ILeaveRequestService _leaveRequestService) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var model = await _leaveRequestService.GetEmployeeLeaveRequests();
             return View(model);
        }

         public async Task<IActionResult> Create(int? leaveTypeId)
      {
        var leaveTypes = await _leaveTypesService.getAll();
        var leaveTypesList = new SelectList(leaveTypes, "Id", "Name", leaveTypeId);
        var model = new LeaveRequestCreateVM
        {
            StartDate = DateOnly.FromDateTime(DateTime.Now),
            EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
            LeaveTypes = leaveTypesList,
        };
        return View(model);
      }
 

         [HttpPost]
         [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequestCreateVM model)
        {

            if(await _leaveRequestService.RequestedDatesExceedAllocation(model)){
                ModelState.AddModelError(string.Empty,"You have exceeded you allocation");
                ModelState.AddModelError(nameof(model.EndDate),"The number of days requested is invalid");
            }

            if(ModelState.IsValid){
                await _leaveRequestService.CreateLeaveRequest(model);
                 return RedirectToAction(nameof(Index));
            }
            var leaveTypes = await _leaveTypesService.getAll();
            model.LeaveTypes = new SelectList(leaveTypes, "Id", "Name");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
             await _leaveRequestService.CancelLeaveRequest(id);
              return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> ListRequests()
        {
            var model = await _leaveRequestService.AdminGetAllLeaveRequests();
            return View(model);
        }
        

        public async Task<IActionResult> Review(int id)
        {
             var model = await _leaveRequestService.GetLeaveRequestForReview(id);
             return View(model);
        }
         
         [HttpPost]
         [ValidateAntiForgeryToken]
        public async Task<IActionResult> Review(int id, bool approved)
        {
             await _leaveRequestService.ReviewLeaveRequest(id, approved);
            return RedirectToAction(nameof(ListRequests));
        }
    }
}