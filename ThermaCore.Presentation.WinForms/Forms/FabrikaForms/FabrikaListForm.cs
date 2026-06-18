using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Interfaces.System;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Enums;
using ThermaCore.Application.Services.Management;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.FabrikaForms
{
    public partial class FabrikaListForm : BaseListForm
    {
        private readonly IBranchService _branchService = default!;
        private readonly ICurrentTenantService _currentTenantService = default!;

        private long _sirketId;
        private string _sirketAdi = string.Empty;

        public FabrikaListForm()
        {
            InitializeComponent();
        }

        public FabrikaListForm(IBranchService branchService, ICurrentTenantService currentTenantService)
        {
            InitializeComponent();
            _branchService = branchService;
            _currentTenantService = currentTenantService;
        }

        public void SetSirketBilgisi(long sirketId, string sirketAdi)
        {
            _sirketId = sirketId;
            _sirketAdi = sirketAdi;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = ModuleType.Management;
            Navigator = longNavigator1.Navigator;
            
            Text = $"Fabrikalar ({_sirketAdi})";
            Tablo.ViewCaption = Text;
        }

        protected override void Listele()
        {
            if (IsDesignMode) return;

            try
            {
                var dtoList = _branchService.GetAll()
                    .Where(x => x.TenantDatabaseId == _sirketId && x.IsActive == AktifKartlariGoster)
                    .ToList();

                myGridControl1.DataSource = dtoList;
            }
            catch (Exception ex)
            {
                Messages.HataBasligi($"Fabrikalar listelenirken veri çekme hatası oluştu:\n{ex.Message}", "Veri Çekme Hatası");
            }
        }

        protected override void ShowEditForm(long id)
        {
            var editForm = Program.ServiceProvider?.GetRequiredService<FabrikaEditForm>();
            if (editForm != null)
            {
                editForm.SetSirketBilgisi(_sirketId, _sirketAdi);
                editForm.IdAtaVeAc(id);
                Listele();
            }
        }

        protected override void EntityDelete()
        {
            if (Tablo == null || Tablo.FocusedRowHandle < 0) return;
            
            var idObj = Tablo.GetRowCellValue(Tablo.FocusedRowHandle, "Id");
            if (idObj != null && long.TryParse(idObj.ToString(), out long id))
            {
                if (Messages.SilMesaj("Fabrika") == DialogResult.Yes)
                {
                    try
                    {
                        var dto = _branchService.GetById(id);
                        if (dto != null)
                        {
                            if (dto.TenantDatabaseId != _sirketId)
                            {
                                Messages.HataBasligi("Farklı bir şirkete ait fabrikayı silemezsiniz!", "Güvenlik İhlali");
                                return;
                            }

                            _branchService.Delete(id);
                            Listele();
                        }
                    }
                    catch (Exception ex)
                    {
                        Messages.HataBasligi($"Silme sırasında hata oluştu: {ex.Message}", "Hata");
                    }
                }
            }
        }
    }
}