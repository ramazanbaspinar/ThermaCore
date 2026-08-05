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

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.DugmeMaliyetForms
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

        protected override void MalzemeAdlariniDoldur(IEnumerable<WinBeyazEsya.Application.DTOs.Production.MaterialCostListDto> liste)
        {
            var dugmeService = Program.ServiceProvider.GetService<WinBeyazEsya.Application.Interfaces.Production.IKnobService>();
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
