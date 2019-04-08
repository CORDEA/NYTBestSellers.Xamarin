using System.Threading.Tasks;
using Unity;

namespace NYTBestSellers
{
    internal class BestSellerRepository
    {
        [Dependency] public BestSellerRemoteDataSource DataSource { get; set; }

        public async Task<ListNamesResponse> GetListNames()
        {
            return await DataSource.GetListNames();
        }

        public async Task<ListsResponse> GetLists(string list)
        {
            return await DataSource.GetLists(list);
        }
    }
}