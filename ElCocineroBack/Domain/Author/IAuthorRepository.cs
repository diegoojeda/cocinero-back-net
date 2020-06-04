using System;
using System.Threading.Tasks;

namespace ElCocineroBack.Domain.Author
{
    public interface IAuthorRepository
    {
        Task<Author> AddAsync(Author author);
    }
}