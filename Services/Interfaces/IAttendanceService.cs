using CanteenManagement_2._0.Models;
using CanteenManagement_2._0.Models.ViewModels;
using System.Threading.Tasks;

namespace CanteenManagement_2._0.Services.Interfaces
{
    public interface IAttendanceService
    {
        Task<ResponseViewModel<int>> MarkAsAttendedAsync(AttendanceViewModel attend);
        Task<ResponseViewModel<int>> RemoveAttended(AttendanceViewModel attend);
    }
}
