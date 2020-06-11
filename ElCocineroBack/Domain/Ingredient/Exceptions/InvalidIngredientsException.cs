namespace ElCocineroBack.Domain.Ingredient.Exceptions
{
    public class InvalidIngredientsException: DomainException
    {
        public InvalidIngredientsException() : base("Any of the ingredients provided is incorrect")
        {
        }
    }
}