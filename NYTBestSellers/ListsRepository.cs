using System.Threading.Tasks;
using Unity;

namespace NYTBestSellers
{
    internal class ListsRepository
    {
        [Dependency] public ListsRemoteDataSource DataSource { get; set; }
        [Dependency] public ListsLocalDataSource LocalDataSource { get; set; }

        public async Task<ListsResponse> Get(string list)
        {
            var cache = LocalDataSource.Get();
            if (cache != null)
            {
                return cache;
            }

            var result = await DataSource.GetLists(list);
            LocalDataSource.Store(result);
            return result;
        }

        public ListResponse Find(int index)
        {
            return LocalDataSource.Find(index);
        }
    }
}