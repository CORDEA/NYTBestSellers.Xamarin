namespace NYTBestSellers
{
    internal class ListNamesLocalDataSource
    {
        private ListNamesResponse _response;

        public void Store(ListNamesResponse response)
        {
            if (response.Results.Length == 0)
            {
                return;
            }

            _response = response;
        }

        public ListNamesResponse Get()
        {
            return _response;
        }
    }
}