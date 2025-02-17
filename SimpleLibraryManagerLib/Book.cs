namespace SimpleLibraryManagerLib
{
    public class Book(string title, string author) : IBook
    {
        public string Title { get; set; } = title;
        public string Author { get; set; } = author;
    }
}