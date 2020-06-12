using System;
using System.Threading.Tasks;

namespace ElCocineroBack.Domain.Author
{
    public interface IAuthorRepository
    {
        Author Find(AuthorId authorId);
        Author Add(Author author);
        bool Any(string authorId);
    }
}