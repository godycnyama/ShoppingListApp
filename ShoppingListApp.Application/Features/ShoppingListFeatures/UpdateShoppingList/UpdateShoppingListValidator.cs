using FluentValidation;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.UpdateShoppingList;
public sealed class UpdateShoppingListValidator : AbstractValidator<UpdateShoppingListRequest>
{
    public UpdateShoppingListValidator()
    {
        RuleFor(x => x.ShoppingListID).NotEmpty();
        RuleFor(x => x.UserName).NotEmpty().EmailAddress();
        RuleFor(x => x.Month).NotEmpty();
        RuleFor(x => x.Year).NotEmpty();
        RuleForEach(x => x.ShoppingItems).ChildRules(item =>
        {
            item.RuleFor(x => x.Name).NotEmpty();
            item.RuleFor(x => x.Quantity).NotEmpty();
            item.RuleFor(x => x.Cost).NotEmpty();
            item.RuleFor(x => x.Currency).NotEmpty();
        });
    }
}