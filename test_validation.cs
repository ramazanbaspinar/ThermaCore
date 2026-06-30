using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Validations.Definitions;
using ThermaCore.Application;
using ThermaCore.Infrastructure;
using ThermaCore.Infrastructure.Persistence.Repositories.Definitions;
using ThermaCore.Application.Interfaces.Repositories.Definitions;
using Microsoft.EntityFrameworkCore;
using ThermaCore.Infrastructure.Persistence;

class Program {
    static void Main() {
        var services = new ServiceCollection();
        services.AddApplicationServices();
        services.AddDbContext<ThermaCoreTenantContext>(options => options.UseInMemoryDatabase("TestDb"));
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
