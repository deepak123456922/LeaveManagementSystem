using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using System.Security.Cryptography.X509Certificates;


namespace LeaveManagementSystem.Web.Service.LeaveTypes
{
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LeaveTypeService(ApplicationDbContext context, IMapper mapper)
        {
           this._context = context;
           this._mapper = mapper; 
        }
         
      public async Task<List<LeaveTypeReadOnlyVM>> getAll()
        {
            var data = await _context.LeaveTypes.ToListAsync();

            var newData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);

            return newData;


        }

        public async Task CreateLeave(LeaveTypeCreateVM leaveCreate)
        {
            var data = _mapper.Map<LeaveType>(leaveCreate);
            _context.Add(data);

            await _context.SaveChangesAsync();
        }

        public async Task<T?> Get<T>(int id) where T : class
        {
            var data = await _context.LeaveTypes.FirstOrDefaultAsync(X => X.Id == id);
            if(data == null)
            {
                return null;
            }
            var viewData = _mapper.Map<T>(data);
            return viewData;
        }

        public async Task Edit(LeaveTypeEditVM leaveTypeEditVM)
        {
            var data = _mapper.Map<LeaveType>(leaveTypeEditVM);
            _context.Update(data);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);
            if(data != null)
            {
                _context.Remove(data);
                await _context.SaveChangesAsync();
            }
        }


        public bool LeaveTypeExists(int id)
        {
            return _context.LeaveTypes.Any(e => e.Id == id);
        }

        public async Task<bool> IsLeaveTypeExists(string name)
        {
            var isnameExists = name.ToLower();
            return await _context.LeaveTypes.AnyAsync(leave => leave.Name.ToLower().Equals(isnameExists));
        }

        public async Task<bool> CheckNameExistsToEdit(LeaveTypeEditVM leaveTypeEditVM)
        {
            var isnameExists = leaveTypeEditVM.Name.ToLower();

            return await _context.LeaveTypes.AnyAsync(leave => leave.Name.ToLower().Equals(isnameExists) && leave.Id != leaveTypeEditVM.Id );
        }

        public async Task<bool> DaysExceedMaximum(int leaveTypeId, int days)
        {
            var leaveType = await _context.LeaveTypes.FindAsync(leaveTypeId);
            return leaveType.NumberOfDays < days;
        }
    }
}