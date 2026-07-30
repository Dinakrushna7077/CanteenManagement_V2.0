using Microsoft.Data.SqlClient;

namespace CanteenManagement_2._0.Data
{
    public class DapperContext
    {
        protected readonly IConfiguration config;
        public DapperContext(IConfiguration _config)
        {
            config= _config;
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(config.GetConnectionString("DefaultConnection"));
        }
    }
}
