using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.CodeTemplateForms
{
    public partial class CodeTemplateEditForm : BaseEditForm
    {
        private readonly IMasterRepository<CodeTemplate> _repository = default!;
        private readonly IMasterUnitOfWork _uow = default!;

        public CodeTemplateEditForm()
        {
            InitializeComponent();
        }

        public CodeTemplateEditForm(IMasterRepository<CodeTemplate> repository, IMasterUnitOfWork uow)
        {
            InitializeComponent();
            _repository = repository;
            _uow = uow;
            BaseKartTuru = ModuleType.CodeTemplateYonetimi;
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();

            txtModul.EditValueChanged += Control_EditValueChanged;
            txtKodOnEk.EditValueChanged += Control_EditValueChanged;
            txtSayisalUzunluk.EditValueChanged += Control_EditValueChanged;
            txtBaslangicSayisi.EditValueChanged += Control_EditValueChanged;
            txtTarihFormati.EditValueChanged += Control_EditValueChanged;
            txtKodSonEk.EditValueChanged += Control_EditValueChanged;
            txtOtomatikKodUretimi.EditValueChanged += Control_EditValueChanged;
            txtKullaniciMudahaleEdebilsin.EditValueChanged += Control_EditValueChanged;
            txtFirmaKisaKoduKullan.EditValueChanged += Control_EditValueChanged;
            txtFirmaKisaKoduKullan.EditValueChanged += Control_EditValueChanged;
            txtTarihKullan.EditValueChanged += Control_EditValueChanged;
            txtTarihKullan.CheckedChanged += TxtTarihKullan_CheckedChanged;
            txtTarihBazliKodSifirlama.EditValueChanged += Control_EditValueChanged;
            
            btnKoduTestEt.Click += BtnKoduTestEt_Click;
        }

        private void BtnKoduTestEt_Click(object sender, EventArgs e)
        {
            TestKoduUret();
        }

        private void TxtTarihKullan_CheckedChanged(object sender, EventArgs e)
        {
            if (txtTarihKullan.Checked)
            {
                txtTarihFormati.Enabled = true;
                txtTarihBazliKodSifirlama.Enabled = true;
            }
            else
            {
                txtTarihFormati.Enabled = false;
                txtTarihFormati.SelectedIndex = -1;
                txtTarihBazliKodSifirlama.Enabled = false;
                txtTarihBazliKodSifirlama.Checked = false;
            }
        }

        public override void Yukle()
        {
            txtSayisalUzunluk.Properties.MinValue = 1;
            txtSayisalUzunluk.Properties.MaxValue = 15;

            var sablonUretilebilenModuller = Enum.GetValues(typeof(ModuleType))
                .Cast<ModuleType>()
                .Where(m => 
                {
                    var field = typeof(ModuleType).GetField(m.ToString());
                    return field != null && Attribute.IsDefined(field, typeof(ThermaCore.Domain.Attributes.RequiresCodeTemplateAttribute));
                })
                .ToArray();
            var tanimliModuller = _repository.Find(x => !x.IsDeleted).Select(x => x.Module).ToList();
            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                var entity = _repository.GetById(Id);
                if (entity != null)
                {
                    tanimliModuller.Remove(entity.Module); // Kendi modülünü listeden çıkar ki dropdown'da görünsün
                }
            }
            
            var gosterilecekModuller = sablonUretilebilenModuller.Where(x => !tanimliModuller.Contains(x)).ToArray();

            txtModul.Properties.Items.Clear();
            txtModul.Properties.Items.AddRange(gosterilecekModuller.Select(x => x.ToName()).ToArray());

            txtTarihFormati.Properties.Items.Clear();
            var dateFormats = EnumFunctions.GetEnumDescriptionList<DateFormat>()
                .Where(x => x != DateFormat.None.ToName())
                .ToArray();
            txtTarihFormati.Properties.Items.AddRange(dateFormats);

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                var entity = _repository.GetById(Id);
                if (entity != null)
                {
                    txtModul.SelectedItem = entity.Module.ToName();
                    txtKodOnEk.Text = entity.CodePrefix;
                    txtSayisalUzunluk.Value = entity.NumericLength;
                    txtBaslangicSayisi.Value = entity.StartNumber;
                    txtTarihFormati.SelectedItem = entity.DateFormat.ToName();
                    txtKodSonEk.Text = entity.CodeSuffix;
                    txtOtomatikKodUretimi.Checked = entity.IsAutoCodeGenerationEnabled;
                    txtKullaniciMudahaleEdebilsin.Checked = entity.IsUserInterventionAllowed;
                    txtFirmaKisaKoduKullan.Checked = entity.IsCompanyShortCodeUsed;
                    txtTarihKullan.Checked = entity.IsDateBasedCodeGenerationEnabled;
                    txtTarihBazliKodSifirlama.Checked = entity.IsDateBasedCodeResetEnabled;
                }
            }
            else
            {
                txtModul.SelectedIndex = -1;
                txtKodOnEk.Text = "";
                txtSayisalUzunluk.Value = 3;
                txtBaslangicSayisi.Value = 1;
                txtTarihFormati.SelectedIndex = -1;
                txtKodSonEk.Text = "";
                txtOtomatikKodUretimi.Checked = true;
                txtKullaniciMudahaleEdebilsin.Checked = false;
                txtFirmaKisaKoduKullan.Checked = false;
                txtTarihKullan.Checked = false;
                txtTarihBazliKodSifirlama.Checked = false;
            }

            // İlk açılışta state'i UI'a yansıt
            TxtTarihKullan_CheckedChanged(null!, EventArgs.Empty);
        }

        protected override void GuncelNesneOlustur()
        {
            ModuleType selectedModul = ModuleType.Factory;
            if (!string.IsNullOrEmpty(txtModul.Text))
                selectedModul = txtModul.Text.GetEnum<ModuleType>();

            DateFormat selectedTarih = DateFormat.None;
            if (!string.IsNullOrEmpty(txtTarihFormati.Text))
                selectedTarih = txtTarihFormati.Text.GetEnum<DateFormat>();

            CurrentEntity = new CodeTemplateDto
            {
                Id = this.Id,
                Module = selectedModul,
                CodePrefix = txtKodOnEk.Text,
                NumericLength = (byte)txtSayisalUzunluk.Value,
                StartNumber = (int)txtBaslangicSayisi.Value,
                DateFormat = selectedTarih,
                CodeSuffix = txtKodSonEk.Text,
                IsAutoCodeGenerationEnabled = txtOtomatikKodUretimi.Checked,
                IsUserInterventionAllowed = txtKullaniciMudahaleEdebilsin.Checked,
                IsCompanyShortCodeUsed = txtFirmaKisaKoduKullan.Checked,
                IsDateBasedCodeGenerationEnabled = txtTarihKullan.Checked,
                IsDateBasedCodeResetEnabled = txtTarihBazliKodSifirlama.Checked
            };
        }

        protected override bool EntityInsert()
        {
            if (string.IsNullOrEmpty(txtModul.Text))
            {
                Messages.UyariMesaji("Lütfen kod şablonu oluşturulacak bir Modül seçiniz.");
                return false;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var dto = (CodeTemplateDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(dto);
                this.Id = dto.Id;

                var entity = new CodeTemplate
                {
                    Id = dto.Id,
                    Module = dto.Module,
                    CodePrefix = dto.CodePrefix,
                    NumericLength = dto.NumericLength,
                    StartNumber = dto.StartNumber,
                    DateFormat = dto.DateFormat,
                    CodeSuffix = dto.CodeSuffix,
                    IsAutoCodeGenerationEnabled = dto.IsAutoCodeGenerationEnabled,
                    IsUserInterventionAllowed = dto.IsUserInterventionAllowed,
                    IsCompanyShortCodeUsed = dto.IsCompanyShortCodeUsed,
                    IsDateBasedCodeGenerationEnabled = dto.IsDateBasedCodeGenerationEnabled,
                    IsDateBasedCodeResetEnabled = dto.IsDateBasedCodeResetEnabled
                };

                _repository.Add(entity);
                _uow.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Messages.HataBasligi($"Hata oluştu:\n{ex.Message}", "Hata");
                return false;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        protected override bool EntityUpdate()
        {
            if (string.IsNullOrEmpty(txtModul.Text))
            {
                Messages.UyariMesaji("Lütfen kod şablonu oluşturulacak bir Modül seçiniz.");
                return false;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var dto = (CodeTemplateDto)CurrentEntity;
                var entity = _repository.GetById(dto.Id);

                if (entity != null)
                {
                    entity.Module = dto.Module;
                    entity.CodePrefix = dto.CodePrefix;
                    entity.NumericLength = dto.NumericLength;
                    entity.StartNumber = dto.StartNumber;
                    entity.DateFormat = dto.DateFormat;
                    entity.CodeSuffix = dto.CodeSuffix;
                    entity.IsAutoCodeGenerationEnabled = dto.IsAutoCodeGenerationEnabled;
                    entity.IsUserInterventionAllowed = dto.IsUserInterventionAllowed;
                    entity.IsCompanyShortCodeUsed = dto.IsCompanyShortCodeUsed;
                    entity.IsDateBasedCodeGenerationEnabled = dto.IsDateBasedCodeGenerationEnabled;
                    entity.IsDateBasedCodeResetEnabled = dto.IsDateBasedCodeResetEnabled;

                    _repository.Update(entity);
                    _uow.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Messages.HataBasligi($"Hata oluştu:\n{ex.Message}", "Hata");
                return false;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        protected override void EntityDelete()
        {
            if (Id <= 0) return;

            if (Messages.SilMesaj("Kod Şablonu") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var entity = _repository.GetById(Id);
                    if (entity != null)
                    {
                        _repository.Remove(entity);
                        _uow.SaveChanges();
                        RefreshYapilacak = true;
                        Messages.SilindiMesaj();
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    Messages.HataBasligi($"Hata oluştu:\n{ex.Message}", "Hata");
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void TestKoduUret()
        {
            GuncelNesneOlustur();
            var dto = CurrentEntity as CodeTemplateDto;
            if (dto == null) return;

            if (!dto.IsAutoCodeGenerationEnabled)
            {
                Messages.UyariMesaji("Otomatik Kod Üretimi kapalı olduğu için test edilemez.");
                return;
            }

            // TODO: İleride Cari Kartlar yapıldığında, Cari Kısa Kod alanı buradan çekilecek.
            // Şimdilik "FirmaKisaKodKullanimDurumu" seçiliyse cari kısa kod yerine boş bırakıyoruz veya opsiyonel bir şey eklemiyoruz.
            string firmaKodu = "";
            string tarihStr = "";
            
            if (dto.IsDateBasedCodeGenerationEnabled)
            {
                tarihStr = dto.DateFormat switch
                {
                    DateFormat.yyyy => DateTime.Today.ToString("yyyy"),
                    DateFormat.yy => DateTime.Today.ToString("yy"),
                    DateFormat.yyMM => DateTime.Today.ToString("yyMM"),
                    DateFormat.yyyyMM => DateTime.Today.ToString("yyyyMM"),
                    DateFormat.yyMMdd => DateTime.Today.ToString("yyMMdd"),
                    DateFormat.yyyyMMdd => DateTime.Today.ToString("yyyyMMdd"),
                    DateFormat.MMdd => DateTime.Today.ToString("MMdd"),
                    DateFormat.MMyy => DateTime.Today.ToString("MMyy"),
                    _ => ""
                };
            }

            string sayisalStr = dto.StartNumber.ToString().PadLeft(dto.NumericLength, '0');

            var parcalar = new System.Collections.Generic.List<string>();
            if (!string.IsNullOrEmpty(dto.CodePrefix)) parcalar.Add(dto.CodePrefix);
            if (!string.IsNullOrEmpty(tarihStr)) parcalar.Add(tarihStr);
            if (!string.IsNullOrEmpty(firmaKodu)) parcalar.Add(firmaKodu);
            parcalar.Add(sayisalStr);
            if (!string.IsNullOrEmpty(dto.CodeSuffix)) parcalar.Add(dto.CodeSuffix);

            string ornekKod = string.Join("-", parcalar);
            Messages.BilgiBasligi($"Oluşturulan Örnek Kod:\n\n{ornekKod}", "Kod Testi");
        }
    }
}
