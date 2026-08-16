using CanteenManagement_2._0.Data;
using CanteenManagement_2._0.Models;
using CanteenManagement_2._0.Repository.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CanteenManagement_2._0.Repository
{
    public class AdminRepository:IAdminRepository
    {
        private readonly DapperContext db;
        public AdminRepository(DapperContext _db)
        {
            db = _db;
        }
        public async Task<int> NewCustomer(Customer cust)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@gmail", cust.GmailId);
                param.Add("@mobile", cust.MobileNo);
                param.Add("@pass", cust.Password);
                param.Add("@roleId", cust.RoleId);
                param.Add("@isActive", cust.ActiveStatus);
                param.Add("@name", cust.Name);
                param.Add("@isHosteler", cust.IsHosteler);
                param.Add("@departmentId", cust.DepartmentId);
                param.Add("@honoursId", cust.HonoursId);
                param.Add("@collegeRoll", cust.CollegeRoll);
                param.Add("@address", cust.Address);
                param.Add("@guardianMobile", cust.GuardianMobile);
                param.Add("@mealStatus", cust.MealStatus);
                param.Add("@alias", cust.Alias);

                SqlConnection con = db.GetConnection();
                if (con.State == ConnectionState.Closed)
                    con.Open();
                int x = await con.ExecuteAsync("ProcInsertCustomer", param, commandType: CommandType.StoredProcedure);
                return await Task.FromResult(x);
            }
            catch
            {
                return await Task.FromResult(0);
            }
        }
        public async Task<(List<string> alias,int maxAlias)> AvailableAlias(int limit)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@limit",limit);
                param.Add("@lastAlias",dbType:DbType.Int32,direction:ParameterDirection.Output);
                SqlConnection con=db.GetConnection();
                List<string> aliasList=(await con.QueryAsync<string>("ProcGetAlias",param,commandType: CommandType.StoredProcedure)).ToList();
                int maxAliasNumber = param.Get<int>("@lastAlias");
                return await Task.FromResult((aliasList,maxAliasNumber));
            }
            catch
            {
                return (new List<string>(),0);
            }
        }

    }
}
