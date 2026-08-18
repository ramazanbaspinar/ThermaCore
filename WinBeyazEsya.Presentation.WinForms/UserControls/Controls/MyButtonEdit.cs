using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.ComponentModel;
using WinBeyazEsya.Presentation.WinForms.Interfaces;

namespace WinBeyazEsya.Presentation.WinForms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyButtonEdit : ButtonEdit, IStatusBarKisaYol
    {
        public MyButtonEdit()
        {
            // --- İŞLEVSEL AYARLAR ---
            // Kullanıcının elle metin girmesini engeller, sadece butona tıklanarak/F4 ile seçim yapılmasını sağlar.
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            // --- GÖRSEL AYARLAR KALDIRILDI ---
            // Font tanımlamaları ve AppearanceFocused.BackColor (Sarı renk) DevExpress Skin (Tema) motoruna bırakıldı.
        }

        public override bool EnterMoveNextControl { get; set; } = true;

        // IStatusBarKisaYol Implementasyonu
        public string StatusBarAciklama { get; set; } = string.Empty;
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; } = string.Empty;

        #region Events & Properties

        private long? _id;

        [Browsable(false)]
        public long? Id
        {
            get => _id;
            set
            {
                var oldValue = _id;
                var newValue = value;
                if (newValue.HasValue && oldValue.HasValue && oldValue == newValue) { return; }

                _id = value;
                IdChanged(this, new IdChangedEventArgs(oldValue, newValue));
                EnabledChange(this, EventArgs.Empty);
            }
        }

        public event EventHandler<IdChangedEventArgs> IdChanged = delegate { };
        public event EventHandler EnabledChange = delegate { };

        #endregion
    }
}
