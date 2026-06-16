using DevExpress.XtraBars;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using ThermaCore.Application.DTOs.Base;
using ThermaCore.Application.Interfaces.System;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Presentation.WinForms.Forms.BaseForms
{
    public partial class BaseEditForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected long Id;
        protected IslemTuru BaseIslemTuru;
        protected bool IsLoaded;
        protected BaseDto OldEntity = default!;
        protected BaseDto CurrentEntity = default!;
        protected bool FormSablonKaydet = true;

        // UI nesnelerinin eksikliği nedeniyle derleme hatası vermemesi için
        public BarStaticItem statusBarAciklama { get; set; } = new BarStaticItem();
        public BarStaticItem statusBarKisaYol { get; set; } = new BarStaticItem();
        public BarStaticItem statusBarKisaYolAciklama { get; set; } = new BarStaticItem();

        public BaseEditForm()
        {
            if (!IsDesignMode)
            {
                this.Load += BaseEditForm_Load;
                this.FormClosing += BaseEditForm_FormClosing;
            }
        }

        protected bool IsDesignMode => LicenseManager.UsageMode == LicenseUsageMode.Designtime || this.DesignMode;

        private void BaseEditForm_Load(object? sender, EventArgs e)
        {
            if (IsDesignMode) return;
            
            try 
            {
                var layoutService = Program.ServiceProvider?.GetService<ILayoutService>();
                // İleride XML layout yükleme kodları eklenecek
            }
            catch { }
            
            Yukle();
            ButonEnabledDurumu();
        }

        private void BaseEditForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (IsDesignMode) return;
            
            try 
            {
                if (FormSablonKaydet)
                {
                    var layoutService = Program.ServiceProvider?.GetService<ILayoutService>();
                    // İleride XML layout kaydetme kodları eklenecek
                }
            }
            catch { }
        }

        protected virtual void Button_ItemClick(object? sender, ItemClickEventArgs e)
        {
            if (IsDesignMode) return;

            switch (e.Item.Name)
            {
                case "btnKaydet":
                    Kaydet(false);
                    break;
                case "btnGeriAl":
                    Yukle();
                    break;
                case "btnSil":
                    EntityDelete();
                    break;
                case "btnCikis":
                    this.Close();
                    break;
            }
        }

        protected bool Kaydet(bool kapanis)
        {
            bool islemSonucu = false;

            GuncelNesneOlustur();

            if (BaseIslemTuru == IslemTuru.EntityInsert)
            {
                if (MessageBox.Show("Yeni kayıt eklenecektir. Onaylıyor musunuz?", "Kayıt Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    islemSonucu = EntityInsert();
                }
            }
            else if (BaseIslemTuru == IslemTuru.EntityUpdate)
            {
                if (MessageBox.Show("Mevcut kayıt güncellenecektir. Onaylıyor musunuz?", "Güncelleme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    islemSonucu = EntityUpdate();
                }
            }

            if (islemSonucu && kapanis)
            {
                this.Close();
            }
            else if (islemSonucu)
            {
                Yukle(); // Kayıt sonrası güncel veriyi ekrana yansıt
            }

            return islemSonucu;
        }

        protected virtual void Yukle() { }
        protected virtual void GuncelNesneOlustur() { }
        protected virtual void NesneyiKontrollereBagla() { }
        protected virtual bool EntityInsert() { return false; }
        protected virtual bool EntityUpdate() { return false; }
        protected virtual void EntityDelete() { }
        public virtual void ButonEnabledDurumu() { }
    }
}