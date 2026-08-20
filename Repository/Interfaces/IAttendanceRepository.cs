using CanteenManagement_2._0.Models.ViewModels;

namespace CanteenManagement_2._0.Repository.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<bool> MarkAsAttended(AttendanceViewModel attend,char action);
        Task<bool> RemoveAttended(AttendanceViewModel attend);
    }
}
