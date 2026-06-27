using DevExpress.XtraEditors;
using System;
using System.Linq;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.DTOs.Security;
using ThermaCore.Application.Interfaces.Management;
using ThermaCore.Application.Interfaces.Security;
using ThermaCore.Application.Interfaces.System;
using ThermaCore.Application.Services.Management;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Forms.YetkilendirmeForms;
using ThermaCore.Presentation.WinForms.Helpers;


namespace ThermaCore.Presentation.WinForms.Forms.KullaniciForms
{
    public partial class KullaniciEditForm : BaseEditForm
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly ITenantDatabaseCrudService _tenantService;
        private readonly IBranchService _branchService;

        public KullaniciEditForm(IUserService userService, IRoleService roleService, ITenantDatabaseCrudService tenantService, IBranchService branchService)
        {
            InitializeComponent();
            _userService = userService;
            _roleService = roleService;
            _tenantService = tenantService;
            _branchService = branchService;

            BaseKartTuru = Domain.Enums.ModuleType.User;
            DataLayoutControl = new object[] { myDataLayoutControl1, myDataLayoutControl2 };
            Bll = _userService;
        }


        protected override void EventsLoad()
        {
            base.EventsLoad();
            glufRol.SearchButtonClicked += GlufRol_SearchButtonClicked;
            clbSirketler.ItemCheck += ClbSirketler_ItemCheck;
            clbFabrikalar.ItemCheck += ClbFabrikalar_ItemCheck;
        }

        private void ClbFabrikalar_ItemCheck(object? sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (_isBinding) return;

            this.BeginInvoke(new Action(() => 
            {
                _isCheckedListBoxModified = true;
                ButonEnabledDurumu();
            }));
        }

        private void ClbSirketler_ItemCheck(object? sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (_isBinding) return; // Yukle metodu sırasında tetiklenmemesi için

            this.BeginInvoke(new Action(() => 
            {
                _isCheckedListBoxModified = true;
                FabrikalariDoldur();
                ButonEnabledDurumu();
            }));
        }

        private void FabrikalariDoldur()
        {
            var seciliSirketIdleri = new System.Collections.Generic.List<long>();
            foreach (int index in clbSirketler.CheckedIndices)
            {
                var val = clbSirketler.GetItemValue(index);
                if (val != null && long.TryParse(val.ToString(), out long sirketId))
                {
                    seciliSirketIdleri.Add(sirketId);
                }
            }

            // Save currently checked branch IDs before rebinding
            var oncedenSeciliFabrikaIdleri = new System.Collections.Generic.List<long>();
            foreach (int index in clbFabrikalar.CheckedIndices)
            {
                var val = clbFabrikalar.GetItemValue(index);
                if (val != null && long.TryParse(val.ToString(), out long fabrikaId))
                {
                    oncedenSeciliFabrikaIdleri.Add(fabrikaId);
                }
            }

            var butunFabrikalar = _branchService.GetActiveBranches().ToList();
            var filtrelenmisFabrikalar = butunFabrikalar.Where(x => seciliSirketIdleri.Contains(x.TenantDatabaseId)).ToList();

            clbFabrikalar.DataSource = filtrelenmisFabrikalar;
            clbFabrikalar.ValueMember = "Id";
            clbFabrikalar.DisplayMember = "BranchName";

            // Restore checks for branches that are still in the list
            for (int i = 0; i < clbFabrikalar.ItemCount; i++)
            {
                var itemValue = clbFabrikalar.GetItemValue(i);
                if (itemValue != null && long.TryParse(itemValue.ToString(), out long fabrikaId))
                {
                    if (oncedenSeciliFabrikaIdleri.Contains(fabrikaId))
                    {
                        clbFabrikalar.SetItemChecked(i, true);
                    }
                }
            }
        }

        public override void Yukle()
        {
            // GridLookUpFind için datasource doldur
            var roller = _roleService.GetActiveRoles().ToList();
            glufRol.Properties.DataSource = roller;
            glufRol.Properties.ValueMember = "Id";
            glufRol.Properties.DisplayMember = "RoleName";

            var sirketler = _tenantService.GetActiveTenants().ToList();
            clbSirketler.DataSource = sirketler;
            clbSirketler.ValueMember = "Id";
            clbSirketler.DisplayMember = "CompanyName";

            // İlk açılışta fabrikalar boş olmalı, Sirket seçiminden sonra dolacak.
            clbFabrikalar.DataSource = null;

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                OldEntity = new UserDto { IsActive = true };
                Id = -1;
            }
            else
            {
                OldEntity = _userService.GetById(Id);
            }

            NesneyiKontrollereBagla();
            ButonEnabledDurumu();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (UserDto)OldEntity;
            
            txtKullaniciAdi.Text = entity.Code;
            myDataLayoutControl1.Text = entity.FirstName;
            txtSoyad.Text = entity.LastName;
            txtEmail.Text = entity.Email;
            txtSifre.Text = Id > 0 ? "********" : ""; // Şifre kutusu güncelleme modunda ******** dolar
            glufRol.EditValue = entity.UserRoleId == 0 ? (long?)null : entity.UserRoleId;
            tglDurum.IsOn = entity.IsActive;

            if (entity.UserTenants != null)
            {
                for (int i = 0; i < clbSirketler.ItemCount; i++)
                {
                    var itemValue = clbSirketler.GetItemValue(i);
                    if (itemValue != null && long.TryParse(itemValue.ToString(), out long sirketId))
                    {
                        if (entity.UserTenants.Any(x => x.TenantDatabaseId == sirketId))
                        {
                            clbSirketler.SetItemChecked(i, true);
                        }
                    }
                }
            }

            FabrikalariDoldur(); // Şirketler işaretlendikten sonra listeyi doldur

            if (entity.UserBranches != null)
            {
                for (int i = 0; i < clbFabrikalar.ItemCount; i++)
                {
                    var itemValue = clbFabrikalar.GetItemValue(i);
                    if (itemValue != null && long.TryParse(itemValue.ToString(), out long fabrikaId))
                    {
                        if (entity.UserBranches.Any(x => x.BranchId == fabrikaId))
                        {
                            clbFabrikalar.SetItemChecked(i, true);
                        }
                    }
                }
            }
        }

        protected override void FocusControlByPropertyName(string propertyName)
        {
            base.FocusControlByPropertyName(propertyName);

            // Base'deki genel bulucu eşleşmezse özel durumlar:
            if (propertyName == nameof(UserDto.UserRoleId))
            {
                glufRol.Focus();
            }
            else if (propertyName == nameof(UserDto.IsActive))
            {
                tglDurum.Focus();
            }
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new UserDto
            {
                Id = Id,
                Code = txtKullaniciAdi.Text,
                FirstName = myDataLayoutControl1.Text,
                LastName = txtSoyad.Text,
                Email = txtEmail.Text,
                Password = txtSifre.Text == "********" ? "" : txtSifre.Text, // Eğer ******** ise veya boşsa arkada eski şifre korunacak (UserService)
                UserRoleId = glufRol.EditValue != null && glufRol.EditValue != DBNull.Value ? Convert.ToInt64(glufRol.EditValue) : 0,
                IsActive = tglDurum.IsOn
            };

            var currentDto = (UserDto)CurrentEntity;

            foreach (int index in clbSirketler.CheckedIndices)
            {
                var val = clbSirketler.GetItemValue(index);
                if (val != null && long.TryParse(val.ToString(), out long sirketId))
                {
                    currentDto.UserTenants.Add(new UserTenantDto { TenantDatabaseId = sirketId });
                }
            }

            foreach (int index in clbFabrikalar.CheckedIndices)
            {
                var val = clbFabrikalar.GetItemValue(index);
                if (val != null && long.TryParse(val.ToString(), out long fabrikaId))
                {
                    currentDto.UserBranches.Add(new UserBranchDto { BranchId = fabrikaId });
                }
            }
            
            ButonEnabledDurumu();
        }

        protected internal override void ButonEnabledDurumu()
        {
            base.ButonEnabledDurumu();

            if (_isCheckedListBoxModified)
            {
                // AutoMapper N-N koleksiyonlarını ignore ettiği için manuel bypass
                if (btnKaydet != null) btnKaydet.Enabled = true;
                if (btnGerial != null) btnGerial.Enabled = true;
                if (btnYeni != null) btnYeni.Enabled = false;
                if (btnSil != null) btnSil.Enabled = false;
            }
        }

        private void GlufRol_SearchButtonClicked(object? sender, EventArgs e)
        {
            using (var frm = new RolListForm())
            {
                frm.EklenebilecekEntityVar = true; // Seçim modu aktif
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.SelectedEntities != null && frm.SelectedEntities.Count > 0)
                    {
                        var seciliRol = frm.SelectedEntities[0] as RoleDto;
                        if (seciliRol != null)
                        {
                            // Listeye yeni eklenmiş olabilecek kayıtlar için veri kaynağını tazele
                            glufRol.Properties.DataSource = _roleService.GetActiveRoles().ToList();
                            glufRol.EditValue = seciliRol.Id;
                        }
                    }
                }
            }
        }

        protected override bool EntityInsert()
        {
            var dto = (UserDto)CurrentEntity;
            dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
            Id = _userService.Insert(dto);
            return true;
        }

        protected override bool EntityUpdate()
        {
            var dto = (UserDto)CurrentEntity;
            _userService.Update(dto);
            return true;
        }

        protected override void EntityDelete()
        {
            if (Id <= 0) return;
            if (Messages.SilMesaj("Kullanıcı") == DialogResult.Yes)
            {
                try
                {
                    _userService.Delete(Id);
                    RefreshYapilacak = true;
                    Close();
                }
                catch (Exception ex)
                {
                    Messages.HataMesaji(ex.Message);
                }
            }
        }
    }
}