using Microsoft.EntityFrameworkCore;

namespace ElCocineroBack.Domain.ValueObjects
{
    [Owned]
    public class NonNullString
    {
        private string value { get; }

        public NonNullString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new EmptyValueException();
            }

            this.value = value;
        }

        public static implicit operator string(NonNullString value)
        {
            return value.value;
        }
    }

    public class EmptyValueException : DomainException
    {
        public EmptyValueException() : base("Mandatory value is not provided")
        {
        }
    }
}