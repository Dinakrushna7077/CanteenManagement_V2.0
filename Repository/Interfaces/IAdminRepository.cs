using CanteenManagement_2._0.Models;

namespace CanteenManagement_2._0.Repository.Interfaces
{
    public interface IAdminRepository
    {
        Task<int> NewCustomer(Customer cust);
    }
}
