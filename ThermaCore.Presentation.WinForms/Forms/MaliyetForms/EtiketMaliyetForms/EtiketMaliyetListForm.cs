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
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.MaliyetForms.EtiketMaliyetForms
{
    public partial class EtiketMaliyetListForm : BaseMaliyetListForm
    {
        public EtiketMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.EtiketMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<EtiketMaliyetEditForm>();
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

        protected override void MalzemeAdlariniDoldur(IEnumerable<ThermaCore.Application.DTOs.Production.MaterialCostListDto> liste)
        {
            var etiketService = Program.ServiceProvider.GetService<ThermaCore.Application.Interfaces.Definitions.IProductLabelService>();
            if (etiketService != null)
            {
                var etiketler = etiketService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var etiket = etiketler.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (etiket != null)
                    {
                        item.MaterialName = etiket.Name;
                    }
                }
            }
        }
    }
}