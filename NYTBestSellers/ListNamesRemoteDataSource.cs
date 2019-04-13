using System.Threading.Tasks;
using Unity;

namespace NYTBestSellers
{
    internal class ListNamesRemoteDataSource
    {
        [Dependency] public NytClient Client { get; set; }

        public async Task<ListNamesResponse> GetListNames()
        {
            return await Client.GetListNames();
        }
    }
}