using FluentValidation;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.UpdateItemInShoppingList;
public sealed class UpdateItemInShoppingListValidator : AbstractValidator<UpdateItemInShoppingListRequest>
{
    public UpdateItemInShoppingListValidator()
    {
        RuleFor(x => x.ShoppingListID).NotEmpty();
        RuleFor(x => x.ShoppingItemID).NotEmpty();
        RuleFor(x => x.UserName).NotEmpty().EmailAddress();
        RuleFor(x => x.ShoppingItemDTO.Name).NotNull();
        RuleFor(x => x.ShoppingItemDTO.Quantity).NotNull();
        RuleFor(x => x.ShoppingItemDTO.Cost).NotNull();
        RuleFor(x => x.ShoppingItemDTO.Currency).NotNull();
    }
}