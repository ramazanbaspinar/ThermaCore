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

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.PlastikVeGorselAksamGrubuMForms
{
    public partial class PlastikVeGorselAksamGrubuMListForms : BaseMaliyetListForm
    {
        private readonly IPlasticAndVisualPartsGroupService _plasticAndVisualPartsGroupService;
        private readonly IServiceProvider _serviceProvider;

        public PlastikVeGorselAksamGrubuMListForms(
            IPlasticAndVisualPartsGroupService plasticAndVisualPartsGroupService,
            IServiceProvider serviceProvider, WinBeyazEsya.Application.Interfaces.Production.IMaterialCostService materialCostService) : base(serviceProvider, materialCostService)
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.PlastikVeGorselAksamGrubuMaliyetleri;
            _plasticAndVisualPartsGroupService = plasticAndVisualPartsGroupService;
            _serviceProvider = serviceProvider;
        }

        protected override void ShowEditForm(long id)
        {
            var form = _serviceProvider.GetRequiredService<PlastikVeGorselAksamGrubuMEditForm>();
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
            if (_plasticAndVisualPartsGroupService != null)
            {
                var requiredIds = liste.Select(x => x.MaterialId).Distinct().ToList();
                var malzemeler = System.Linq.Enumerable.ToList(System.Linq.Queryable.Where(System.Linq.Queryable.AsQueryable(_plasticAndVisualPartsGroupService.GetAll()), x => requiredIds.Contains(x.Id)));
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
