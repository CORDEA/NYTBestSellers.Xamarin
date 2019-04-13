namespace NYTBestSellers
{
    internal class ListsLocalDataSource
    {
        private ListsResponse _response;

        public void Store(ListsResponse response)
        {
            if (response.Results.Length == 0)
            {
                return;
            }

            _response = response;
        }

        public ListsResponse Get()
        {
            return _response;
        }

        public ListResponse Find(int index)
        {
            return _response.Results[index];
        }
    }
}