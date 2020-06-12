using System;
using System.Threading.Tasks;
using ElCocineroBack.Controllers;

namespace ElCocineroBack.Domain.Author
{
    public class AuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IAuthorRepository authorRepository, IUnitOfWork unitOfWork
        )
        {
            this._authorRepository = authorRepository;
            this._unitOfWork = unitOfWork;
        }

        public Author Find(AuthorId authorId)
        {
            return _authorRepository.Find(authorId);
        }

        public Author SaveAsync(Author author)
        {
            var inserted = _authorRepository.Add(author);
            _unitOfWork.Complete();

            return inserted;
        }

        public bool Any(string authorId)
        {
            return _authorRepository.Any(authorId);
        }
    }
}