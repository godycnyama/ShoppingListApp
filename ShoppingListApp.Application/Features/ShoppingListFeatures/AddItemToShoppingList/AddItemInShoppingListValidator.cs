using FluentValidation;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.AddItemToShoppingList;
public sealed class AddItemToShoppingListValidator : AbstractValidator<AddItemToShoppingListRequest>
{
    public AddItemToShoppingListValidator()
    {
        RuleFor(x => x.ShoppingListID).NotEmpty();
        RuleFor(x => x.UserName).NotEmpty().EmailAddress();
        RuleFor(x => x.ShoppingItemDTO.Name).NotNull();
        RuleFor(x => x.ShoppingItemDTO.Quantity).NotNull();
        RuleFor(x => x.ShoppingItemDTO.Cost).NotNull();
        RuleFor(x => x.ShoppingItemDTO.Currency).NotNull();
    }
}