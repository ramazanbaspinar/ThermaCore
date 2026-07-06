using DevExpress.XtraEditors;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ThermaCore.Presentation.WinForms.Helpers;
using ThermaCore.Presentation.WinForms.UserControls.Controls;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Docking2010.Customization;

namespace ThermaCore.Presentation.WinForms.Functions
{
    public static class SelectPictureFunctions
    {
        public static void Sec(this MyPictureEdit pictureEdit, DevExpress.XtraBars.PopupMenu menu)
        {
            pictureEdit.MouseUp += (sender, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    // Set the active picture edit as the tag of the menu
                    menu.Tag = pictureEdit;
                    
                    if (menu.Manager != null)
                        menu.ShowPopup(Control.MousePosition);
                }
            };
        }

        public static void ResimSec(this MyPictureEdit pictureEdit)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Resim Seç",
                Filter = "Resim Dosyaları (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp",
                RestoreDirectory = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var imageBytes = File.ReadAllBytes(ofd.FileName);
                    pictureEdit.IsModified = true;
                    pictureEdit.EditValue = imageBytes;
                }
                catch (System.Exception ex)
                {
                    Messages.UyariMesaji($"Resim yüklenirken hata oluştu: {ex.Message}");
                }
            }
        }

        public static void ResimSil(this MyPictureEdit pictureEdit)
        {
            pictureEdit.IsModified = true;
            pictureEdit.EditValue = null;
        }

        public static void ResimIndir(this MyPictureEdit pictureEdit)
        {
            if (pictureEdit.EditValue == null) return;

            using var sfd = new SaveFileDialog
            {
                Title = "Resmi Kaydet",
                Filter = "PNG Dosyası (*.png)|*.png|JPEG Dosyası (*.jpg)|*.jpg|Tüm Dosyalar (*.*)|*.*",
                DefaultExt = "png"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (pictureEdit.EditValue is byte[] bytes)
                    {
                        File.WriteAllBytes(sfd.FileName, bytes);
                    }
                    else if (pictureEdit.EditValue is Image img)
                    {
                        img.Save(sfd.FileName);
                    }
                }
                catch (System.Exception ex)
                {
                    Messages.UyariMesaji($"Resim kaydedilirken hata oluştu: {ex.Message}");
                }
            }
        }

        public static void ResimBuyut(this MyPictureEdit pictureEdit)
        {
            if (pictureEdit.EditValue == null) return;
            
            Image? img = null;
            if (pictureEdit.EditValue is byte[] bytes)
            {
                img = bytes.ToImage();
            }
            else if (pictureEdit.EditValue is Image existingImg)
            {
                img = existingImg;
            }

            if (img == null) return;

            var form = pictureEdit.FindForm();
            if (form == null) return;

            // Ana formu (MDI Parent veya AnaForm) bularak Flyout'un tüm uygulamayı kaplamasını sağlıyoruz.
            var mainForm = System.Windows.Forms.Application.OpenForms.Cast<Form>().FirstOrDefault(f => f.Name == "AnaForm") ?? form;
            
            // Tüm ana ekranı (formu) kaplaması için ana formun ClientSize'ını baz alıyoruz.
            // Kapat butonunun biraz daha yukarıda (sıkışmadan) durması için buton payını artırıyoruz (160px).
            var targetWidth = mainForm.ClientSize.Width - 20;
            var targetHeight = mainForm.ClientSize.Height - 160;

            var picViewer = new PictureEdit
            {
                Image = img,
                Properties = 
                {
                    SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom,
                    ShowMenu = false,
                    BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder,
                    AllowScrollViaMouseDrag = false
                },
                Dock = DockStyle.Fill
            };

            var uc = new XtraUserControl
            {
                Size = new Size(targetWidth, targetHeight),
                BackColor = Color.Transparent
            };
            uc.Controls.Add(picViewer);

            var action = new FlyoutAction() { Caption = "Resim Önizleme", Description = "Kapatmak için ESC tuşuna basabilir veya Kapat butonunu kullanabilirsiniz." };
            var command = new FlyoutCommand() { Text = "     KAPAT     ", Result = DialogResult.OK };
            action.Commands.Add(command);

            FlyoutDialog.Show(mainForm, action, uc);
        }
    }
}
