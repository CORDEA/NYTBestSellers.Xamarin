using System.Threading.Tasks;
using Unity;

namespace NYTBestSellers
{
    internal class ListsRemoteDataSource
    {
        [Dependency] public NytClient Client { get; set; }

        public async Task<ListsResponse> GetLists(string list)
        {
            return await Client.GetLists(list);
        }
    }
}