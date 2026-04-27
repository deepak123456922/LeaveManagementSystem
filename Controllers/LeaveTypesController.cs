using System;
    
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using AutoMapper;
using System.Runtime.CompilerServices;
using LeaveManagementSystem.Web.Service.LeaveTypes;
using Microsoft.AspNetCore.Authorization;


namespace LeaveManagementSystem.Web.Controllers
{
     [Authorize(Roles = Roles.Administrator)]
    public class LeaveTypesController : Controller
    {
        

        private readonly ILeaveTypeService leaveTypeService;

        private static string NameExistsValidationMessage = "Name already exists, Please create new name.";

        public LeaveTypesController(ILeaveTypeService leaveTypeService)
        {
           
            this.leaveTypeService = leaveTypeService;
        }

        

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {   
            var viewData = await leaveTypeService.getAll();
            return View(viewData);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await leaveTypeService.Get<LeaveTypeReadOnlyVM>(id.Value);
            if (leaveType == null)
            {
                return NotFound();
            }
            
            
            return View(leaveType);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( LeaveTypeCreateVM leaveCreate)
        {

            if(await leaveTypeService.IsLeaveTypeExists(leaveCreate.Name))
            {
                ModelState.AddModelError(nameof(leaveCreate.Name),NameExistsValidationMessage);
            }

            if (ModelState.IsValid)
            {
                await leaveTypeService.CreateLeave(leaveCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveCreate);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await leaveTypeService.Get<LeaveTypeEditVM>(id.Value);
            if (leaveType == null)
            {
                return NotFound();
            }

            
            return View(leaveType);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeEditVM leaveTypeEdit)
        {
            if (id != leaveTypeEdit.Id)
            {
                return NotFound();
            }

            if(await leaveTypeService.CheckNameExistsToEdit(leaveTypeEdit))
            {
                ModelState.AddModelError(nameof(leaveTypeEdit.Name),NameExistsValidationMessage);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    await leaveTypeService.Edit(leaveTypeEdit);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!leaveTypeService.LeaveTypeExists(leaveTypeEdit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeEdit);
        }

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await leaveTypeService.Get<LeaveTypeReadOnlyVM>(id.Value);
            if (leaveType == null)
            {
                return NotFound();
            }
            
           
            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            await leaveTypeService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
