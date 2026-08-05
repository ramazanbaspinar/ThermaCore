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

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.EmayeMaliyetForms
{
    public partial class EmayeMaliyetListForm : BaseMaliyetListForm
    {
        public EmayeMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.EmayeMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<EmayeMaliyetEditForm>();
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
            var emayeService = Program.ServiceProvider.GetService<WinBeyazEsya.Application.Interfaces.Production.IEmayeService>();
            if (emayeService != null)
            {
                var emayeler = emayeService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var emaye = emayeler.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (emaye != null)
                    {
                        item.MaterialName = emaye.Name;
                    }
                }
            }
        }
    }
}
