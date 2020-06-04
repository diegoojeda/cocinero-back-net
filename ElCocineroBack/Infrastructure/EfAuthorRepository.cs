using System;
using System.Threading.Tasks;
using ElCocineroBack.Domain.Author;

namespace ElCocineroBack.Infrastructure
{
    public class EfAuthorRepository : BaseRepository, IAuthorRepository
    {
        public EfAuthorRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Author> AddAsync(Author author)
        {
            var inserted = await _context.Authors.AddAsync(author.State);
            return new Author(inserted.Entity);
        }
    }
}