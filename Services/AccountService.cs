using CanteenManagement_2._0.Models;
using CanteenManagement_2._0.Repository.Interfaces;
using CanteenManagement_2._0.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace CanteenManagement_2._0.Services
{
    public class AccountService:IAccountService
    {
        private readonly IAccountRepository repo;
        public AccountService(IAccountRepository repo)
        {
            this.repo = repo;
        }
        public async Task<LoginResult> UserLogin(LoginViewModel data)
        {
            LoginResult result=new LoginResult();
            try
            {
                var user = await repo.GetUserById(data.UserId);
                if (user != null)
                {
                    PasswordHasher<User> hasher= new PasswordHasher<User>();
                    var res = hasher.VerifyHashedPassword(user, user.Password, data.Password);
                    if (res==PasswordVerificationResult.Success)
                    {
                        result.Success = true;
                        result.Message = "Success";
                        result.user = user;
                        return await Task.FromResult(result);
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "Invalid Password...";
                        return await Task.FromResult(result);
                    }
                }
                else
                {
                    if (isMobileNumber(data.UserId))
                        result.Message = "Invalid mobile number";
                    if (isMail(data.UserId))
                        result.Message = "Invalid Gmail ID";
                    else
                        result.Message = "Invalid Format or User Id";
                    result.Success = false;
                    return await Task.FromResult(result);
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error : Something went wrong.Please try again later.";
                return result;
            }
        }
        private bool isMobileNumber(string userId)
        {
            if(string.IsNullOrWhiteSpace(userId))
                return false;
            return Regex.IsMatch(userId.Trim(),@"^\d{10}$");
        }
        private bool isMail(string userId)
        {
            if(string.IsNullOrWhiteSpace(userId))
                return false;
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(userId.Trim(), pattern, RegexOptions.IgnoreCase);
        }

    }
}
