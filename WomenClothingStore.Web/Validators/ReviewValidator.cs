using FluentValidation;

using WomenClothingStore.Domain.Entities;

namespace WomenClothingStore.Web.Validators;

public class ReviewValidator : AbstractValidator<Review>
{
    public ReviewValidator()
    {
        RuleFor(x => x.AuthorName)
            .NotEmpty().WithMessage("Укажите ваше имя")
            .MaximumLength(100).WithMessage("Имя не должно превышать 100 символов");

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5).WithMessage("Оценка должна быть от 1 до 5");

        RuleFor(x => x.Comment)
            .NotEmpty().WithMessage("Напишите текст отзыва")
            .MinimumLength(10).WithMessage("Отзыв должен быть не короче 10 символов")
            .MaximumLength(1000).WithMessage("Отзыв не должен превышать 1000 символов");
    }
}