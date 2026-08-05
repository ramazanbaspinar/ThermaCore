using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraVerticalGrid;
using Microsoft.Win32;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Presentation.WinForms.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WinBeyazEsya.Presentation.WinForms.Helpers
{
    public static class UIExtensions
    {
        public static long GetRowId(this GridView tablo, bool mesajVer = true)
        {
            if (tablo.FocusedRowHandle > -1) return (long)tablo.GetFocusedRowCellValue("Id");

            if (mesajVer)
                Messages.UyariMesaji("Lütfen bir kayıt seçiniz.");

            return -1;
        }

        public static long GetirUstSatirId(this GridView tablo, string yazidrmaHataMesaj)
        {
            int ustSatirIndex = tablo.FocusedRowHandle - 1;

            if (ustSatirIndex >= 0) return (long)tablo.GetRowCellValue(ustSatirIndex, "Id");

            Messages.UyariMesaji(yazidrmaHataMesaj);
            return -1;
        }

        public static long GetirAltSatirId(this GridView tablo, string yazidrmaHataMesaj)
        {
            int altSatirIndex = tablo.FocusedRowHandle + 1;

            if (altSatirIndex < tablo.RowCount)
                return (long)tablo.GetRowCellValue(altSatirIndex, "Id");

            Messages.UyariMesaji(yazidrmaHataMesaj);
            return -1;
        }

        public static long GetRowId(this GridView tablo, string yazidrmaHataMesaj)
        {
            if (tablo.FocusedRowHandle > -1) return (long)tablo.GetFocusedRowCellValue("Id");
            Messages.UyariMesaji(yazidrmaHataMesaj);
            return -1;
        }

        public static long GetRowCellId(this GridView tablo, GridColumn idColumn)
        {
            var value = tablo.GetRowCellValue(tablo.FocusedRowHandle, idColumn);
            return (long?)value ?? -1;
        }

        public static T GetRow<T>(this GridView tablo, bool mesajVer = true)
        {
            if (tablo.FocusedRowHandle > -1) return (T)tablo.GetRow(tablo.FocusedRowHandle);

            if (mesajVer)
                Messages.UyariMesaji("Lütfen bir kayıt seçiniz.");

            return default(T)!;
        }

        public static T GetirUstSatir<T>(this GridView tablo, bool mesajVer = true)
        {
            if (tablo.FocusedRowHandle > -1) return (T)tablo.GetRow(tablo.FocusedRowHandle - 1);

            if (mesajVer)
                Messages.UyariMesaji("Lütfen bir kayıt seçiniz.");

            return default(T)!;
        }

        public static T GetirAltSatir<T>(this GridView tablo, bool mesajVer = true)
        {
            if (tablo.FocusedRowHandle > -1) return (T)tablo.GetRow(tablo.FocusedRowHandle + 1);

            if (mesajVer)
                Messages.UyariMesaji("Lütfen bir kayıt seçiniz.");

            return default(T)!;
        }

        public static T GetRow<T>(this GridView tablo, int rowHandle)
        {
            if (tablo.FocusedRowHandle > -1) return (T)tablo.GetRow(rowHandle);
            Messages.UyariMesaji("Lütfen bir kayıt seçiniz.");
            tablo.FocusedRowHandle = 0;
            return default(T)!;
        }

        public static void CopyProperties<T>(T source, T destination)
        {
            var properties = typeof(T).GetProperties().Where(p => p.CanRead && p.CanWrite);
            foreach (var prop in properties)
            {
                var value = prop.GetValue(source, null);
                prop.SetValue(destination, value, null);
            }
        }

        public static void CopyMatchingProperties<TSource, TDestination>(TSource source, TDestination destination)
        {
            var sourceProps = typeof(TSource).GetProperties().Where(p => p.CanRead).ToList();
            var destProps = typeof(TDestination).GetProperties().Where(p => p.CanWrite).ToList();

            foreach (var sourceProp in sourceProps)
            {
                var destProp = destProps.FirstOrDefault(p => p.Name == sourceProp.Name && p.PropertyType == sourceProp.PropertyType);
                if (destProp != null)
                {
                    var value = sourceProp.GetValue(source, null);
                    destProp.SetValue(destination, value, null);
                }
            }
        }

        private static VeriDegisimYeri VeriDegisimYeriGetir<T>(T oldEntity, T currentEntity)
        {
            if (oldEntity == null || currentEntity == null) return VeriDegisimYeri.VeriDegisimiYok;

            foreach (var prop in currentEntity.GetType().GetProperties())
            {
                if (prop.PropertyType.Namespace == "System.Collections.Generic") continue;

                if (prop.PropertyType.IsClass &&
                    prop.PropertyType != typeof(string) &&
                    prop.PropertyType != typeof(byte[]) &&
                    prop.PropertyType != typeof(System.Security.SecureString))
                    continue;

                var oldValue = prop.GetValue(oldEntity) ?? string.Empty;
                var currentValue = prop.GetValue(currentEntity) ?? string.Empty;

                if (prop.PropertyType == typeof(byte[]))
                {
                    if (string.IsNullOrEmpty(oldValue.ToString())) oldValue = new byte[] { 0 };
                    if (string.IsNullOrEmpty(currentValue.ToString())) currentValue = new byte[] { 0 };

                    if (((byte[])oldValue).Length != ((byte[])currentValue).Length)
                        return VeriDegisimYeri.Alan;
                }
                else if (prop.PropertyType == typeof(System.Security.SecureString))
                {
                    var oldStr = new System.Net.NetworkCredential(string.Empty, (System.Security.SecureString)oldValue).Password;
                    var curStr = new System.Net.NetworkCredential(string.Empty, (System.Security.SecureString)currentValue).Password;

                    if (!oldStr.Equals(curStr))
                        return VeriDegisimYeri.Alan;
                }
                else if (!currentValue.Equals(oldValue))
                {
                    return VeriDegisimYeri.Alan;
                }
            }
            return VeriDegisimYeri.VeriDegisimiYok;
        }

        public static void ButtonEnabledDurumu<T>(BarButtonItem btnYeni, BarButtonItem btnKaydet, BarButtonItem btnGeriAl, BarButtonItem btnSil, BarButtonItem btnYenile, BarButtonItem btnYazdir, BarButtonItem btnYazdir2, T oldEntity, T currentEntity, ActionType islemTuru)
        {
            bool buttonEnabledDurumu;
            if (islemTuru == ActionType.EntityInsert)
            {
                buttonEnabledDurumu = true;
            }
            else
            {
                var veriDegisimYeri = VeriDegisimYeriGetir(oldEntity, currentEntity);
                buttonEnabledDurumu = veriDegisimYeri == VeriDegisimYeri.Alan;
            }

            if (btnKaydet != null) btnKaydet.Enabled = buttonEnabledDurumu;
            if (btnGeriAl != null) btnGeriAl.Enabled = buttonEnabledDurumu;
            if (btnYeni != null) btnYeni.Enabled = !buttonEnabledDurumu;
            if (btnSil != null) btnSil.Enabled = !buttonEnabledDurumu;
            if (btnYenile != null) btnYenile.Enabled = !buttonEnabledDurumu;
            if (btnYazdir != null) btnYazdir.Enabled = !buttonEnabledDurumu;
            if (btnYazdir2 != null) btnYazdir2.Enabled = !buttonEnabledDurumu;
        }

        public static void ButtonEnabledDurumu<T>(BarButtonItem btnYeni, BarButtonItem btnKaydet, BarButtonItem btnGeriAl, BarButtonItem btnSil, T oldEntity, T currentEntity, bool tableValueChanged)
        {
            var veriDegisimYeri = tableValueChanged ? VeriDegisimYeri.Tablo : VeriDegisimYeriGetir(oldEntity, currentEntity);
            var buttonEnableDurum = veriDegisimYeri == VeriDegisimYeri.Alan || veriDegisimYeri == VeriDegisimYeri.Tablo;

            if (btnKaydet != null) btnKaydet.Enabled = buttonEnableDurum;
            if (btnGeriAl != null) btnGeriAl.Enabled = buttonEnableDurum;
            if (btnYeni != null) btnYeni.Enabled = !buttonEnableDurum;
            if (btnSil != null) btnSil.Enabled = !buttonEnableDurum;
        }

        public static void ButtonEnabledDurumu<T>(BarButtonItem btnKaydet, BarButtonItem btnFarkliKaydet, BarButtonItem btnSil, ActionType islemTuru, T oldEntity, T currentEntity)
        {
            var veriDegisimYeri = VeriDegisimYeriGetir(oldEntity, currentEntity);
            var buttonEnabledDurumu = veriDegisimYeri == VeriDegisimYeri.Alan;

            if (btnKaydet != null) btnKaydet.Enabled = buttonEnabledDurumu;
            if (btnFarkliKaydet != null) btnFarkliKaydet.Enabled = islemTuru != ActionType.EntityInsert;
            if (btnSil != null) btnSil.Enabled = !buttonEnabledDurumu;
        }

        public static long IdOlustur(this ActionType islemTuru, BaseDto selectedEntity)
        {
            return islemTuru == ActionType.EntityUpdate ? selectedEntity.Id : WinBeyazEsya.Domain.Helpers.IdGenerator.GenerateId();
        }

        public static void ControlEnabledChange(object baseEdit, Control prmEdit)
        {
        }

        public static void RowFocus(this GridView tablo, string aranacakKolon, object aranacakDeger)
        {
            var rowHandle = 0;

            for (int i = 0; i < tablo.RowCount; i++)
            {
                var bulunanDeger = tablo.GetRowCellValue(i, aranacakKolon);

                if (aranacakDeger != null && aranacakDeger.Equals(bulunanDeger))
                    rowHandle = i;
            }

            tablo.FocusedRowHandle = rowHandle;
        }

        public static void RowFocus(this GridView tablo, int rowHandle)
        {
            if (rowHandle <= 0) return;

            if (rowHandle == tablo.RowCount - 1)
                tablo.FocusedRowHandle = rowHandle;
            else
                tablo.FocusedRowHandle = rowHandle - 1;
        }

        public static void SagTikMenuGoster(this MouseEventArgs e, PopupMenu sagMenu)
        {
            if (e.Button != MouseButtons.Right) return;
            sagMenu.ShowPopup(Control.MousePosition);
        }

        public static List<string> YazicilariListele()
        {
            return PrinterSettings.InstalledPrinters.Cast<string>().ToList();
        }

        public static string DefaultYazici()
        {
            var settings = new PrinterSettings();
            return settings.PrinterName;
        }

        public static void ShowPopupMenu(this MouseEventArgs e, PopupMenu popupMenu)
        {
            if (e.Button != MouseButtons.Right) return;
            popupMenu.ShowPopup(Control.MousePosition);
        }

        public static byte[]? ResimYukle()
        {
            var dialog = new System.Windows.Forms.OpenFileDialog
            {
                Title = "Resim Seç",
                Filter = "Resim Dosyaları (*.bmp, *.gif, *.jpg, *.jpeg, *.png)|*.bmp; *.gif; *.jpg; *.jpeg; *.png|Bmp Dosyaları|*.bmp|Gif Dosyaları|*.gif|Jpg Dosyaları|*.jpg|Jpeg Dosyaları|*.jpeg|Png Dosyaları|*.png",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            };

            byte[] Resim()
            {
                using (var stream = new MemoryStream())
                {
                    Image.FromFile(dialog.FileName).Save(stream, ImageFormat.Png);
                    return stream.ToArray();
                }
            }

            return dialog.ShowDialog() != DialogResult.OK ? null : Resim();
        }

        public static void LayoutControlInsert(this LayoutGroup grup, Control control, int columnIndex, int rowIndex, int columnSpan, int rowSpan)
        {
            var item = new LayoutControlItem
            {
                Control = control,
                Parent = grup
            };

            item.OptionsTableLayoutItem.ColumnIndex = columnIndex;
            item.OptionsTableLayoutItem.RowIndex = rowIndex;
            item.OptionsTableLayoutItem.ColumnSpan = columnSpan;
            item.OptionsTableLayoutItem.RowSpan = rowSpan;
        }

        public static void RowCellEnabled(this GridView tablo)
        {
            var rowHandle = tablo.FocusedRowHandle;

            tablo.FocusedRowHandle = 0;
            tablo.ClearSelection();

            tablo.FocusedRowHandle = rowHandle;
        }

        public static void CreateDropDownMenu(this BarButtonItem baseButton, BarItem[] buttonItems)
        {
            baseButton.ButtonStyle = BarButtonStyle.CheckDropDown;
            var popupMenu = new PopupMenu();
            buttonItems.ForEach(x => x.Visibility = BarItemVisibility.Always);
            popupMenu.ItemLinks.AddRange(buttonItems);
            baseButton.DropDownControl = popupMenu;
        }
        
        public static MemoryStream ByteToStream(this byte[] report)
        {
            return new MemoryStream(report);
        }

        public static MemoryStream ReportToStream(this XtraReport rapor)
        {
            var stream = new MemoryStream();
            rapor.SaveLayout(stream);
            return stream;
        }

        public static void AppSettingsWrite(string key, string value)
        {

            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static string Md5Sifrele(this string value)
        {
            using var md5 = MD5.Create();
            var byteDiziBuffer = Encoding.UTF8.GetBytes(value);
            byteDiziBuffer = md5.ComputeHash(byteDiziBuffer);

            var md5Sifre = BitConverter.ToString(byteDiziBuffer).Replace("-", ""); 

            return md5Sifre;
        }

        public static void LoginYapanSonKullaniciyiKaydet(string kullaniciAdi)
        {
            RegistryKey? key = Registry.CurrentUser.CreateSubKey(@"Software\WinBeyazEsya\AppSettings\Startup");
            if (key != null)
            {
                key.SetValue("LoginYapanSonKullanici", kullaniciAdi);
                key.Close();
            }
        }

        public static string LoginYapanSonKullaniciyiGetir()
        {
            RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"Software\WinBeyazEsya\AppSettings\Startup");
            if (key != null)
            {
                object? kullaniciAdi = key.GetValue("LoginYapanSonKullanici");
                key.Close();
                return kullaniciAdi != null ? kullaniciAdi.ToString()! : string.Empty;
            }
            return string.Empty;
        }

        private static readonly string encryptionKey = "S3cureK3y"; 

        public static string Encrypt(string plainText)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(encryptionKey.PadRight(32)); 
                aes.IV = new byte[16]; 
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(plainBytes, 0, plainBytes.Length);
                        cs.Close();
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText)) return string.Empty;

            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(encryptionKey.PadRight(32));
                aes.IV = new byte[16];
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }

        public static void SplashBaslat(SplashScreenManager manager, Point? location = null)
        {
            if (location.HasValue)
            {
                manager.SplashFormStartPosition = SplashFormStartPosition.Manual;
                manager.SplashFormLocation = location.Value;
            }
            if (manager.IsSplashFormVisible)
                manager.CloseWaitForm();

            manager.ShowWaitForm();
        }

        public static void SplashDurdur(SplashScreenManager manager)
        {
            if (manager.IsSplashFormVisible)
                manager.CloseWaitForm();
        }
    }
}

