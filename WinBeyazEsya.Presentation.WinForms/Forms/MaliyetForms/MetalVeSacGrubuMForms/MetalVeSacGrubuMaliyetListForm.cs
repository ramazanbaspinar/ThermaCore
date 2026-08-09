using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Application.Interfaces.Definitions;
using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MetalVeSacGrubuMForms
{
    public partial class MetalVeSacGrubuMaliyetListForm : BaseMaliyetListForm
    {
        private readonly IMetalSheetGroupService _metalSheetGroupService;
        private readonly IServiceProvider _serviceProvider;

        public MetalVeSacGrubuMaliyetListForm(
            IMetalSheetGroupService metalSheetGroupService,
            IServiceProvider serviceProvider, WinBeyazEsya.Application.Interfaces.Production.IMaterialCostService materialCostService) : base(serviceProvider, materialCostService)
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.MetalVeSacGrubuMaliyetleri;
            _metalSheetGroupService = metalSheetGroupService;
            _serviceProvider = serviceProvider;
        }

        protected override void ShowEditForm(long id)
        {
            var form = _serviceProvider.GetRequiredService<MetalVeSacGrubuMaliyetEditForm>();
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
            if (_metalSheetGroupService != null)
            {
                var requiredIds = liste.Select(x => x.MaterialId).Distinct().ToList();
                var malzemeler = System.Linq.Enumerable.ToList(System.Linq.Queryable.Where(System.Linq.Queryable.AsQueryable(_metalSheetGroupService.GetAll()), x => requiredIds.Contains(x.Id)));
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



