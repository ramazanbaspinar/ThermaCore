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
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MotorMaliyetForms
{
    public partial class MotorMaliyetListForm : BaseMaliyetListForm
    {
        public MotorMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.MotorMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<MotorMaliyetEditForm>();
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
            var motorService = Program.ServiceProvider.GetService<IOvenMotorService>();
            if (motorService != null)
            {
                var motorlar = motorService.GetAllList().ToList();
                foreach (var item in liste)
                {
                    var motor = motorlar.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (motor != null)
                    {
                        item.MaterialName = motor.Name;
                    }
                }
            }
        }
    }
}
