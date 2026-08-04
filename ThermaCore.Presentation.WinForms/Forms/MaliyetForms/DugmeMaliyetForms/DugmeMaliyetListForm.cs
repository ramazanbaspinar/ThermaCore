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

namespace ThermaCore.Presentation.WinForms.Forms.MaliyetForms.DugmeMaliyetForms
{
    public partial class DugmeMaliyetListForm : BaseMaliyetListForm
    {
        public DugmeMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.DugmeMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<DugmeMaliyetEditForm>();
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
            var dugmeService = Program.ServiceProvider.GetService<ThermaCore.Application.Interfaces.Production.IKnobService>();
            if (dugmeService != null)
            {
                var dugmeler = dugmeService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var dugme = dugmeler.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (dugme != null)
                    {
                        item.MaterialName = dugme.Name;
                    }
                }
            }
        }
    }
}