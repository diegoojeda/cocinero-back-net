using System.ComponentModel.DataAnnotations.Schema;

namespace ElCocineroBack.Domain.ValueObjects
{
    [ComplexType]
    public class NonNullString
    {
        private string value { get; }

        public NonNullString()
        {
        }

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

        public static implicit operator NonNullString(string value)
        {
            return new NonNullString(value);
        }
        
    }

    public class EmptyValueException : DomainException
    {
        public EmptyValueException() : base("Mandatory value is not provided")
        {
        }
    }
}