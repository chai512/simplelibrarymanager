namespace SimpleLibraryManagerTests;

using SimpleLibraryManagerLib;
using Xunit;

public class LibraryTests
{
    private readonly Library library = new(10);

    [Fact]
    public void Library_ShouldAddBook()
    {
        // Arrange
        var book = new Book("1984", "George Orwell");

        // Act
        library.AddBook(book);

        // Assert
        Assert.NotNull(library.FindBookByTitle(book.Title));
    }

    [Fact]
    public void Library_ShouldRemoveBook()
    {
        // Arrange
        var book = new Book("1984", "George Orwell");
        library.AddBook(book);

        // Act
        library.RemoveBook(book.Title);

        // Assert
        Assert.Null(library.FindBookByTitle(book.Title));
    }

    [Fact]
    public void Library_ShouldFindBookByTitle()
    {
        // Arrange
        var book = new Book("1984", "George Orwell");
        library.AddBook(book);

        // Act
        var foundBook = library.FindBookByTitle("1984");

        // Assert
        Assert.Equal(book, foundBook);
    }

    [Fact]
    public void Library_ShouldReturnNullIfBookNotFound()
    {
        // Act
        var foundBook = library.FindBookByTitle("Nonexistent Book");

        // Assert
        Assert.Null(foundBook);
    }

    [Fact]
    public void Library_ShouldNotAddDuplicateBook()
    {
        // Arrange
        var book = new Book("1984", "George Orwell");
        library.AddBook(book);

        // Act
        var result = library.AddBook(book);

        // Assert
        Assert.False(result.Success);
    }

    [Fact]
    public void Library_ShouldNotRemoveNonexistentBook()
    {
        // Act
        var result = library.RemoveBook("Nonexistent Book");

        // Assert
        Assert.False(result.Success);
    }

    [Fact]
    public void Library_ShouldNotAddBookWhenFull()
    {
        // Arrange
        var fullLibrary = new Library(1);
        var book1 = new Book("1984", "George Orwell");
        var book2 = new Book("Brave New World", "Aldous Huxley");
        fullLibrary.AddBook(book1);

        // Act
        var result = fullLibrary.AddBook(book2);

        // Assert
        Assert.False(result.Success);
    }
}