using CanteenManagement_2._0.Models;

namespace CanteenManagement_2._0.Services.Interfaces
{
    public interface IAdminService
    {
        Task<ResponseViewModel<int>> NewCustomerAsync(Customer cust);
        Task<List<string>> GetAliasAsync(int limit);
    }
}
