using System.Threading.Tasks;
using Unity;

namespace NYTBestSellers
{
    internal class ListsRepository
    {
        [Dependency] public ListsRemoteDataSource DataSource { get; set; }

        public async Task<ListsResponse> Get(string list)
        {
            return await DataSource.GetLists(list);
        }
    }
}