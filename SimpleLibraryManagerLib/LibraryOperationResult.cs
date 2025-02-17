namespace SimpleLibraryManagerLib
{
    public class LibraryOperationResult
    {
        public bool Success { get; set; }
        public LibraryError Error { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}