using System;
using System.Threading.Tasks;

namespace ElCocineroBack.Domain.Author
{
    public interface IAuthorRepository
    {
        Task<Author> FindAsync(AuthorId authorId);
        Task<Author> AddAsync(Author author);
        Task<bool> Any(string authorId);
    }
}