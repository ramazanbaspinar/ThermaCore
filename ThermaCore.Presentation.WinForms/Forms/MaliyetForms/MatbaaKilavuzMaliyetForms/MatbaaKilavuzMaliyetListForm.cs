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

namespace ThermaCore.Presentation.WinForms.Forms.MaliyetForms.MatbaaKilavuzMaliyetForms
{
    public partial class MatbaaKilavuzMaliyetListForm : BaseMaliyetListForm
    {
        public MatbaaKilavuzMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.MatbaaKilavuzMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<MatbaaKilavuzMaliyetEditForm>();
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
            var matbaaService = Program.ServiceProvider.GetService<ThermaCore.Application.Interfaces.Definitions.IManualService>();
            if (matbaaService != null)
            {
                var matbaalar = matbaaService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var matbaa = matbaalar.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (matbaa != null)
                    {
                        item.MaterialName = matbaa.Name;
                    }
                }
            }
        }
    }
}