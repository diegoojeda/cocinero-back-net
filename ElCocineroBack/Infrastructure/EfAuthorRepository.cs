using System.Linq;
using System.Threading.Tasks;
using ElCocineroBack.Domain.Author;
using Microsoft.EntityFrameworkCore;

namespace ElCocineroBack.Infrastructure
{
    public class EfAuthorRepository : BaseRepository, IAuthorRepository
    {
        public EfAuthorRepository(AppDbContext context) : base(context)
        {
        }

        public Author Find(AuthorId authorId)
        {
            return _context.Authors.Find(authorId.Id);
        }

        public Author Add(Author author)
        {
            var inserted = _context.Authors.Add(author);
            return inserted.Entity;
        }

        public bool Any(string authorId)
        {
            return _context.Authors.Any(x => x.Id == authorId);
        }
    }
}