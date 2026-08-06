using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Domain.Entities.Management;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.CodeTemplateForms
{
    public partial class KodSablonlariListForm : BaseListForm
    {
        private readonly IMasterRepository<CodeTemplate> _repository = default!;
        private readonly IMasterUnitOfWork _uow = default!;

        public KodSablonlariListForm()
        {
            InitializeComponent();
        }

        public KodSablonlariListForm(IMasterRepository<CodeTemplate> repository, IMasterUnitOfWork uow)
        {
            InitializeComponent();
            _repository = repository;
            _uow = uow;

            Tablo = myGridView1;
            Navigator = longNavigator1.Navigator;

            btnBagliKayitlar.Caption = "Loglar";
            HideItems = new DevExpress.XtraBars.BarItem[] { btnAktifPasifKayitlar };
            ShowItems = new DevExpress.XtraBars.BarItem[] { btnBagliKayitlar };
        }

        protected override void Listele()
        {
            if (IsDesignMode) return;

            try
            {
                var entities = _repository.GetAll().ToList();

                var dtoList = entities.Select(x => new CodeTemplateDto
                {
                    Id = x.Id,
                    Module = x.Module,
                    CodePrefix = x.CodePrefix,
                    NumericLength = x.NumericLength,
                    StartNumber = x.StartNumber,
                    DateFormat = x.DateFormat,
                    CodeSuffix = x.CodeSuffix,
                    IsAutoCodeGenerationEnabled = x.IsAutoCodeGenerationEnabled,
                    IsUserInterventionAllowed = x.IsUserInterventionAllowed,
                    IsCompanyShortCodeUsed = x.IsCompanyShortCodeUsed,
                    IsDateBasedCodeGenerationEnabled = x.IsDateBasedCodeGenerationEnabled,
                    IsDateBasedCodeResetEnabled = x.IsDateBasedCodeResetEnabled
                }).ToList();

                myGridControl1.DataSource = dtoList;
            }
            catch (Exception ex)
            {
                Messages.HataBasligi($"Hata oluştu:\n{ex.Message}", "Veri Çekme Hatası");
            }
        }

        protected override void ShowEditForm(long id)
        {
            var editForm = Program.ServiceProvider?.GetRequiredService<KodSablonlariEditForm>();
            
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

        protected override void BagliKayitAc()
        {
            var selectedId = GetSelectedRowId();
            if (selectedId < 0) return;

            var entity = _repository.GetById(selectedId);
            if (entity != null)
            {
                var form = Program.ServiceProvider?.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.KodYonetimForms.KodLogListForm>();
                if (form != null)
                {
                    form.SetModule(entity.Module);
                    form.ShowDialog();
                }
            }
        }

        protected override void EntityDelete()
        {
            var selectedId = GetSelectedRowId();
            if (selectedId < 0) return;

            if (Messages.SilMesaj("Kod Şablonu") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var entity = _repository.GetById(selectedId);
                    if (entity != null)
                    {
                        _repository.Remove(entity);
                        _uow.SaveChanges();
                        Listele();
                        Messages.BilgiBasligi("Başarıyla silindi.", "Bilgi");
                    }
                }
                catch (Exception ex)
                {
                    Messages.HataBasligi($"Silme işlemi sırasında hata oluştu:\n\n{ex.Message}", "Hata");
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private long GetSelectedRowId()
        {
            if (Tablo != null && Tablo.FocusedRowHandle >= 0)
            {
                var rowObj = Tablo.GetRowCellValue(Tablo.FocusedRowHandle, "Id");
                if (rowObj != null && long.TryParse(rowObj.ToString(), out long id))
                {
                    return id;
                }
            }
            return -1;
        }
    }
}

