namespace SimpleLibraryManagerLib
{
    public class Library(int capacity) : ILibrary
    {
        private readonly IDictionary<string,Book> books = new Dictionary<string,Book>();
        private readonly int capacity = capacity;

        private const string FullCapacityMessage = "Library is at full capacity. Cannot add more books.";
        private const string BookAddedMessage = "Book '{0}' by {1} added to the library.";
        private const string BookAlreadyExistsMessage = "Book '{0}' by {1} already exists in the library.";
        private const string BooksInLibraryMessage = "Books in the library:";
        private const string BookRemovedMessage = "Book '{0}' removed from the library.";
        private const string BookNotFoundMessage = "Book '{0}' not found in the library.";

        public LibraryOperationResult AddBook(Book book)
        {
            if (books.Count >= capacity)
            {
                return CreateLibraryOperationResult(false, LibraryError.FullCapacity, FullCapacityMessage);
            }

            if (!books.TryAdd(book.Title, book))
            {
                return CreateLibraryOperationResult(false, LibraryError.BookAlreadyExists, string.Format(BookAlreadyExistsMessage, book.Title, book.Author));
            }

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

            int i = 0;
            foreach (var book in books.Values)
            {
                message.AppendLine($"{++i}. {book.Title} by {book.Author}");
            }

            return CreateLibraryOperationResult(true, message: message.ToString());
        }

        public LibraryOperationResult RemoveBook(string title)
        {
            var bookToRemove = books.FirstOrDefault(b => b.Value.Title == title).Value;
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove.Title);
                return CreateLibraryOperationResult(true, message: string.Format(BookRemovedMessage, title));
            }
            else
            {
                return CreateLibraryOperationResult(false, LibraryError.BookNotFound, string.Format(BookNotFoundMessage, title));
            }
        }

        public LibraryOperationResult FindBook(string title)
        {
            var book = books.FirstOrDefault(b => b.Value.Title == title).Value;
            if (book != null)
            {
                return CreateLibraryOperationResult(true, message: book.Title);
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

            return books.FirstOrDefault(b => b.Value.Title == title).Value;
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
