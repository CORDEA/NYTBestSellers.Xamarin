using System.Threading.Tasks;
using Unity;

namespace NYTBestSellers
{
    internal class ListNamesRepository
    {
        [Dependency] public ListNamesRemoteDataSource DataSource { get; set; }
        [Dependency] public ListNamesLocalDataSource LocalDataSource { get; set; }

        public async Task<ListNamesResponse> Get()
        {
            var cache = LocalDataSource.Get();
            if (cache != null)
            {
                return cache;
            }

            var result = await DataSource.GetListNames();
            LocalDataSource.Store(result);
            return result;
        }
    }
}