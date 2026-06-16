using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Windows.Forms;

namespace ThermaCore.Presentation.WinForms.Helpers
{
    public static class UIExtensions
    {
        public static long GetRowId(this GridView tablo)
        {
            if (tablo == null) return 0;
            
            if (tablo.FocusedRowHandle >= 0)
            {
                object idObj = tablo.GetRowCellValue(tablo.FocusedRowHandle, "Id");
                if (idObj != null && long.TryParse(idObj.ToString(), out long id))
                {
                    return id;
                }
            }
            return 0;
        }

        public static T GetRow<T>(this GridView tablo, int rowHandle = -1)
        {
            if (rowHandle == -1) rowHandle = tablo.FocusedRowHandle;
            if (rowHandle < 0) return default!;
            return (T)tablo.GetRow(rowHandle);
        }

        public static void SagTikMenuGoster(this MouseEventArgs e, PopupMenu popupMenu)
        {
            if (e.Button == MouseButtons.Right && popupMenu != null)
            {
                popupMenu.ShowPopup(Control.MousePosition);
            }
        }
    }
}
