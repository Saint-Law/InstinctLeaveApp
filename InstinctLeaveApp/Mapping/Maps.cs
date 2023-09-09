using AutoMapper;
using InstinctLeaveApp.Data;
using InstinctLeaveApp.Models;

namespace InstinctLeaveApp.Mapping
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestVM>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationVM>().ReverseMap();

        }
    }
}
