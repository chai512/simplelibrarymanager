namespace SimpleLibraryManagerLib
{
    public interface ILibrary
    {
        LibraryOperationResult AddBook(Book book);
        LibraryOperationResult ListBooks();
        LibraryOperationResult RemoveBook(string title);
    }
}