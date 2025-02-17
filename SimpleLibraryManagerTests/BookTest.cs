namespace SimpleLibraryManagerTests;

using SimpleLibraryManagerLib;
using Xunit;

public class BookTest
{
    [Fact]
    public void Book_ShouldHaveCorrectTitleAndAuthor()
    {
        // Arrange
        var title = "The Great Gatsby";
        var author = "F. Scott Fitzgerald";

        // Act
        var book = new Book(title, author);

        // Assert
        Assert.Equal(title, book.Title);
        Assert.Equal(author, book.Author);
    }

    [Fact]
    public void Book_Title_ShouldBeSettable()
    {
        // Arrange
        var book = new Book("Old Title", "Author");

        // Act
        book.Title = "New Title";

        // Assert
        Assert.Equal("New Title", book.Title);
    }

    [Fact]
    public void Book_Author_ShouldBeSettable()
    {
        // Arrange
        var book = new Book("Title", "Old Author");

        // Act
        book.Author = "New Author";

        // Assert
        Assert.Equal("New Author", book.Author);
    }
}
