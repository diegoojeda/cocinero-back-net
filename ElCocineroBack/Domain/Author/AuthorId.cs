using ElCocineroBack.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ElCocineroBack.Domain.Author
{
    [Owned]
    public class AuthorId : Identity
    {
        public AuthorId()
        {
        }

        public AuthorId(string id) : base(id)
        {
        }

        public static implicit operator string(AuthorId item)
        {
            return item.Id;
        }

        public static implicit operator AuthorId(string value)
        {
            return new AuthorId(value);
        }
    }
}