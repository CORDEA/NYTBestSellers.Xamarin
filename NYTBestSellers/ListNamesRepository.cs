using System.Threading.Tasks;
using Unity;

namespace NYTBestSellers
{
    internal class ListNamesRepository
    {
        [Dependency] public ListNamesRemoteDataSource DataSource { get; set; }

        public async Task<ListNamesResponse> Get()
        {
            return await DataSource.GetListNames();
        }
    }
}