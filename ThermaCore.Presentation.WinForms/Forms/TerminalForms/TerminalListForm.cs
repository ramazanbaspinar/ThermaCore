using System;
using System.Linq;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Services.Management;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using Microsoft.Extensions.DependencyInjection;

namespace ThermaCore.Presentation.WinForms.Forms.TerminalForms
{
    public partial class TerminalListForm : BaseListForm
    {
        private readonly ITerminalService _terminalService = default!;

        public TerminalListForm()
        {
            InitializeComponent();
        }

        public TerminalListForm(ITerminalService terminalService)
        {
            InitializeComponent();
            _terminalService = terminalService;
            Bll = terminalService;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = ThermaCore.Domain.Enums.ModuleType.Terminal;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = _terminalService.GetAll().Where(x => x.IsActive == AktifKartlariGoster).ToList();
        }

        protected override void ShowEditForm(long id)
        {
            using (var form = Program.ServiceProvider.GetRequiredService<TerminalEditForm>())
            {
                form.IdAtaVeAc(id);
                if (form.RefreshYapilacak && !EklenebilecekEntityVar)
                {
                    Listele();
                }
            }
        }

        protected override void EntityDelete()
        {
            if (Tablo.FocusedRowHandle < 0) return;

            long entityId = 0;
            long.TryParse(Tablo.GetFocusedRowCellValue("Id")?.ToString(), out entityId);
            
            if (entityId <= 0) return;

            if (DevExpress.XtraEditors.XtraMessageBox.Show("Seçili terminal kaydını silmek istediğinize emin misiniz?", "Onay", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    _terminalService.Delete(entityId);
                    Listele();
                }
                catch (Exception ex)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Hata", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        }
    }
}