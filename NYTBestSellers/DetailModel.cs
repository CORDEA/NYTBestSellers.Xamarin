namespace NYTBestSellers
{
    public class DetailModel
    {
        public DetailModel(string title, string description, string author, string publisher)
        {
            Title = title;
            Description = description;
            Author = author;
            Publisher = publisher;
        }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public string Author { get; private set; }

        public string Publisher { get; private set; }
    }
}