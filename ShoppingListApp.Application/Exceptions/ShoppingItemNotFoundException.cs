namespace ShoppingItemApp.Application.Exceptions;
public class ShoppingItemNotFoundException : Exception
{
    public ShoppingItemNotFoundException()
    {
    }

    public ShoppingItemNotFoundException(string message)
        : base($"Shopping item with id: {message} not found")
    {
    }

    public ShoppingItemNotFoundException(string message, Exception inner)
        : base($"Shopping item with id: {message} not found", inner)
    {
    }
}