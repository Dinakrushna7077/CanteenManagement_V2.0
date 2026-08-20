using CanteenManagement_2._0.Models;
using CanteenManagement_2._0.Models.ViewModels;
using CanteenManagement_2._0.Repository.Interfaces;
using CanteenManagement_2._0.Services.Interfaces;

namespace CanteenManagement_2._0.Services
{
    public class AttendanceService:IAttendanceService
    {
        private readonly IAttendanceRepository repo;
        public AttendanceService(IAttendanceRepository repo)
        {
            this.repo = repo;
        }
        public async Task<ResponseViewModel<int>> MarkAsAttendedAsync(AttendanceViewModel attend)
        {
            ResponseViewModel<int> response = new ResponseViewModel<int>();
            char ind = attend.AttId != 0 ? 'U' : 'I';
                
            bool isSuccess=await repo.MarkAsAttended(attend,ind);
            if(isSuccess)
            {
                response.Success = true;
                response.Message = "Attendance updated";
                return response;
            }
            response.Message = "Some Error occured";
            return response;
        }
        public async Task<ResponseViewModel<int>> RemoveAttended(AttendanceViewModel attend)
        {
            ResponseViewModel<int> response = new ResponseViewModel<int>();
            bool isSuccess = await repo.RemoveAttended(attend);
            if (isSuccess)
            {
                response.Success = true;
                response.Message = "Attendance updated";
                return response;
            }
            response.Message = "Some Error occured";
            return response;
        }
    }
}
