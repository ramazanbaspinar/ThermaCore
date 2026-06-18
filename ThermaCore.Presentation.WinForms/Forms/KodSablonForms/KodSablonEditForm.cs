using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.KodSablonForms
{
    public partial class KodSablonEditForm : BaseEditForm
    {
        private readonly IRepository<KodSablon> _repository = default!;
        private readonly IUnitOfWork _uow = default!;

        public KodSablonEditForm()
        {
            InitializeComponent();
        }

        public KodSablonEditForm(IRepository<KodSablon> repository, IUnitOfWork uow)
        {
            InitializeComponent();
            _repository = repository;
            _uow = uow;
            BaseKartTuru = ModuleType.KodSablonYonetimi;
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

            var sablonUretilebilenModuller = new[] { ModuleType.Factory };
            
            var tanimliModuller = _repository.Find(x => !x.IsDeleted).Select(x => x.Modul).ToList();
            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                var entity = _repository.GetById(Id);
                if (entity != null)
                {
                    tanimliModuller.Remove(entity.Modul); // Kendi modülünü listeden çıkar ki dropdown'da görünsün
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
                    txtModul.SelectedItem = entity.Modul.ToName();
                    txtKodOnEk.Text = entity.KodOnEk;
                    txtSayisalUzunluk.Value = entity.SayisalUzunluk;
                    txtBaslangicSayisi.Value = entity.BaslangicSayisi;
                    txtTarihFormati.SelectedItem = entity.TarihFormati.ToName();
                    txtKodSonEk.Text = entity.KodSonEk;
                    txtOtomatikKodUretimi.Checked = entity.OtomatikKodUretmeDurumu;
                    txtKullaniciMudahaleEdebilsin.Checked = entity.KullaniciMudahalesiDurumu;
                    txtFirmaKisaKoduKullan.Checked = entity.FirmaKisaKodKullanimDurumu;
                    txtTarihKullan.Checked = entity.TarihliKodUretmeDurumu;
                    txtTarihBazliKodSifirlama.Checked = entity.TarihBazliKodSifrlamaDurumu;
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

            CurrentEntity = new KodSablonDto
            {
                Id = this.Id,
                Modul = selectedModul,
                KodOnEk = txtKodOnEk.Text,
                SayisalUzunluk = (byte)txtSayisalUzunluk.Value,
                BaslangicSayisi = (int)txtBaslangicSayisi.Value,
                TarihFormati = selectedTarih,
                KodSonEk = txtKodSonEk.Text,
                OtomatikKodUretmeDurumu = txtOtomatikKodUretimi.Checked,
                KullaniciMudahalesiDurumu = txtKullaniciMudahaleEdebilsin.Checked,
                FirmaKisaKodKullanimDurumu = txtFirmaKisaKoduKullan.Checked,
                TarihliKodUretmeDurumu = txtTarihKullan.Checked,
                TarihBazliKodSifrlamaDurumu = txtTarihBazliKodSifirlama.Checked
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
                var dto = (KodSablonDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(dto);
                this.Id = dto.Id;

                var entity = new KodSablon
                {
                    Id = dto.Id,
                    Modul = dto.Modul,
                    KodOnEk = dto.KodOnEk,
                    SayisalUzunluk = dto.SayisalUzunluk,
                    BaslangicSayisi = dto.BaslangicSayisi,
                    TarihFormati = dto.TarihFormati,
                    KodSonEk = dto.KodSonEk,
                    OtomatikKodUretmeDurumu = dto.OtomatikKodUretmeDurumu,
                    KullaniciMudahalesiDurumu = dto.KullaniciMudahalesiDurumu,
                    FirmaKisaKodKullanimDurumu = dto.FirmaKisaKodKullanimDurumu,
                    TarihliKodUretmeDurumu = dto.TarihliKodUretmeDurumu,
                    TarihBazliKodSifrlamaDurumu = dto.TarihBazliKodSifrlamaDurumu
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
                var dto = (KodSablonDto)CurrentEntity;
                var entity = _repository.GetById(dto.Id);

                if (entity != null)
                {
                    entity.Modul = dto.Modul;
                    entity.KodOnEk = dto.KodOnEk;
                    entity.SayisalUzunluk = dto.SayisalUzunluk;
                    entity.BaslangicSayisi = dto.BaslangicSayisi;
                    entity.TarihFormati = dto.TarihFormati;
                    entity.KodSonEk = dto.KodSonEk;
                    entity.OtomatikKodUretmeDurumu = dto.OtomatikKodUretmeDurumu;
                    entity.KullaniciMudahalesiDurumu = dto.KullaniciMudahalesiDurumu;
                    entity.FirmaKisaKodKullanimDurumu = dto.FirmaKisaKodKullanimDurumu;
                    entity.TarihliKodUretmeDurumu = dto.TarihliKodUretmeDurumu;
                    entity.TarihBazliKodSifrlamaDurumu = dto.TarihBazliKodSifrlamaDurumu;

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
            var dto = CurrentEntity as KodSablonDto;
            if (dto == null) return;

            if (!dto.OtomatikKodUretmeDurumu)
            {
                Messages.UyariMesaji("Otomatik Kod Üretimi kapalı olduğu için test edilemez.");
                return;
            }

            string firmaKodu = dto.FirmaKisaKodKullanimDurumu ? "FRM" : "";
            string tarihStr = "";
            
            if (dto.TarihliKodUretmeDurumu)
            {
                tarihStr = dto.TarihFormati switch
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

            string sayisalStr = dto.BaslangicSayisi.ToString().PadLeft(dto.SayisalUzunluk, '0');

            var parcalar = new System.Collections.Generic.List<string>();
            if (!string.IsNullOrEmpty(dto.KodOnEk)) parcalar.Add(dto.KodOnEk);
            if (!string.IsNullOrEmpty(tarihStr)) parcalar.Add(tarihStr);
            if (!string.IsNullOrEmpty(firmaKodu)) parcalar.Add(firmaKodu);
            parcalar.Add(sayisalStr);
            if (!string.IsNullOrEmpty(dto.KodSonEk)) parcalar.Add(dto.KodSonEk);

            string ornekKod = string.Join("-", parcalar);
            Messages.BilgiBasligi($"Oluşturulan Örnek Kod:\n\n{ornekKod}", "Kod Testi");
        }
    }
}