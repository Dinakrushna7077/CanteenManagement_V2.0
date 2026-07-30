using Microsoft.Data.SqlClient;

namespace CanteenManagement_2._0.Data
{
    public class DapperContext
    {
        IConfiguration config;
        public DapperContext(IConfiguration _config)
        {
            config= _config;
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(config.GetConnectionString("DefaultConnection"));
        }
    }
}
