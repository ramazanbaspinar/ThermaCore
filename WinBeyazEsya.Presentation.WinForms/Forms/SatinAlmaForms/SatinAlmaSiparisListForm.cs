using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace WinBeyazEsya.Presentation.WinForms.Forms.SatinAlmaForms
{
    public partial class SatinAlmaSiparisListForm : BaseListForm
    {
        private readonly WinBeyazEsya.Application.Interfaces.Purchasing.IPurchaseOrderService _purchaseOrderService = default!;
        private readonly System.IServiceProvider _serviceProvider = default!;

        public SatinAlmaSiparisListForm()
        {
            InitializeComponent();
        }

        public SatinAlmaSiparisListForm(
            WinBeyazEsya.Application.Interfaces.Purchasing.IPurchaseOrderService purchaseOrderService,
            System.IServiceProvider serviceProvider)
        {
            InitializeComponent();

            if (!DesignMode && Program.ServiceProvider != null)
            {
                _purchaseOrderService = purchaseOrderService;
                _serviceProvider = serviceProvider;
                Bll = _purchaseOrderService;
            }

            ShowItems = new DevExpress.XtraBars.BarItem[] { btnYeni, btnSil, btnYenile };
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = Domain.Enums.ModuleType.SatinalmaSiparisleri;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;

            Tablo.RowStyle -= Tablo_RowStyle;
            Tablo.RowStyle += Tablo_RowStyle;
        }

        private DevExpress.XtraBars.BarButtonItem _btnOnayaGonder;
        private DevExpress.XtraBars.BarButtonItem _btnOnayla;
        private DevExpress.XtraBars.BarButtonItem _btnIptalEt;
        private DevExpress.XtraBars.BarButtonItem _btnZorlaKapat;

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            if (!IsDesignMode && SagTikMenu != null && ribbon != null)
            {
                _btnOnayaGonder = new DevExpress.XtraBars.BarButtonItem(ribbon.Manager, "Siparişi Onaya Gönder");
                _btnOnayaGonder.ItemClick += (s, args) => 
                {
                    if (Helpers.Messages.HayirSeciliEvetHayir("Siparişi onaya göndermek istediğinize emin misiniz?", "Onaya Gönder") == DialogResult.Yes)
                    {
                        ChangeOrderStatus(Tablo.FocusedRowHandle, OrderStatus.WaitingApproval);
                    }
                };
                SagTikMenu.ItemLinks.Insert(0, _btnOnayaGonder);

                _btnOnayla = new DevExpress.XtraBars.BarButtonItem(ribbon.Manager, "Siparişi Onayla");
                _btnOnayla.ItemClick += (s, args) => 
                {
                    if (Helpers.Messages.HayirSeciliEvetHayir("Seçili siparişi onaylamak istediğinize emin misiniz?", "Sipariş Onayı") == DialogResult.Yes)
                    {
                        ChangeOrderStatus(Tablo.FocusedRowHandle, OrderStatus.Approved);
                    }
                };
                SagTikMenu.ItemLinks.Insert(1, _btnOnayla);

                _btnIptalEt = new DevExpress.XtraBars.BarButtonItem(ribbon.Manager, "Siparişi İptal Et");
                _btnIptalEt.ItemClick += (s, args) => 
                {
                    if (Helpers.Messages.HayirSeciliEvetHayir("Seçili siparişi iptal etmek istediğinize emin misiniz?", "Sipariş İptali") == DialogResult.Yes)
                    {
                        ChangeOrderStatus(Tablo.FocusedRowHandle, OrderStatus.Canceled);
                    }
                };
                SagTikMenu.ItemLinks.Insert(2, _btnIptalEt);

                _btnZorlaKapat = new DevExpress.XtraBars.BarButtonItem(ribbon.Manager, "Siparişi Zorla Kapat");
                _btnZorlaKapat.ItemClick += (s, args) => 
                {
                    if (Helpers.Messages.HayirSeciliEvetHayir("Seçili siparişi zorla kapatmak istediğinize emin misiniz?", "Siparişi Kapatma") == DialogResult.Yes)
                    {
                        ChangeOrderStatus(Tablo.FocusedRowHandle, OrderStatus.Completed);
                    }
                };
                var link = SagTikMenu.ItemLinks.Insert(3, _btnZorlaKapat);
                link.BeginGroup = true; // separator

                SagTikMenu.BeforePopup += SagTikMenu_BeforePopup;
            }
        }

        protected override void Listele()
        {
            var liste = _purchaseOrderService.GetAll()
                .Where(x => x.IsActive == AktifKartlariGoster)
                .OrderByDescending(x => x.OrderDate)
                .ToList();

            if (ListeDisiTutulacakKayitlar != null && ListeDisiTutulacakKayitlar.Any())
            {
                liste = liste.Where(x => !ListeDisiTutulacakKayitlar.Contains(x.Id)).ToList();
            }

            if (_serviceProvider != null)
            {
                var currentAccountRepo = _serviceProvider.GetService<WinBeyazEsya.Application.Interfaces.Repositories.IRepository<WinBeyazEsya.Domain.Entities.Definitions.CurrentAccount>>();
                var warehouseRepo = _serviceProvider.GetService<WinBeyazEsya.Application.Interfaces.Repositories.IRepository<WinBeyazEsya.Domain.Entities.Definitions.Warehouse>>();
                var userRepo = _serviceProvider.GetService<WinBeyazEsya.Application.Interfaces.Repositories.IMasterRepository<WinBeyazEsya.Domain.Entities.Management.User>>();

                foreach (var item in liste)
                {
                    if (currentAccountRepo != null && item.SupplierId > 0)
                    {
                        var supplier = currentAccountRepo.GetById(item.SupplierId);
                        if (supplier != null)
                        {
                            item.SupplierName = supplier.Title ?? "";
                            item.SupplierCode = supplier.Code ?? "";
                        }
                    }

                    if (warehouseRepo != null && item.WarehouseId.HasValue && item.WarehouseId > 0)
                    {
                        var warehouse = warehouseRepo.GetById(item.WarehouseId.Value);
                        if (warehouse != null)
                        {
                            item.WarehouseName = warehouse.Name ?? "";
                        }
                    }

                    if (userRepo != null && item.CreatedUserId.HasValue && item.CreatedUserId > 0)
                    {
                        var user = userRepo.GetById(item.CreatedUserId.Value);
                        if (user != null)
                        {
                            item.CreatedFullName = $"{user.FirstName} {user.LastName}".Trim();
                        }
                    }
                    
                    item.StatusName = item.Status.ToName();
                }
            }

            Tablo.GridControl.DataSource = liste;
        }

        protected override void ShowEditForm(long id)
        {
            if (_serviceProvider != null)
            {
                var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<SatinAlmaSiparisEditForm>(_serviceProvider);
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
        }

        protected override void EntityDelete()
        {
            if (Tablo.FocusedRowHandle < 0) return;

            long entityId = 0;
            long.TryParse(Tablo.GetFocusedRowCellValue("Id")?.ToString(), out entityId);

            if (entityId <= 0) return;

            var statusVal = Tablo.GetRowCellValue(Tablo.FocusedRowHandle, "Status");
            if (statusVal != null && statusVal is WinBeyazEsya.Domain.Enums.OrderStatus status)
            {
                if (status != WinBeyazEsya.Domain.Enums.OrderStatus.Draft && 
                    status != WinBeyazEsya.Domain.Enums.OrderStatus.WaitingApproval)
                {
                    Helpers.Messages.UyariMesaji("Onaylanmış veya işlem görmüş siparişler silinemez! Silmek için önce onayını geri çekmelisiniz.");
                    return;
                }
            }

            var result = Helpers.Messages.SilMesaj(Tablo.GetRowCellValue(Tablo.FocusedRowHandle, "DocumentNo")?.ToString() ?? Tablo.GetRowCellValue(Tablo.FocusedRowHandle, "Code")?.ToString() ?? "");
            if (result == DialogResult.Yes)
            {
                try
                {
                    _purchaseOrderService.Delete(entityId);
                    Listele();
                }
                catch (System.Exception ex)
                {
                    Helpers.Messages.HataBasligi(ex.Message, "Silme Hatası");
                }
            }
        }

        private void Tablo_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (view == null) return;
                
                var dto = view.GetRow(e.RowHandle) as WinBeyazEsya.Application.DTOs.Purchasing.PurchaseOrderListDto;
                if (dto == null) return;

                switch (dto.Status)
                {
                    case OrderStatus.Draft:
                        e.Appearance.BackColor = ColorTranslator.FromHtml("#F5F5F5");
                        e.HighPriority = true;
                        break;
                    case OrderStatus.WaitingApproval:
                        e.Appearance.BackColor = ColorTranslator.FromHtml("#FFF59D");
                        e.HighPriority = true;
                        break;
                    case OrderStatus.Approved:
                        e.Appearance.BackColor = ColorTranslator.FromHtml("#C8E6C9");
                        e.HighPriority = true;
                        break;
                    case OrderStatus.PartialReceived:
                        e.Appearance.BackColor = ColorTranslator.FromHtml("#BBDEFB");
                        e.HighPriority = true;
                        break;
                    case OrderStatus.Canceled:
                        e.Appearance.BackColor = ColorTranslator.FromHtml("#FFCDD2");
                        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Strikeout);
                        e.HighPriority = true;
                        break;
                    case OrderStatus.Completed:
                        e.Appearance.BackColor = ColorTranslator.FromHtml("#E0E0E0");
                        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Italic);
                        e.HighPriority = true;
                        break;
                }
            }
        }

        private void SagTikMenu_BeforePopup(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _btnOnayaGonder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            _btnOnayla.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            _btnIptalEt.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            _btnZorlaKapat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            if (Tablo == null || Tablo.FocusedRowHandle < 0) return;

            var dto = Tablo.GetRow(Tablo.FocusedRowHandle) as WinBeyazEsya.Application.DTOs.Purchasing.PurchaseOrderListDto;
            if (dto == null) return;

            var authService = _serviceProvider?.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            bool canApprove = authService != null && authService.HasSpecialPermission(Domain.Enums.ModuleType.SatinalmaSiparisleri, "CanApproveOrders");
            bool canCancel = authService != null && authService.HasSpecialPermission(Domain.Enums.ModuleType.SatinalmaSiparisleri, "CanCancelOrders");
            bool canClose = authService != null && authService.HasSpecialPermission(Domain.Enums.ModuleType.SatinalmaSiparisleri, "CanCloseOrdersForcefully");

            if (dto.Status == OrderStatus.Draft)
                _btnOnayaGonder.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            if (canApprove && dto.Status == OrderStatus.WaitingApproval)
                _btnOnayla.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            if (canCancel && dto.Status != OrderStatus.Completed && dto.Status != OrderStatus.Canceled)
                _btnIptalEt.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            if (canClose && dto.Status == OrderStatus.PartialReceived)
                _btnZorlaKapat.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        private void ChangeOrderStatus(int rowHandle, OrderStatus newStatus)
        {
            if (rowHandle < 0) return;
            
            long entityId = 0;
            if (long.TryParse(Tablo.GetRowCellValue(rowHandle, "Id")?.ToString(), out entityId) && entityId > 0)
            {
                try
                {
                    var order = _purchaseOrderService.GetById(entityId);
                    if (order != null)
                    {
                        order.Status = newStatus;
                        _purchaseOrderService.Update(order);
                        Listele();
                        Tablo.FocusedRowHandle = Tablo.LocateByValue("Id", entityId);
                    }
                }
                catch (System.Exception ex)
                {
                    Helpers.Messages.HataBasligi(ex.Message, "Durum Güncelleme Hatası");
                }
            }
        }
    }
}