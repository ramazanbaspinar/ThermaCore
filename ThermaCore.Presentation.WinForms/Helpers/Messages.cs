using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ThermaCore.Presentation.WinForms.Helpers;

public static class Messages
{
    public static void HataMesaji(string hataMesaji)
    {
        XtraMessageBox.Show(hataMesaji, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static DialogResult SilMesaj(string tabloAdi)
    {
        return XtraMessageBox.Show($"Seçili {tabloAdi} kayıtları silinecektir. Onaylıyor musunuz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
    }

    public static DialogResult HayirSeciliEvetHayir(string mesaj, string baslik)
    {
        return XtraMessageBox.Show(mesaj, baslik, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
    }
}
