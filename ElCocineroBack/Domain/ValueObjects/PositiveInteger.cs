using System;

namespace ElCocineroBack.Domain.ValueObjects
{
    public class PositiveInteger
    {
        public int Value { get; }

        public PositiveInteger(int value)
        {
            if (value < 0)
            {
                throw new NegativeValueException();
            }

            Value = value;
        }

        public static implicit operator PositiveInteger(int integer)
        {
            return new PositiveInteger(integer);
        }

        public static implicit operator int(PositiveInteger positiveInteger)
        {
            return positiveInteger.Value;
        }
    }

    public class NegativeValueException : Exception
    {
        public NegativeValueException() : base("A negative value was provided when a positive one was expected")
        {
        }
    }
}