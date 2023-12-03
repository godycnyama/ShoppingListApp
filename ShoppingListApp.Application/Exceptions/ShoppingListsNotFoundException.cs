namespace ShoppingListApp.Application.Exceptions;
public class ShoppingListsNotFoundException : Exception
{
    public ShoppingListsNotFoundException()
    {
    }

    public ShoppingListsNotFoundException(string message = "No shopping list records found")
        : base(message)
    {
    }

    public ShoppingListsNotFoundException(Exception inner, string message = "No shopping list records found")
        : base(message, inner)
    {
    }
}