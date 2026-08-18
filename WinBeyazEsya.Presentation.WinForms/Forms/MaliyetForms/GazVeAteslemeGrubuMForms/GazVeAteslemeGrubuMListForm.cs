using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.GazVeAteslemeGrubuMForms
{
    public partial class GazVeAteslemeGrubuMListForm : BaseMaliyetListForm
    {
        private readonly IGasAndIgnitionGroupService _gasAndIgnitionGroupService;
        private readonly IServiceProvider _serviceProvider;

        public GazVeAteslemeGrubuMListForm(
            IGasAndIgnitionGroupService gasAndIgnitionGroupService,
            IServiceProvider serviceProvider, WinBeyazEsya.Application.Interfaces.Production.IMaterialCostService materialCostService) : base(serviceProvider, materialCostService)
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.GazVeAteslemeGrubuMaliyetleri;
            _gasAndIgnitionGroupService = gasAndIgnitionGroupService;
            _serviceProvider = serviceProvider;
        }

        protected override void ShowEditForm(long id)
        {
            var form = _serviceProvider.GetRequiredService<GazVeAteslemeGrubuMEditForm>();
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
            if (_gasAndIgnitionGroupService != null)
            {
                var malzemeler = _gasAndIgnitionGroupService.GetAll().ToList();
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



