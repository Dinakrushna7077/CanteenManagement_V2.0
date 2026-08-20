using CanteenManagement_2._0.Data;
using CanteenManagement_2._0.Models.ViewModels;
using CanteenManagement_2._0.Repository.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace CanteenManagement_2._0.Repository
{
    public class AttendanceRepository:IAttendanceRepository
    {
        private readonly DapperContext db;
        public AttendanceRepository(DapperContext db)
        {
            this.db = db;
        }
        public async Task<bool> MarkAsAttended(AttendanceViewModel attend,char action)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@action", action);
                param.Add("@alias", attend.Alias);
                param.Add("@date", attend.Date);
                param.Add("@breakfast", attend.BreakFast);
                param.Add("@lunch", attend.Lunch);
                param.Add("@dinner", attend.Dinner);

                param.Add("@attId", attend.AttId);
                param.Add("@itemId", attend.ItemId);
                param.Add("@quantity", attend.Quantity);
                param.Add("@extraPrice", attend.Price);

                SqlConnection con = db.GetConnection();
                if (con.State == ConnectionState.Closed)
                    con.Open();
                await con.ExecuteAsync("", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> RemoveAttended(AttendanceViewModel attend)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@action", 'U');
                param.Add("@alias", attend.Alias);
                param.Add("@date", attend.Date);
                param.Add("@breakfast", attend.BreakFast);
                param.Add("@lunch", attend.Lunch);
                param.Add("@dinner", attend.Dinner);

                param.Add("@attId", attend.AttId);
                param.Add("@itemId", attend.ItemId);
                param.Add("@quantity", attend.Quantity);
                param.Add("@extraPrice", attend.Price);

                SqlConnection con = db.GetConnection();
                if (con.State == ConnectionState.Closed)
                    con.Open();
                await con.ExecuteAsync("", param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch { return false; }
        }
    }
}
