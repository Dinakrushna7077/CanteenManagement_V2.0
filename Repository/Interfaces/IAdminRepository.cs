using CanteenManagement_2._0.Models;

namespace CanteenManagement_2._0.Repository.Interfaces
{
    public interface IAdminRepository
    {
        Task<int> NewCustomer(Customer cust, long createdBy);
        Task<(List<string> alias,int maxAlias)> AvailableAlias(int limit);
        Task<List<Department>> AllDepartments();
        Task<List<Honour>> GetHonours(int deptId);
    }
}
