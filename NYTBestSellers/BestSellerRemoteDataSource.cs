using System.Threading.Tasks;
using Unity;

namespace NYTBestSellers
{
    internal class BestSellerRemoteDataSource
    {
        [Dependency] public NytClient Client { get; set; }

        public async Task<ListNamesResponse> GetListNames()
        {
            return await Client.GetListNames();
        }

        public async Task<ListsResponse> GetLists(string list)
        {
            return await Client.GetLists(list);
        }
    }
}