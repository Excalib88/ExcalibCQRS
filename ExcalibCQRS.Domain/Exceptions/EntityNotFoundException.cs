namespace ExcalibCQRS.Domain.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string message = "Entity not found") : base(message)
    {
    }
}