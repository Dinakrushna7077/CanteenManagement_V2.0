using CanteenManagement_2._0.Models;
using CanteenManagement_2._0.Repository.Interfaces;
using CanteenManagement_2._0.Services.Interfaces;

namespace CanteenManagement_2._0.Services
{
    public class AdminService:IAdminService
    {
        private readonly IAdminRepository repo;
        public AdminService(IAdminRepository _repo)
        {
            repo = _repo;
        }

        public async Task<ResponseViewModel<int>> NewCustomerAsync(Customer cust)
        {
            ResponseViewModel<int> response=new ResponseViewModel<int>();
            if (cust != null)
            {
                int x = await repo.NewCustomer(cust);
                if (x > 0)
                {
                    response.Success = true;
                    response.Message = "New Customer Registered...";
                    return await Task.FromResult(response);
                }
                response.Message = "Something went wrong please try again later...";
                return await Task.FromResult(response);
            }
            
             response.Message = "Please Enter All required fields...";
            return await Task.FromResult(response);
        }
        public async Task<List<string>> GetAliasAsync(int limit)
        {
            var result = await repo.AvailableAlias(limit);
            if(result.alias.Count()>0)
            {
                return result.alias;
            }
            result.alias=GenerateNextAlias(result.maxAlias,limit);
            return result.alias;
        }
        private List<string> GenerateNextAlias(int n, int limit)
        {
            var result = new List<string>();
            for(int i=n+1;i<=n+limit;i++)
            {
                result.Add(i.ToString("D3"));
            }
            return result;
        }
    }
}
