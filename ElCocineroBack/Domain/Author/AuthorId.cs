using System.ComponentModel.DataAnnotations.Schema;
using ElCocineroBack.Domain.ValueObjects;

namespace ElCocineroBack.Domain.Author
{
    [ComplexType]
    public class AuthorId: Identity
    {
        public AuthorId()
        {
        }

        public AuthorId(string id) : base(id)
        {
        }
    }
}