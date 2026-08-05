using System;
using System.Linq;
using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Application.Services.Management;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using Microsoft.Extensions.DependencyInjection;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TerminalForms
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
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.TerminalYonetimi;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
            HideItems = new DevExpress.XtraBars.BarItem[] { btnYeni };
            if (Tablo != null)
            {
                Tablo.PopupMenuShowing += Tablo_PopupMenuShowing;
            }
        }

        private void Tablo_PopupMenuShowing(object? sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var rowHandle = e.HitInfo.RowHandle;
                if (rowHandle < 0) return;

                bool isActive = true;
                if (Tablo.GetRowCellValue(rowHandle, "IsActive") != null)
                {
                    isActive = (bool)Tablo.GetRowCellValue(rowHandle, "IsActive");
                }

                string menuText = isActive ? "Pasife Çek" : "Aktife Çek";

                DevExpress.Utils.Menu.DXMenuItem menuItem = new DevExpress.Utils.Menu.DXMenuItem(menuText, (s, args) =>
                {
                    long entityId = 0;
                    long.TryParse(Tablo.GetRowCellValue(rowHandle, "Id")?.ToString(), out entityId);
                    if (entityId > 0)
                    {
                        var terminal = _terminalService.GetById(entityId);
                        if (terminal != null)
                        {
                            try
                            {
                                terminal.IsActive = !isActive;
                                _terminalService.Update(terminal);
                                Listele();
                            }
                            catch (FluentValidation.ValidationException ex)
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show(
                                    string.Join("\n", ex.Errors.Select(e => e.ErrorMessage)), 
                                    "Lisans Uyarısı", 
                                    System.Windows.Forms.MessageBoxButtons.OK, 
                                    System.Windows.Forms.MessageBoxIcon.Warning);
                            }
                            catch (Exception ex)
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Hata", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            }
                        }
                    }
                });

                e.Menu?.Items.Add(menuItem);
            }
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
