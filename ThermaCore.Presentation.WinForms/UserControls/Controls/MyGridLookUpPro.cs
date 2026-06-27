using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using ThermaCore.Presentation.WinForms.Interfaces;

namespace ThermaCore.Presentation.WinForms.UserControls.Controls.Controls
{
    [ToolboxItem(true)]
    public class MyGridLookUpPro : GridLookUpEdit, IStatusBarKisaYol
    {
        public MyGridLookUpPro()
        {
            // --- İŞLEVSEL AYARLAR ---

            // Serbest metin girişini engeller, kullanıcının sadece listeden seçim yapmasını zorunlu kılar.
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            // Bileşen boşken DevExpress'in varsayılan olarak gösterdiği yazıyı temizler.
            Properties.NullText = "";

            // Aşağı ok ve Silme butonlarının arayüze eklenmesini tetikler.
            InitializeComponent();

            // --- GÖRSEL AYARLAR KALDIRILDI ---
            // Sabit renkler (Beyaz zemin, odaklanıldığında Sarı zemin) ve Segoe UI font atamaları silindi. 
            // Seçim aracı artık formun genel DevExpress temasından (Skin) beslenecek.
        }

        private void InitializeComponent()
        {
            Properties.Buttons.Clear();

            // 1. Buton: Varsayılan aşağı ok (açılır liste) butonu
            // 2. Buton: Seçimi temizleme (Çarpı/Sil) butonu
            Properties.Buttons.AddRange(new EditorButton[] {
                new EditorButton(ButtonPredefines.Combo),
                new EditorButton(ButtonPredefines.Delete)
            });

            this.Properties.ButtonClick += Properties_ButtonClick;
        }

        private void Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            // Silme butonuna tıklandığında seçili değeri (EditValue) null yaparak alanı temizler.
            // Yabancı anahtar (Foreign Key) ilişkilerinde kaydı boşaltmak için kritiktir.
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                this.EditValue = null;
            }
        }

        // Enter tuşuna basıldığında bir sonraki kontrole geçişi sağlar.
        public override bool EnterMoveNextControl { get; set; } = true;

        // IStatusBarKisaYol Implementasyonu
        // Başlangıç değerleri atandığı için CS8618 uyarısı oluşmaz.
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; } = "Seçim Yap";
        public string StatusBarAciklama { get; set; } = "Kayıt Seçiniz";
    }
}