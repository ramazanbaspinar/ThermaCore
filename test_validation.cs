using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Validations.Definitions;
using WinBeyazEsya.Application;
using WinBeyazEsya.Infrastructure;
using WinBeyazEsya.Infrastructure.Persistence.Repositories.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories.Definitions;
using Microsoft.EntityFrameworkCore;
using WinBeyazEsya.Infrastructure.Persistence;

class Program {
    static void Main() {
        var services = new ServiceCollection();
        services.AddApplicationServices();
        services.AddDbContext<WinBeyazEsyaTenantContext>(options => options.UseInMemoryDatabase("TestDb"));
        services.AddScoped<IUnitRepository, UnitRepository>();
        
        var provider = services.BuildServiceProvider();
        
        var dto = new UnitDto();
        var type = typeof(IValidator<>).MakeGenericType(dto.GetType());
        var validator = provider.GetService(type) as IValidator;
        
        Console.WriteLine("Validator is null? " + (validator == null));
        if (validator != null) {
            Console.WriteLine("Validator type: " + validator.GetType().Name);
            
            var context = new ValidationContext<object>(dto);
            var result = validator.Validate(context);
            Console.WriteLine("IsValid: " + result.IsValid);
            foreach(var e in result.Errors) {
                Console.WriteLine("Error: " + e.ErrorMessage);
            }
        }
    }
}

