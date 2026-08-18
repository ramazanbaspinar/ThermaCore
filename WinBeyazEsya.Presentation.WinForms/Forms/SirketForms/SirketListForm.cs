using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Domain.Entities.Management;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.SirketForms
{
    public partial class SirketListForm : BaseListForm
    {
        private readonly IMasterRepository<TenantDatabase> _tenantRepository;
        private readonly IMasterUnitOfWork _uow;

        public SirketListForm()
        {
            InitializeComponent();
        }

        public SirketListForm(IMasterRepository<TenantDatabase> tenantRepository, IMasterUnitOfWork uow)
        {
            InitializeComponent();
            _tenantRepository = tenantRepository;
            _uow = uow;

            // BaseForm'daki korumalı (protected) Tablo referansına, 
            // bu formdaki gridView'ı bağlıyoruz ki base metodlar çalışabilsin.
            Tablo = myGridView1;
            Navigator = longNavigator1.Navigator;

            btnBagliKayitlar.Caption = "Fabrikalar";
        }

        protected override void DegiskenleriDoldur()
        {
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.SirketTanimlari;

            if (IsMdiChild)
                ShowItems = new DevExpress.XtraBars.BarItem[] { btnBagliKayitlar };
        }

        protected override void Listele()
        {
            if (IsDesignMode) return;

            try
            {
                // Master veritabanındaki şirketleri çekmek için repo'yu alıyoruz
                // AktifKartlariGoster base classtan gelir
                var entities = _tenantRepository.Find(x => x.IsActive == AktifKartlariGoster).ToList();

                // DTO dönüşümü (Eğer AutoMapper UI katmanında da konfigüre edildiyse IMapper kullanılabilir)
                var dtoList = entities.Select(x => new TenantDatabaseDto
                {
                    Id = x.Id,
                    Code = x.Code,
                    CompanyCode = x.CompanyCode,
                    CompanyName = x.CompanyName,
                    DatabaseName = x.DatabaseName,
                    Server = x.Server,
                    AuthType = x.AuthType,
                    Username = x.Username,
                    Password = x.Password
                }).ToList();

                // Grid'e DTO listesini bağlıyoruz
                myGridControl1.DataSource = dtoList;
            }
            catch (Exception ex)
            {
                Messages.HataBasligi($"Şirketler listelenirken veri çekme hatası oluştu:\n{ex.Message}", "Veri Çekme Hatası");
            }
        }

        protected override void ShowEditForm(long id)
        {
            // İlgili edit formunu DI üzerinden çözümlüyoruz (Tüm bağımlılıklarıyla birlikte gelir)
            var editForm = Program.ServiceProvider?.GetRequiredService<SirketEditForm>();

            if (editForm != null)
            {
                // Formu Id ile aç (Ekleme için -1 veya 0, düzenleme için id > 0)
                editForm.IdAtaVeAc(id);

                // Form kapandıktan sonra güncel listeyi tekrar çek
                Listele();

                // Ve eklenen/güncellenen satıra odaklan
                if (editForm.Id > 0)
                {
                    Tablo.RowFocus("Id", editForm.Id);
                }
            }
        }

        protected override void EntityDelete()
        {
            var selectedId = GetSelectedRowId();
            if (selectedId < 0) return;

            if (Messages.SilMesaj("Şirket") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var entity = _tenantRepository.GetById(selectedId);
                    if (entity != null)
                    {
                        _tenantRepository.Remove(entity);
                        _uow.SaveChanges();
                        Listele();
                        Messages.BilgiBasligi("Şirket başarıyla silindi.", "Bilgi");
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

        protected override void BagliKayitAc()
        {
            var selectedId = GetSelectedRowId();
            if (selectedId <= 0) return;

            var entity = _tenantRepository.GetById(selectedId);
            if (entity == null) return;

            var frm = Program.ServiceProvider?.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.FabrikaForms.FabrikaListForm>();
            if (frm != null)
            {
                frm.SetSirketBilgisi(entity.Id, entity.CompanyName);
                frm.MdiParent = this.MdiParent;
                frm.Yukle();
                frm.Show();
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
