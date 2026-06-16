using AutoMapper;
using FluentValidation;
using ThermaCore.Application.DTOs.Yonetim;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Services.Base;
using ThermaCore.Domain.Entities.Yonetim;

namespace ThermaCore.Application.Services.Yonetim;

public class KullaniciRoluManager : BaseMasterManager<KullaniciRoluListDto, KullaniciRoluDto, KullaniciRolu>, IKullaniciRoluService
{
    public KullaniciRoluManager(
        IMapper mapper, 
        IMasterRepository<KullaniciRolu> repository, 
        IMasterUnitOfWork unitOfWork, 
        IValidator<KullaniciRoluDto> validator) 
        : base(mapper, repository, unitOfWork, validator)
    {
    }
}
