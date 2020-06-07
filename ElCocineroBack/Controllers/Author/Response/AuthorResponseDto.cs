namespace ElCocineroBack.Controllers.Author.Response
{
    public class AuthorResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public AuthorResponseDto(string authorId, string authorName)
        {
            Id = authorId;
            Name = authorName;
        }
    }
}