using FluentValidation;
using System;

namespace WinBeyazEsya.Application.Validations;

public static class ValidationTool
{
    public static void Validate<TValidator, TEntity>(TValidator validator, TEntity entity)
        where TValidator : IValidator<TEntity>
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        var context = new ValidationContext<TEntity>(entity);
        var result = validator.Validate(context);

        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }
    }
}

