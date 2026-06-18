using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;
using DevExpress.XtraEditors;

namespace ThermaCore.Presentation.WinForms.Forms.SirketForms
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