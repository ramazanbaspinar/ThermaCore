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

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.ElektrikVeElektronikGrubuMForms
{
    public partial class ElektrikVeElektronikGrubuMListForm : BaseMaliyetListForm
    {
        private readonly IElectricalElectronicGroupService _electricalElectronicGroupService;
        private readonly IServiceProvider _serviceProvider;

        public ElektrikVeElektronikGrubuMListForm(
            IElectricalElectronicGroupService electricalElectronicGroupService,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.ElektrikVeElektronikGrubuMaliyetleri;
            _electricalElectronicGroupService = electricalElectronicGroupService;
            _serviceProvider = serviceProvider;
        }

        protected override void ShowEditForm(long id)
        {
            var form = _serviceProvider.GetRequiredService<ElektrikVeElektronikGrubuMEditForm>();
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
            if (_electricalElectronicGroupService != null)
            {
                var malzemeler = _electricalElectronicGroupService.GetAll().ToList();
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