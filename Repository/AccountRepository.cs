using CanteenManagement_2._0.Data;
using CanteenManagement_2._0.Models;
using CanteenManagement_2._0.Repository.Interfaces;
using Dapper;
using System.Text.RegularExpressions;
using System.Data;

namespace CanteenManagement_2._0.Repository
{
    public class AccountRepository:IAccountRepository
    {
        public readonly DapperContext db;
        public AccountRepository(DapperContext db)
        {
            this.db = db;
        }
        public async Task<User> GetUserById(string uid)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@action", "GetUser");
            param.Add("@uid", uid);
            return (await db.GetConnection().QueryAsync<User>("ProcUserLogin", param, commandType: CommandType.StoredProcedure)).FirstOrDefault();
        }
    }
}
