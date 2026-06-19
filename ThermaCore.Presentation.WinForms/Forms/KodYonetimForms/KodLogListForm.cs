using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Interfaces.System;
using ThermaCore.Application.Services.Management;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Enums;
using ThermaCore.Domain.Extensions;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;
using System;
using System.Windows.Forms;

namespace ThermaCore.Presentation.WinForms.Forms.KodYonetimForms
{
    public partial class KodLogListForm : BaseListForm
    {
        private readonly ICodeLogRepository _codeLogRepository;
        private readonly IBranchService _branchService;
        private readonly ICodeGenerationService _codeGenerationService;
        private ModuleType _module;
        private object _eskiDeger;

        public KodLogListForm()
        {
            InitializeComponent();
        }

        public KodLogListForm(ICodeLogRepository codeLogRepository, IBranchService branchService, ICodeGenerationService codeGenerationService)
        {
            InitializeComponent();
            _codeLogRepository = codeLogRepository;
            _branchService = branchService;
            _codeGenerationService = codeGenerationService;

            // Güvenlik: Admin olsalar dahi log silemezler veya yenisini ekleyemezler.
            HideItems = new DevExpress.XtraBars.BarItem[] { btnYeni, btnSil, btnSec };
            FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Duzenleme;

            colSonKodDegeri.OptionsColumn.AllowEdit = true;
            myGridView1.ShownEditor += MyGridView1_ShownEditor;
            myGridView1.CellValueChanged += MyGridView1_CellValueChanged;

            Tablo = myGridView1;
            Navigator = longNavigator1.Navigator;
        }

        public void SetModule(ModuleType module)
        {
            _module = module;
            Text = $"{ThermaCore.Domain.Extensions.EnumExtensions.ToName(module)} - Kod Logları";
        }

        protected override void Listele()
        {
            if (IsDesignMode) return;

            try
            {
                var logs = _codeLogRepository.GetAll()
                    .Where(x => x.Module == _module)
                    .ToList();

                var branches = _branchService.GetAll().ToList();

                var dtoList = logs.Select(x => new CodeLogDto
                {
                    Id = x.Id,
                    Module = x.Module,
                    CompanyCode = x.CompanyCode,
                    DateKey = x.DateKey,
                    LastCodeValue = x.LastCodeValue,
                    BranchId = x.BranchId,
                    BranchName = x.BranchId.HasValue
                        ? branches.FirstOrDefault(b => b.Id == x.BranchId.Value)?.BranchName ?? "Bilinmeyen Şube"
                        : "Genel"
                }).ToList();

                myGridControl1.DataSource = dtoList;
            }
            catch (System.Exception ex)
            {
                Messages.HataBasligi($"Veri çekme sırasında hata oluştu:\n{ex.Message}", "Hata");
            }
        }

        protected override void ShowEditForm(long id)
        {
            var editForm = Program.ServiceProvider?.GetRequiredService<KodLogEditForm>();

            if (editForm != null)
            {
                editForm.IdAtaVeAc(id);
                Listele();

                if (editForm.Id > 0)
                {
                    Tablo.RowFocus("Id", editForm.Id);
                }
            }
        }

        private void MyGridView1_ShownEditor(object sender, EventArgs e)
        {
            if (myGridView1.FocusedColumn.FieldName == "LastCodeValue")
            {
                _eskiDeger = myGridView1.ActiveEditor.OldEditValue;
            }
        }

        private async void MyGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "LastCodeValue")
            {
                var yeniDeger = e.Value;
                var id = (long)myGridView1.GetRowCellValue(e.RowHandle, "Id");

                if (_eskiDeger != null && yeniDeger != null && System.Convert.ToInt32(_eskiDeger) == System.Convert.ToInt32(yeniDeger))
                    return;

                if (Messages.EvetSeciliEvetHayir($"Sayacı {_eskiDeger} değerinden {yeniDeger} değerine güncellemek istediğinize emin misiniz?", "Onay") == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        await _codeGenerationService.UpdateLastCodeValueAsync(id, System.Convert.ToInt32(yeniDeger));
                        Messages.BilgiBasligi("Kod sayacı başarıyla güncellendi.", "Bilgi");
                    }
                    catch (System.Exception ex)
                    {
                        Messages.HataBasligi($"Hata: {ex.Message}", "Hata");
                        myGridView1.SetRowCellValue(e.RowHandle, e.Column, _eskiDeger);
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
                else
                {
                    myGridView1.HideEditor();
                    myGridView1.SetRowCellValue(e.RowHandle, e.Column, _eskiDeger);
                }
            }
        }
    }
}