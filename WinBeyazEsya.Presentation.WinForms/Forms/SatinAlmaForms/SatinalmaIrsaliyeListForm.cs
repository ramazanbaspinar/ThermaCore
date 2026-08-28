using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.SatinalmaForms
{
    public partial class SatinalmaIrsaliyeListForm : BaseListForm
    {
        private WinBeyazEsya.Application.Interfaces.Purchasing.IPurchaseReceiptService _purchaseReceiptService = default!;
        private System.IServiceProvider _serviceProvider = default!;

        public SatinalmaIrsaliyeListForm()
        {
            InitializeComponent();
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.SatinalmaIrsaliyeleri;
        }

        public SatinalmaIrsaliyeListForm(
            WinBeyazEsya.Application.Interfaces.Purchasing.IPurchaseReceiptService purchaseReceiptService,
            System.IServiceProvider serviceProvider)
        {
            InitializeComponent();

            if (!DesignMode && Program.ServiceProvider != null)
            {
                _purchaseReceiptService = purchaseReceiptService;
                _serviceProvider = serviceProvider;
                Bll = _purchaseReceiptService;
            }

            ShowItems = new DevExpress.XtraBars.BarItem[] { btnYeni, btnSil, btnYenile };
        }

        protected override void DegiskenleriDoldur()
        {
            if (!IsDesignMode && Program.ServiceProvider != null && _purchaseReceiptService == null)
            {
                _purchaseReceiptService = Program.ServiceProvider.GetService<WinBeyazEsya.Application.Interfaces.Purchasing.IPurchaseReceiptService>()!;
                _serviceProvider = Program.ServiceProvider;
                Bll = _purchaseReceiptService;
            }

            Tablo = myGridView1;
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.SatinalmaIrsaliyeleri;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = false;
        }

        protected override void Listele()
        {
            var liste = _purchaseReceiptService.GetAll()
                .OrderByDescending(x => x.ReceiptDate)
                .ToList();

            if (ListeDisiTutulacakKayitlar != null && ListeDisiTutulacakKayitlar.Any())
            {
                liste = liste.Where(x => !ListeDisiTutulacakKayitlar.Contains(x.Id)).ToList();
            }

            if (_serviceProvider != null)
            {
                var currentAccountRepo = _serviceProvider.GetService<WinBeyazEsya.Application.Interfaces.Repositories.IRepository<WinBeyazEsya.Domain.Entities.Definitions.CurrentAccount>>();
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

                    if (userRepo != null && item.CreatedUserId.HasValue && item.CreatedUserId > 0)
                    {
                        var user = userRepo.GetById(item.CreatedUserId.Value);
                        if (user != null)
                        {
                            item.CreatedUserName = $"{user.FirstName} {user.LastName}".Trim();
                        }
                    }
                }
            }

            Tablo.GridControl.DataSource = liste;
        }

        protected override void ShowEditForm(long id)
        {
            if (_serviceProvider != null)
            {
                var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<SatinalmaIrsaliyeEditForm>(_serviceProvider);
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

            var result = Helpers.Messages.SilMesaj(Tablo.GetRowCellValue(Tablo.FocusedRowHandle, "DocumentNo")?.ToString() ?? Tablo.GetRowCellValue(Tablo.FocusedRowHandle, "Code")?.ToString() ?? "");
            if (result == DialogResult.Yes)
            {
                try
                {
                    _purchaseReceiptService.Delete(entityId);
                    Listele();
                }
                catch (System.Exception ex)
                {
                    Helpers.Messages.HataBasligi(ex.Message, "Silme Hatası");
                }
            }
        }
    }
}