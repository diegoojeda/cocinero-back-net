namespace ElCocineroBack.Domain.Author.Exceptions
{
    public class AuthorNotFoundException : DomainException
    {
        public AuthorNotFoundException(string authorId) : base($"Author with ID: {authorId} not found")
        {
        }
    }
}