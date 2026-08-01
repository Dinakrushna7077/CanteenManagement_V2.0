using CanteenManagement_2._0.Models;

namespace CanteenManagement_2._0.Services.Interfaces
{
    public interface IAccountService
    {
        Task<LoginResult> UserLogin(LoginViewModel user);
    }
}
