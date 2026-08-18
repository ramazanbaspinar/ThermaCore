using Microsoft.Extensions.DependencyInjection;
using System.Text;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Interfaces.System;
using WinBeyazEsya.Domain.Entities.System;

namespace WinBeyazEsya.Infrastructure.Services.System;

public class LayoutService : ILayoutService
{
    private readonly IServiceProvider _serviceProvider;

    public LayoutService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void SaveLayout(long kullaniciId, string formAdi, string kontrolAdi, string xmlData)
    {
        try
        {
            using var scope = _serviceProvider.CreateScope();
            var repo = scope.ServiceProvider.GetRequiredService<IMasterRepository<UserInterfaceTemplate>>();
            var uow = scope.ServiceProvider.GetRequiredService<IMasterUnitOfWork>();

            // Guardrail 2: UTF-8 Base64 Conversion to prevent Stream Closed / Data Loss
            var bytes = Encoding.UTF8.GetBytes(xmlData);
            string base64Xml = Convert.ToBase64String(bytes);

            var template = repo.Find(x => x.UserId == kullaniciId && x.FormName == formAdi && x.ControlName == kontrolAdi).FirstOrDefault();

            if (template == null)
            {
                template = new UserInterfaceTemplate
                {
                    Id = WinBeyazEsya.Domain.Helpers.IdGenerator.GenerateId(),
                    UserId = kullaniciId,
                    FormName = formAdi,
                    ControlName = kontrolAdi,
                    Code = $"{formAdi}_{kontrolAdi}",
                    XmlData = base64Xml,
                    IsActive = true
                };
                repo.Add(template);
            }
            else
            {
                template.XmlData = base64Xml;
                repo.Update(template);
            }

            uow.SaveChanges();
        }
        catch
        {
            // Logging can be added here
        }
    }

    public string GetLayout(long kullaniciId, string formAdi, string kontrolAdi)
    {
        try
        {
            using var scope = _serviceProvider.CreateScope();
            var repo = scope.ServiceProvider.GetRequiredService<IMasterRepository<UserInterfaceTemplate>>();

            var template = repo.Find(x => x.UserId == kullaniciId && x.FormName == formAdi && x.ControlName == kontrolAdi).FirstOrDefault();

            if (template != null && !string.IsNullOrEmpty(template.XmlData))
            {
                // Decode Base64 to UTF-8 XML string
                var bytes = Convert.FromBase64String(template.XmlData);
                return Encoding.UTF8.GetString(bytes);
            }
        }
        catch
        {
            // Logging can be added here
        }

        return string.Empty;
    }

    public void DeleteLayout(long kullaniciId, string formAdi, string kontrolAdi)
    {
        try
        {
            using var scope = _serviceProvider.CreateScope();
            var repo = scope.ServiceProvider.GetRequiredService<IMasterRepository<UserInterfaceTemplate>>();
            var uow = scope.ServiceProvider.GetRequiredService<IMasterUnitOfWork>();

            var template = repo.Find(x => x.UserId == kullaniciId && x.FormName == formAdi && x.ControlName == kontrolAdi).FirstOrDefault();
            if (template != null)
            {
                repo.Remove(template);
                uow.SaveChanges();
            }
        }
        catch
        {
            // Logging can be added here
        }
    }
}

