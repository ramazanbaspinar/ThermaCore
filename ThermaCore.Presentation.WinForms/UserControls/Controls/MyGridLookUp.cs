#pragma warning disable CS8618
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using ThermaCore.Presentation.WinForms.Interfaces;

namespace ThermaCore.Presentation.WinForms.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyGridLookUp : GridLookUpEdit, IStatusBarKisaYol
    {
        public MyGridLookUp()
        {
            Properties.Appearance.BackColor = Color.White;
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            Properties.NullText = "";
            Properties.Appearance.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceDropDown.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceFocused.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9f);
            Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Properties.Buttons.Clear();
            Properties.Buttons.AddRange(new EditorButton[] {
                new EditorButton(ButtonPredefines.Combo), 
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
        }

        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; } = "Seçim Yap";
        public string StatusBarAciklama { get; set; } = "Kayıt Seçiniz";
    }
}
