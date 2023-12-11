using FluentValidation;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.CreateShoppingList;
public sealed class CreateShoppingListValidator : AbstractValidator<CreateShoppingListRequest>
{
    public CreateShoppingListValidator()
    {
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