using DevExpress.XtraEditors;
using WinBeyazEsya.Presentation.WinForms.Helpers;
using System;
using System.Linq;
using System.Windows.Forms;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Application.Interfaces.Definitions;
using Microsoft.Extensions.DependencyInjection;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.CariTanimForms
{
    public partial class CariTanimListForm : BaseListForm
    {
        private readonly ICurrentAccountService _currentAccountService = default!;
        private readonly IServiceProvider _serviceProvider = default!;

        public CariTanimListForm()
        {
            InitializeComponent();
        }

        public CariTanimListForm(ICurrentAccountService currentAccountService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            if (!DesignMode && Program.ServiceProvider != null)
            {
                _currentAccountService = currentAccountService;
                _serviceProvider = serviceProvider;
                Bll = _currentAccountService;
            }
            Tablo = myGridView1;
            ShowItems = new DevExpress.XtraBars.BarItem[] { btnYeni, btnSil, btnYenile };
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = Domain.Enums.ModuleType.CurrentAccount;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
            
            if (Tablo != null)
            {
                Tablo.CustomColumnDisplayText += Tablo_CustomColumnDisplayText;
            }
        }

        private void Tablo_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "CardType" && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int val))
                {
                    e.DisplayText = WinBeyazEsya.Domain.Helpers.EnumFunctions.GetDescription((Domain.Enums.CardType)val);
                }
            }
        }

        protected override void Listele()
        {
            var liste = _currentAccountService.GetAll().Where(x => x.IsActive == AktifKartlariGoster);
            Tablo.GridControl.DataSource = liste.ToList();
        }

        protected override void ShowEditForm(long id)
        {
            if (_serviceProvider != null)
            {
                var form = _serviceProvider.GetRequiredService<CariTanimEditForm>();
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

            if (Helpers.Messages.SilMesaj(Tablo.GetRowCellValue(Tablo.FocusedRowHandle, "Title")?.ToString() ?? "") == DialogResult.Yes)
            {
                try
                {
                    _currentAccountService.Delete(entityId);
                    Listele();
                }
                catch (Exception ex)
                {
                    Helpers.Messages.HataBasligi(ex.Message, "Silme Hatası");
                }
            }
        }
    }
}