using Microsoft.Extensions.DependencyInjection;
using System.Data;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MekanikVeHirdavatGrubuMForms
{
    public partial class MekanikVeHirdavatGrubuMListForm : BaseMaliyetListForm
    {
        private readonly IMechanicalAndHardwareGroupService _mechanicalAndHardwareGroupService;
        private readonly IServiceProvider _serviceProvider;

        public MekanikVeHirdavatGrubuMListForm(
            IMechanicalAndHardwareGroupService mechanicalAndHardwareGroupService,
            IServiceProvider serviceProvider, WinBeyazEsya.Application.Interfaces.Production.IMaterialCostService materialCostService) : base(serviceProvider, materialCostService)
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.MekanikVeHirdavatGrubuMaliyetleri;
            _mechanicalAndHardwareGroupService = mechanicalAndHardwareGroupService;
            _serviceProvider = serviceProvider;
        }

        protected override void ShowEditForm(long id)
        {
            var form = _serviceProvider.GetRequiredService<MekanikVeHirdavatGrubuMEditForm>();
            if (form != null)
            {
                form.IdAtaVeAc(id);
                Listele();
                if (form.Id > 0)
                {
                    Tablo.RowFocus("Id", form.Id);
                }
            }
        }

        protected override void MalzemeAdlariniDoldur(IEnumerable<WinBeyazEsya.Application.DTOs.Production.MaterialCostListDto> liste)
        {
            if (_mechanicalAndHardwareGroupService != null)
            {
                var requiredIds = liste.Select(x => x.MaterialId).Distinct().ToList();
                var malzemeler = System.Linq.Enumerable.ToList(System.Linq.Queryable.Where(System.Linq.Queryable.AsQueryable(_mechanicalAndHardwareGroupService.GetAll()), x => requiredIds.Contains(x.Id)));
                foreach (var item in liste)
                {
                    var malzeme = malzemeler.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (malzeme != null)
                    {
                        item.MaterialName = malzeme.Name;
                    }
                }
            }
        }
    }
}



