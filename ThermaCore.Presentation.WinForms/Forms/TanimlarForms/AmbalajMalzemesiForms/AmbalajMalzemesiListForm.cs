using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using ThermaCore.Application.Interfaces.Definitions;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;
using System.Linq;

namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.AmbalajMalzemesiForms;

public partial class AmbalajMalzemesiListForm : BaseListForm
{
    private readonly IPackagingMaterialService _packagingMaterialService;

    public AmbalajMalzemesiListForm()
    {
        InitializeComponent();
        _packagingMaterialService = Program.ServiceProvider.GetRequiredService<IPackagingMaterialService>();
    }

    protected override void DegiskenleriDoldur()
    {
        Tablo = myGridView1;
        BaseKartTuru = ModuleType.AmbalajMalzemesiTanimlari;
        Navigator = longNavigator1.Navigator;
        AktifPasifButonGoster = true;
    }

    protected override void Listele()
    {
        Tablo.GridControl.DataSource = _packagingMaterialService.GetAll().Where(x => x.IsActive == AktifKartlariGoster).ToList();
    }

    protected override void ShowEditForm(long id)
    {
        var form = Program.ServiceProvider.GetRequiredService<AmbalajMalzemesiEditForm>();
        form.IdAtaVeAc(id);
        Listele();
        if (form.Id > 0)
        {
            Tablo.RowFocus("Id", form.Id);
        }
    }

    protected override void EntityDelete()
    {
        if (Tablo.FocusedRowHandle < 0) return;

        long entityId = 0;
        long.TryParse(Tablo.GetFocusedRowCellValue("Id")?.ToString(), out entityId);
        
        if (entityId <= 0) return;

        if (Messages.SilMesaj(Tablo.GetFocusedRowCellValue("Code").ToString()) == DialogResult.Yes)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _packagingMaterialService.Delete(entityId);
                Listele();
                Messages.SilindiMesaj();
            }
            catch (Exception ex)
            {
                Messages.HataBasligi(ex.Message, "Silme Hatası");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}