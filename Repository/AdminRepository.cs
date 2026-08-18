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
        SqlConnection con;
        public AdminRepository(DapperContext _db)
        {
            db = _db;
        }
        public async Task<bool> NewCustomer(Customer cust)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@gmail", cust.GmailId);
                param.Add("@mobile", cust.MobileNo);
                param.Add("@pass", cust.Password);
                param.Add("@roleId", 3);
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

                con = db.GetConnection();
                if (con.State == ConnectionState.Closed)
                    con.Open();
                int x = await con.ExecuteAsync("ProcInsertCustomer", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<(List<string> alias,int maxAlias)> AvailableAlias(int limit)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@limit",limit);
                param.Add("@lastAlias",dbType:DbType.Int32,direction:ParameterDirection.Output);
                con=db.GetConnection();
                List<string> aliasList=(await con.QueryAsync<string>("ProcGetAlias",param,commandType: CommandType.StoredProcedure)).ToList();
                int maxAliasNumber = param.Get<int>("@lastAlias");
                return await Task.FromResult((aliasList,maxAliasNumber));
            }
            catch
            {
                return (new List<string>(),0);
            }
        }
        public async Task<List<Department>> AllDepartments()
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@action", 'D');
            con = db.GetConnection();
            return (await con.QueryAsync<Department>("ProcGetDropdown", param,commandType: CommandType.StoredProcedure)).ToList();
        }
        public async Task<List<Honour>> GetHonours(int deptId)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@action", 'H');
            param.Add("@deptId", deptId);
            con = db.GetConnection();
            return (await con.QueryAsync<Honour>("ProcGetDropdown", param,commandType: CommandType.StoredProcedure)).ToList();
        }

    }
}
