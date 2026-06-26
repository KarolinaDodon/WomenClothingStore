using FluentValidation;

using WomenClothingStore.Domain.Entities;

namespace WomenClothingStore.Web.Validators;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(x => x.CustomerName)
            .NotEmpty().WithMessage("Укажите ваше имя")
            .MaximumLength(100).WithMessage("Имя не должно превышать 100 символов");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Укажите номер телефона")
            .Matches(@"^[\d\+\-\(\)\s]{7,20}$").WithMessage("Введите корректный номер телефона");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Укажите адрес доставки")
            .MaximumLength(300).WithMessage("Адрес не должен превышать 300 символов");
    }
}