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
}