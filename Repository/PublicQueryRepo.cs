using CanteenManagement_2._0.Data;
using CanteenManagement_2._0.Models;
using CanteenManagement_2._0.Repository.Interfaces;

namespace CanteenManagement_2._0.Repository
{
    public class PublicQueryRepo:IPublicQueryRepo
    {
        private readonly DapperContext db;
        public PublicQueryRepo(DapperContext _db)
        {
            db= _db;
        }
        public async Task<List<PublicQuery>> GetAllPublicQueries()
        {
            return null;
        }
        public async Task<int> AddPublicQuery(PublicQuery query)
        {
            return await Task.FromResult(0);
        }
        public async Task<int> MarkeAsRead(int queryId)
        {
            return await Task.FromResult(0);
        }
    }
}
