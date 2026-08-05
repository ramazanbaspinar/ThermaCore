using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using WinBeyazEsya.Presentation.WinForms.Interfaces;

namespace WinBeyazEsya.Presentation.WinForms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyGridLookUpFind : GridLookUpEdit, IStatusBarKisaYol
    {
        // Kullanıcının arama butonuna bastığını bildiren olay.
        public event EventHandler? SearchButtonClicked;

        public MyGridLookUpFind()
        {
            // --- İŞLEVSEL AYARLAR ---

            // Serbest metin girişini engeller, sadece listeden seçim zorunluluğu sağlar.
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            // DevExpress'in varsayılan NullText uyarısını temizler.
            Properties.NullText = "";

            // Butonları (Açılır Liste, Arama, Sil) oluşturur.
            InitializeComponent();

            // --- GÖRSEL AYARLAR KALDIRILDI ---
            // Sabit renk ve font atamaları silindi. Tema (Skin) motoru yönetimi devralacak.
        }

        private void InitializeComponent()
        {
            Properties.Buttons.Clear();

            // 1. Combo: Açılır liste
            // 2. Search: Gelişmiş arama/yeni kayıt ekranını tetikler
            // 3. Delete: Mevcut seçimi temizler
            Properties.Buttons.AddRange(new EditorButton[] {
                new EditorButton(ButtonPredefines.Combo),
                new EditorButton(ButtonPredefines.Search),
                new EditorButton(ButtonPredefines.Delete)
            });

            this.Properties.ButtonClick += Properties_ButtonClick;
        }

        private void Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                this.EditValue = null;
            }
            else if (e.Button.Kind == ButtonPredefines.Search)
            {
                // Arama butonuna tıklandığında olayı tetikler.
                SearchButtonClicked?.Invoke(this, EventArgs.Empty);
            }
        }

        public override bool EnterMoveNextControl { get; set; } = true;

        // IStatusBarKisaYol Implementasyonu
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; } = "Seçim Yap";
        public string StatusBarAciklama { get; set; } = "Kayıt Seçiniz";
    }
}
