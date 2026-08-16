using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Application.Validators.Definitions
{
    public class ProductRecipeValidator : AbstractValidator<ProductRecipeDto>
    {
        public ProductRecipeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Reçete adı boş olamaz.");

            RuleFor(x => x.FinishedGoodId)
                .GreaterThan(0).WithMessage("Geçerli bir mamül seçilmelidir.");
        }
    }
}
