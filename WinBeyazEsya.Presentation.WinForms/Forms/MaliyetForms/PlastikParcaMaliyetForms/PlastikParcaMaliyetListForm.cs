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
using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.PlastikParcaMaliyetForms
{
    public partial class PlastikParcaMaliyetListForm : BaseMaliyetListForm
    {
        public PlastikParcaMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.PlastikParcaMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<PlastikParcaMaliyetEditForm>();
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
            var plastikParcaService = Program.ServiceProvider.GetService<WinBeyazEsya.Application.Interfaces.Definitions.IPlasticPartService>();
            if (plastikParcaService != null)
            {
                var parcalar = plastikParcaService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var parca = parcalar.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (parca != null)
                    {
                        item.MaterialName = parca.Name;
                    }
                }
            }
        }
    }
}
