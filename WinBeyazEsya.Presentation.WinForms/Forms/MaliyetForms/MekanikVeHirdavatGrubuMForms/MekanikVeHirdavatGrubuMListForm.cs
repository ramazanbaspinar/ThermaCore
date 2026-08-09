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

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MekanikVeHirdavatGrubuMForms
{
    public partial class MekanikVeHirdavatGrubuMListForm : BaseMaliyetListForm
    {
        private readonly IMechanicalAndHardwareGroupService _mechanicalAndHardwareGroupService;
        private readonly IServiceProvider _serviceProvider;

        public MekanikVeHirdavatGrubuMListForm(
            IMechanicalAndHardwareGroupService mechanicalAndHardwareGroupService,
            IServiceProvider serviceProvider)
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
                var malzemeler = _mechanicalAndHardwareGroupService.GetAll().ToList();
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