using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveAllocations;
using LeaveManagementSystem.Web.Models.Periods;

namespace LeaveManagementSystem.Web.MappingProfiles
{
    public class LeaveAllocationAutoMapperProfile : Profile
    {
        public LeaveAllocationAutoMapperProfile()
        {
            CreateMap<LeaveAllocation, LeaveAllocationVM>();
            CreateMap<Period, PeriodVM>();
            CreateMap<ApplicationUser, EmployeeListVM>();
            CreateMap<LeaveAllocation, LeaveAllocationEditVM>();
           
        }
    }
}