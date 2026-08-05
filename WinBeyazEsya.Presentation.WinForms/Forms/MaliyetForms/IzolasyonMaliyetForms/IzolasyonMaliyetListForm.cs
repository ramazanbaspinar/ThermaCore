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

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.IzalasyonMaliyetForms
{
    public partial class IzolasyonMaliyetListForm : BaseMaliyetListForm
    {
        public IzolasyonMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.IzolasyonMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<IzolasyonMaliyetEditForm>();
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
            var izolasyonService = Program.ServiceProvider.GetService<WinBeyazEsya.Application.Interfaces.Definitions.IInsulationService>();
            if (izolasyonService != null)
            {
                var izolasyonlar = izolasyonService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var izolasyon = izolasyonlar.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (izolasyon != null)
                    {
                        item.MaterialName = izolasyon.Name;
                    }
                }
            }
        }
    }
}
