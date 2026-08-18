using DevExpress.XtraDataLayout;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System.ComponentModel;

namespace WinBeyazEsya.Presentation.WinForms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyDataLayoutControl : DataLayoutControl
    {
        public MyDataLayoutControl()
        {
            // --- İŞLEVSEL AYARLAR ---
            OptionsFocus.EnableAutoTabOrder = false; // Tab sırasını manuel yönetmek için.
            AllowCustomization = false; // Kullanıcının çalışma zamanında (runtime) sağ tıklayıp form düzenini bozmasını engeller.
        }

        protected override LayoutControlImplementor CreateILayoutControlImplementorCore()
        {
            return new MyLayoutControlImplementorPro(this);
        }

        private class MyLayoutControlImplementorPro : LayoutControlImplementor
        {
            public MyLayoutControlImplementorPro(ILayoutControlOwner controlOwner) : base(controlOwner)
            {
            }

            // CreateLayoutItem metodu sadece Font ataması yaptığı için kaldırıldı.
            // Tema (Skin) motoru etiket fontlarını otomatik ayarlayacak.

            public override LayoutGroup CreateLayoutGroup(LayoutGroup parent)
            {
                var grp = base.CreateLayoutGroup(parent);

                // Form düzeninin nizami durması için Tablo (Table) modu aktif ediliyor.
                grp.LayoutMode = LayoutMode.Table;

                // --- KOLON TANIMLAMALARI ---
                // 1. Kolon (Etiketler/Caption) : 200px sabit genişlik
                grp.OptionsTableLayoutGroup.ColumnDefinitions[0].SizeType = SizeType.Absolute;
                grp.OptionsTableLayoutGroup.ColumnDefinitions[0].Width = 200;

                // 2. Kolon (Veri Giriş Kontrolleri): %100 (kalan tüm alan)
                grp.OptionsTableLayoutGroup.ColumnDefinitions[1].SizeType = SizeType.Percent;
                grp.OptionsTableLayoutGroup.ColumnDefinitions[1].Width = 100;

                // 3. Kolon (Ekstra buton vs.): 99px sabit genişlik
                grp.OptionsTableLayoutGroup.ColumnDefinitions.Add(new ColumnDefinition { SizeType = SizeType.Absolute, Width = 99 });

                grp.OptionsTableLayoutGroup.RowDefinitions.Clear();

                // --- SATIR TANIMLAMALARI ---
                // İlk 9 satır standart veri girişi için 31px yüksekliğe sabitleniyor.
                // 10. satır ise formun altında kalan tüm boşluğu (%100) kaplayarak grid vb. kontrollerin sığmasını sağlıyor.
                for (int i = 0; i < 9; i++)
                {
                    grp.OptionsTableLayoutGroup.RowDefinitions.Add(new RowDefinition
                    {
                        SizeType = SizeType.Absolute,
                        Height = 31,
                    });

                    // Eğer döngü son elemana geldiyse, esnek bir satır daha ekle.
                    if (i + 1 == 9)
                    {
                        grp.OptionsTableLayoutGroup.RowDefinitions.Add(new RowDefinition
                        {
                            SizeType = SizeType.Percent,
                            Height = 100
                        });
                    }
                }

                return grp;
            }
        }
    }
}
