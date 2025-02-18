using SimpleLibraryManagerLib;

namespace SimpleLibraryManager
{
    internal class SimpleLibraryManager
    {
        private const string AddBookPrompt = "Enter the title of the book to add: ";
        private const string AddAuthorPrompt = "Enter the author of the book to add: ";
        private const string RemoveBookPrompt = "Enter the name of the book to remove: ";
        private const string ChoicePrompt = "Enter your choice: ";
        private const string OptionPrompt = "Choose an option: (1) Add Book (2) Remove Book (3) Search Book (4) View Books (5) Exit";
        private const string EmptyInputMessage = "Book title and author cannot be empty.";
        private const string InvalidChoiceMessage = "Invalid choice. Please try again.";
        private const string AddBookOption = "1";
        private const string RemoveBookOption = "2";
        private const string SearchBookOption = "3";
        private const string ViewBooksOption = "4";
        private const string ExitOption = "5";

        public static string TakeUserInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine() ?? string.Empty;
        }

        public static void Main()
        {
            Library library = new(100);

            while (true)
            {
                Console.WriteLine(OptionPrompt);
                string choice = TakeUserInput(ChoicePrompt);

                switch (choice)
                {
                    case AddBookOption:
                        string bookToAdd = TakeUserInput(AddBookPrompt);
                        string authorToAdd = TakeUserInput(AddAuthorPrompt);
                        if (!ValidateBookTitle(bookToAdd) || !ValidateAuthor(authorToAdd))
                        {
                            Console.WriteLine(EmptyInputMessage);
                            break;
                        }
                        Book newBook = new(bookToAdd, authorToAdd);
                        Console.WriteLine(library.AddBook(newBook).Message);
                        break;
                    case RemoveBookOption:
                        string bookToRemove = TakeUserInput(RemoveBookPrompt);
                        if (!ValidateBookTitle(bookToRemove))
                        {
                            Console.WriteLine(EmptyInputMessage);
                            break;
                        }
                        Console.WriteLine(library.RemoveBook(bookToRemove).Message);
                        break;
                    case SearchBookOption:
                        string bookToSearch = TakeUserInput(RemoveBookPrompt);
                        if (!ValidateBookTitle(bookToSearch))
                        {
                            Console.WriteLine(EmptyInputMessage);
                            break;
                        }
                        Console.WriteLine(library.FindBook(bookToSearch).Message);
                        break;
                    case ViewBooksOption:
                        Console.WriteLine(library.ListBooks().Message);
                        break;
                    case ExitOption:
                        return;
                    default:
                        Console.WriteLine(InvalidChoiceMessage);
                        break;
                }
            }
        }


        private static bool ValidateBookTitle(string bookTitle)
        {
            return !string.IsNullOrEmpty(bookTitle);
        }

        private static bool ValidateAuthor(string author)
        {
            return !string.IsNullOrEmpty(author);
        }
    }
}
