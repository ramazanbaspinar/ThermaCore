using AutoMapper;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Application.Mappings.Definitions
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

