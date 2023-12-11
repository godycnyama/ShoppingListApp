using FluentValidation;

namespace ShoppingListApp.Application.Features.ShoppingListFeatures.AddShoppingItemPhoto;
public sealed class AddShoppingItemPhotoValidator : AbstractValidator<AddShoppingItemPhotoRequest>
{
    public AddShoppingItemPhotoValidator()
    {
        RuleFor(x => x.ShoppingListID).NotEmpty();
        RuleFor(x => x.ItemID).NotEmpty();
        RuleFor(x => x.UserName).NotEmpty().EmailAddress();
        RuleFor(x => x.File).NotNull();
    }
}