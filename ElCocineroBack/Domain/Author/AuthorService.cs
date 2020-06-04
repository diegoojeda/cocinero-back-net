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

        public async Task<AuthorResponseDto> SaveAsync(Author author)
        {
            var inserted = await _authorRepository.AddAsync(author);
            await _unitOfWork.CompleteAsync();

            return inserted;
        }
    }
}