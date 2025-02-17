namespace SimpleLibraryManagerLib
{
    public class Library(int capacity) : ILibrary
    {
        private readonly List<Book> books = [];
        private readonly int capacity = capacity;

        private const string FullCapacityMessage = "Library is at full capacity. Cannot add more books.";
        private const string BookAddedMessage = "Book '{0}' by {1} added to the library.";
        private const string BooksInLibraryMessage = "Books in the library:";
        private const string BookRemovedMessage = "Book '{0}' removed from the library.";
        private const string BookNotFoundMessage = "Book '{0}' not found in the library.";

        public LibraryOperationResult AddBook(Book book)
        {
            if (books.Count >= capacity)
            {
                return CreateLibraryOperationResult(false, LibraryError.FullCapacity, FullCapacityMessage);
            }

            books.Add(book);
            return CreateLibraryOperationResult(true, message: string.Format(BookAddedMessage, book.Title, book.Author));
        }

        public LibraryOperationResult ListBooks()
        {
            if (books.Count == 0)
            {
                return CreateLibraryOperationResult(false, message: "No books in the library.");
            }

            var message = new System.Text.StringBuilder();
            message.AppendLine(BooksInLibraryMessage);

            for (int i = 0; i < books.Count; i++)
            {
                var book = books[i];
                message.AppendLine($"{i + 1}. {book.Title} by {book.Author}");
            }

            return CreateLibraryOperationResult(true, message: message.ToString());
        }

        public LibraryOperationResult RemoveBook(string title)
        {
            var bookToRemove = books.FirstOrDefault(b => b.Title == title);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                return CreateLibraryOperationResult(true, message: string.Format(BookRemovedMessage, title));
            }
            else
            {
                return CreateLibraryOperationResult(false, LibraryError.BookNotFound, string.Format(BookNotFoundMessage, title));
            }
        }

        public Book? FindBookByTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return null;
            }

            return books.FirstOrDefault(b => b.Title == title);
        }

        private static LibraryOperationResult CreateLibraryOperationResult(
            bool success,
            LibraryError error = LibraryError.None,
            string message = "")
        {
            return new LibraryOperationResult
            {
                Success = success,
                Error = error,
                Message = message
            };
        }
    }
}
