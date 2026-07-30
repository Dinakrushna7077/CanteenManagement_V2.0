using CanteenManagement_2._0.Models;

namespace CanteenManagement_2._0.Repository.Interfaces
{
    public interface IPublicQueryRepo
    {
        Task<List<PublicQuery>> GetAllPublicQueries();
        Task<int> AddPublicQuery(PublicQuery query);
        Task <int> MarkeAsRead(int  queryId);
    }
}
