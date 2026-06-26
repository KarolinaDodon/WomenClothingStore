using FluentValidation;
using WomenClothingStore.Domain.Entities;

namespace WomenClothingStore.Web.Validators;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Название обязательно")
            .MaximumLength(150).WithMessage("Название не должно превышать 150 символов");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Цена должна быть больше 0");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Описание не должно превышать 1000 символов");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("Категория обязательна");
    }
}