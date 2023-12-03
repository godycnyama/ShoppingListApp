namespace ShoppingListApp.Application.Exceptions;
public class ShoppingListNotFoundException : Exception
{
    public ShoppingListNotFoundException()
    {
    }

    public ShoppingListNotFoundException(string message)
        : base($"Shopping list with id: {message} not found")
    {
    }

    public ShoppingListNotFoundException(string message, Exception inner)
        : base($"Shopping list with id: {message} not found", inner)
    {
    }
}