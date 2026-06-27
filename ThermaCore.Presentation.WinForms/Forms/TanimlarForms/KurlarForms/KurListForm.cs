using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.KurlarForms
{
    public partial class KurListForm : BaseListForm
    {
        private readonly IRepository<ExchangeRate> _exchangeRateRepository = default!;
        private readonly IUnitOfWork _uow = default!;

        public KurListForm()
        {
            InitializeComponent();
        }

        public KurListForm(IRepository<ExchangeRate> exchangeRateRepository, IUnitOfWork uow)
        {
            InitializeComponent();
            _exchangeRateRepository = exchangeRateRepository;
            _uow = uow;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridViewPro1;
            BaseKartTuru = ModuleType.KurTanimlari;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = false;
            
            HideItems = new DevExpress.XtraBars.BarItem[] { btnYeni, btnSil };
        }

        protected override void Listele()
        {
            var kurlar = _exchangeRateRepository.Find(x => !x.IsDeleted).OrderByDescending(x => x.RateDate).ToList();
            Tablo.GridControl.DataSource = kurlar;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<KurEditForm>();
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

        protected override void EntityDelete()
        {
            XtraMessageBox.Show("Kur tanımlarında silme işlemi yapılamaz.", "Yetki Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        protected override async void Button_ItemClick(object? sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item == btnYenile)
            {
                if (XtraMessageBox.Show("TCMB kurları senkronize edilip daha sonrasında liste yenilenecektir. Onaylıyor musunuz?", "Senkronizasyon", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    Listele();
                }
                else
                {
                    try
                    {
                        var currentTenantService = Program.ServiceProvider.GetRequiredService<ThermaCore.Application.Interfaces.System.ICurrentTenantService>();
                        using var scope = Program.ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
                        
                        var scopedTenantService = scope.ServiceProvider.GetRequiredService<ThermaCore.Application.Interfaces.System.ICurrentTenantService>();
                        scopedTenantService.ConnectionString = currentTenantService.ConnectionString;
                        scopedTenantService.TenantId = currentTenantService.TenantId;
                        scopedTenantService.TenantName = currentTenantService.TenantName;
                        scopedTenantService.UserId = currentTenantService.UserId;

                        var manager = scope.ServiceProvider.GetRequiredService<ThermaCore.Application.Interfaces.System.IExchangeRateService>();
                        bool isNewDataAdded = await manager.SyncTcmbRatesAsync();
                        
                        if (isNewDataAdded)
                        {
                            XtraMessageBox.Show("Kurlar başarıyla senkronize edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show("TCMB tarafından yayınlanan en güncel kur verileri sistemde zaten kayıtlıdır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                        Listele();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"Kurlar güncellenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                base.Button_ItemClick(sender, e);
            }
        }
    }
}