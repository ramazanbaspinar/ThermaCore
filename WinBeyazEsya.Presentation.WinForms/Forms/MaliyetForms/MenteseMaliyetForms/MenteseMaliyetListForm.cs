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

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MenteseMaliyetForms
{
    public partial class MenteseMaliyetListForm : BaseMaliyetListForm
    {
        public MenteseMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.MenteseMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<MenteseMaliyetEditForm>();
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
            var menteseService = Program.ServiceProvider.GetService<WinBeyazEsya.Application.Interfaces.Definitions.IHingeService>();
            if (menteseService != null)
            {
                var menteseler = menteseService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var mentese = menteseler.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (mentese != null)
                    {
                        item.MaterialName = mentese.Name;
                    }
                }
            }
        }
    }
}
