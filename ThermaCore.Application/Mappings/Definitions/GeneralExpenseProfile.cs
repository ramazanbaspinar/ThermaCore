using AutoMapper;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Application.Mappings.Definitions
{
    public class GeneralExpenseProfile : Profile
    {
        public GeneralExpenseProfile()
        {
            CreateMap<GeneralExpense, GeneralExpenseDto>().ReverseMap();
            CreateMap<GeneralExpense, GeneralExpenseListDto>().ReverseMap();
        }
    }
}
