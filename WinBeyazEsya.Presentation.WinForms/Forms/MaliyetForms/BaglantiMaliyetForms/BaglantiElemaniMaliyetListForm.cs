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

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.BaglantiMaliyetForms
{
    public partial class BaglantiElemaniMaliyetListForm : BaseMaliyetListForm
    {
        public BaglantiElemaniMaliyetListForm()
        {
            InitializeComponent();
            BaseKartTuru = ModuleType.BaglantiElemaniMaliyetleri;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<BaglantiElemaniMaliyetEditForm>();
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
            var baglantiElemaniService = Program.ServiceProvider.GetService<WinBeyazEsya.Application.Interfaces.Definitions.IFastenerService>();
            if (baglantiElemaniService != null)
            {
                var baglantiElemanlari = baglantiElemaniService.GetAll().ToList();
                foreach (var item in liste)
                {
                    var baglantiElemani = baglantiElemanlari.FirstOrDefault(x => x.Id == item.MaterialId);
                    if (baglantiElemani != null)
                    {
                        item.MaterialName = baglantiElemani.Name;
                    }
                }
            }
        }
    }
}
