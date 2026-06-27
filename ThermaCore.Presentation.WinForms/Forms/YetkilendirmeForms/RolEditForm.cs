using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThermaCore.Application.DTOs.Security;
using ThermaCore.Domain.Enums;
using ThermaCore.Application.Interfaces.Security;
using ThermaCore.Presentation.WinForms.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.YetkilendirmeForms
{
    public partial class RolEditForm : BaseEditForm
    {
        private readonly IRoleService _roleService;
        private string _originalPermissionsJson = string.Empty;

        protected override string CodeControlName => "txtRolKodu";

        public RolEditForm()
        {
            InitializeComponent();
            _roleService = Program.ServiceProvider.GetService<IRoleService>()!;

            BaseKartTuru = Domain.Enums.ModuleType.YetkiGruplari;
            DataLayoutControl = myDataLayoutControl1;
            Bll = _roleService;
        }

        public override void Yukle()
        {
            treeList1.KeyFieldName = "Id";
            treeList1.ParentFieldName = "ParentId";

            List<RolePermissionDto> permissionDtos;

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                OldEntity = new RoleDto();
                Id = -1;
                permissionDtos = _roleService.GetEmptyPermissions().ToList();
            }
            else
            {
                OldEntity = _roleService.GetById(Id);
                permissionDtos = _roleService.GetRolePermissions(Id).ToList();
            }
            
            var permissionNodes = ConvertToPermissionNodes(permissionDtos);
            _originalPermissionsJson = System.Text.Json.JsonSerializer.Serialize(permissionNodes);
            treeList1.DataSource = permissionNodes;

            treeList1.OptionsView.ShowCheckBoxes = true;
            treeList1.CheckBoxFieldName = "IsChecked";
            treeList1.OptionsBehavior.AllowRecursiveNodeChecking = false; // Kendi mantığımızı yazacağız
            treeList1.OptionsView.ShowAutoFilterRow = true;
            treeList1.NodeCellStyle += TreeList1_NodeCellStyle;
            treeList1.CustomNodeCellEdit += TreeList1_CustomNodeCellEdit;
            treeList1.CustomDrawNodeCheckBox += TreeList1_CustomDrawNodeCheckBox;
            treeList1.BeforeCheckNode += TreeList1_BeforeCheckNode;
            treeList1.ShowingEditor += TreeList1_ShowingEditor;
            repositoryItemButtonEdit1.ButtonClick += RepositoryItemButtonEdit1_ButtonClick;
            
            // TextEditStyle'ı düzenlenemez yapıyoruz, sadece butona tıklanabilsin.
            repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            treeList1.PopupMenuShowing += TreeList1_PopupMenuShowing;

            treeList1.PopulateColumns();
            foreach (DevExpress.XtraTreeList.Columns.TreeListColumn col in treeList1.Columns)
            {
                if (col.FieldName == "Name")
                {
                    col.Caption = "Yetki / Modül Adı";
                    col.Visible = true;
                    // Buton editörünün tıklanabilmesi için AllowEdit true olmalı
                    // Fakat ShowingEditor event'i ile diğer satırların düzenlenmesini engelleyeceğiz.
                    col.OptionsColumn.AllowEdit = true;
                    col.VisibleIndex = 0;
                }
                else
                {
                    col.Visible = false;
                }
            }

            NesneyiKontrollereBagla();
            treeList1.CollapseAll();

            if (txtRolKodu.Text == "ADMIN_ROLE" && BaseIslemTuru == ActionType.EntityUpdate)
            {
                treeList1.OptionsBehavior.Editable = false;
                treeList1.Enabled = false; // Ağaç listesi tıklanamaz hale gelir
                txtRolKodu.Properties.ReadOnly = true;
                txtRolAdi.Properties.ReadOnly = true;
                txtAciklama.Properties.ReadOnly = true;
                tglDurum.Properties.ReadOnly = true;
                tglDurum.Enabled = false;
            }
            else
            {
                treeList1.OptionsBehavior.Editable = true;
                treeList1.Enabled = true;
                txtRolKodu.Properties.ReadOnly = false;
                txtRolAdi.Properties.ReadOnly = false;
                txtAciklama.Properties.ReadOnly = false;
                tglDurum.Properties.ReadOnly = false;
                tglDurum.Enabled = true;
            }

            // İlk yüklemede, parent (Modül ve Klasör) check durumlarını çocukların durumuna göre gerçek zamanlı düzelt (E-mail vs için)
            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node in treeList1.GetNodeList())
            {
                if (!node.HasChildren)
                {
                    UpdateParentChecked(node);
                }
            }

            // Düzenleme sonucu değişen TreeList Datasource'u baz alarak orjinal JSON'ı yeniden oluştur (Değişiklik olmadan Kaydet butonunun aktifleşmesi bug fix)
            if (treeList1.DataSource != null)
            {
                var currentNodes = (List<ThermaCore.Presentation.WinForms.Models.PermissionNodeDto>)treeList1.DataSource;
                _originalPermissionsJson = System.Text.Json.JsonSerializer.Serialize(currentNodes);
            }

            // Kontrol değişikliklerinde Kaydet butonunu aktif etmek için event'leri bağlıyoruz
            txtRolKodu.EditValueChanged += Control_EditValueChanged;
            txtRolAdi.EditValueChanged += Control_EditValueChanged;
            txtAciklama.EditValueChanged += Control_EditValueChanged;
            tglDurum.EditValueChanged += Control_EditValueChanged;
            
            // TreeList hücre veya check değişikliklerinde Kaydet butonunu tetikle
            treeList1.CellValueChanged += (s, e) => {
                GuncelNesneOlustur();
                ButonEnabledDurumu();
            };
            treeList1.AfterCheckNode += TreeList1_AfterCheckNode;
        }

        private void SetChildrenChecked(DevExpress.XtraTreeList.Nodes.TreeListNode node, bool isChecked)
        {
            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode child in node.Nodes)
            {
                var pTypeObj = child.GetValue("PermissionType");
                var modObj = child.GetValue("ModuleId");

                if (pTypeObj != null && (pTypeObj.ToString() == "Special" || pTypeObj.ToString() == "5")) continue;

                if (pTypeObj != null && modObj != null)
                {
                    var modType = (ModuleType)Convert.ToInt32(modObj);
                    if (modType == ModuleType.EmailParameter || modType == ModuleType.SystemLicense || modType == ModuleType.KodLog || modType == ModuleType.TerminalYonetimi)
                    {
                        if (pTypeObj.ToString() == "Create" || pTypeObj.ToString() == "1" || 
                            pTypeObj.ToString() == "Delete" || pTypeObj.ToString() == "3")
                        {
                            continue; // Bu yetkiler yok sayılır
                        }
                    }
                    else if (modType == ModuleType.UserInterfaceTemplate)
                    {
                        if (pTypeObj.ToString() == "Create" || pTypeObj.ToString() == "1" || pTypeObj.ToString() == "2" ||
                            pTypeObj.ToString() == "Update" || pTypeObj.ToString() == "3")
                        {
                            continue; // Bu yetkiler yok sayılır
                        }
                    }
                }
                
                child.Checked = isChecked;
                child.SetValue("IsChecked", isChecked);
                
                if (child.HasChildren)
                    SetChildrenChecked(child, isChecked);
            }
        }

        private void UpdateParentChecked(DevExpress.XtraTreeList.Nodes.TreeListNode node)
        {
            if (node.ParentNode != null)
            {
                int checkedCount = 0;
                int validCount = 0;
                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode child in node.ParentNode.Nodes)
                {
                    var pTypeObj = child.GetValue("PermissionType");
                    var modObj = child.GetValue("ModuleId");

                    if (pTypeObj != null && (pTypeObj.ToString() == "Special" || pTypeObj.ToString() == "5")) continue;

                    if (pTypeObj != null && modObj != null)
                    {
                        var modType = (ModuleType)Convert.ToInt32(modObj);
                        if (modType == ModuleType.EmailParameter || modType == ModuleType.SystemLicense || modType == ModuleType.KodLog || modType == ModuleType.TerminalYonetimi)
                        {
                            if (pTypeObj.ToString() == "Create" || pTypeObj.ToString() == "1" || 
                                pTypeObj.ToString() == "Delete" || pTypeObj.ToString() == "3")
                            {
                                continue; // Sayıma katma!
                            }
                        }
                        else if (modType == ModuleType.UserInterfaceTemplate)
                        {
                            if (pTypeObj.ToString() == "Create" || pTypeObj.ToString() == "1" || pTypeObj.ToString() == "2" ||
                                pTypeObj.ToString() == "Update" || pTypeObj.ToString() == "3")
                            {
                                continue; // Sayıma katma!
                            }
                        }
                    }
                    
                    validCount++;
                    if (child.Checked) checkedCount++;
                }

                bool parentChecked = (checkedCount == validCount && validCount > 0);
                node.ParentNode.CheckState = parentChecked ? CheckState.Checked : CheckState.Unchecked;
                node.ParentNode.SetValue("IsChecked", parentChecked);
                
                UpdateParentChecked(node.ParentNode);
            }
        }

        private void TreeList1_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            treeList1.BeginUpdate();
            try
            {
                bool isChecked = e.Node.Checked;
                e.Node.SetValue("IsChecked", isChecked);

                if (e.Node.HasChildren)
                {
                    SetChildrenChecked(e.Node, isChecked);
                }
                
                UpdateParentChecked(e.Node);
            }
            finally
            {
                treeList1.EndUpdate();
            }

            GuncelNesneOlustur();
            ButonEnabledDurumu();
        }

        private void TreeList1_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            e.Allow = false; // DevExpress'in varsayılan menüsünü tamamen iptal et ki İngilizce menü anlık olarak gözükmesin

            var menu = new DevExpress.Utils.Menu.DXPopupMenu();

            var itemSelectAll = new DevExpress.Utils.Menu.DXMenuItem("Tüm Yetkileri Seç");
            itemSelectAll.Click += (s, ev) => SetAllNodesChecked(true);
            menu.Items.Add(itemSelectAll);

            var itemDeselectAll = new DevExpress.Utils.Menu.DXMenuItem("Tüm Yetkileri Kaldır");
            itemDeselectAll.Click += (s, ev) => SetAllNodesChecked(false);
            menu.Items.Add(itemDeselectAll);

            var itemExpand = new DevExpress.Utils.Menu.DXMenuItem("Ağacı Genişlet");
            itemExpand.Click += (s, ev) => treeList1.ExpandAll();
            itemExpand.BeginGroup = true; // Araya çizgi (Separator) ekler
            menu.Items.Add(itemExpand);

            var itemCollapse = new DevExpress.Utils.Menu.DXMenuItem("Ağacı Daralt");
            itemCollapse.Click += (s, ev) => treeList1.CollapseAll();
            menu.Items.Add(itemCollapse);

            DevExpress.Utils.Menu.MenuManagerHelper.ShowMenu(menu, treeList1.LookAndFeel, treeList1.MenuManager, treeList1, e.Point);
        }

        private void SetAllNodesChecked(bool isChecked)
        {
            treeList1.BeginUpdate();
            try
            {
                // treeList1.Nodes contains root nodes
                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node in treeList1.GetNodeList())
                {
                    var pTypeObj = node.GetValue("PermissionType");
                    // Sadece Special olmayanlara dokun, çünkü Special node'un checkbox'ı yok
                    if (pTypeObj == null || (pTypeObj.ToString() != "Special" && pTypeObj.ToString() != "5"))
                    {
                        node.SetValue("IsChecked", isChecked);
                    }
                }
            }
            finally
            {
                treeList1.EndUpdate();
            }
            treeList1.Refresh();
        }

        private void TreeList1_ShowingEditor(object sender, CancelEventArgs e)
        {
            var node = treeList1.FocusedNode;
            if (node == null) return;

            var pTypeObj = node.GetValue("PermissionType");
            if (pTypeObj == null || (pTypeObj.ToString() != "Special" && pTypeObj.ToString() != "5"))
            {
                e.Cancel = true; // Sadece Special (Özel Yetkiler) node'unun editörünü açmaya izin ver.
            }
        }

        private void TreeList1_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            var pTypeObj = e.Node.GetValue("PermissionType");
            var modObj = e.Node.GetValue("ModuleId");
            if (pTypeObj != null && modObj != null)
            {
                var modType = (ModuleType)Convert.ToInt32(modObj);
                if (modType == ModuleType.EmailParameter || modType == ModuleType.SystemLicense || modType == ModuleType.KodLog || modType == ModuleType.TerminalYonetimi || modType == ModuleType.KurTanimlari)
                {
                    if (pTypeObj.ToString() == "Create" || pTypeObj.ToString() == "1" || 
                        pTypeObj.ToString() == "Delete" || pTypeObj.ToString() == "3")
                    {
                        e.CanCheck = false; // Prevent checking
                    }
                }
                else if (modType == ModuleType.UserInterfaceTemplate)
                {
                    if (pTypeObj.ToString() == "Create" || pTypeObj.ToString() == "1" || pTypeObj.ToString() == "2" ||
                        pTypeObj.ToString() == "Update" || pTypeObj.ToString() == "3")
                    {
                        e.CanCheck = false; // Prevent checking
                    }
                }
            }
        }

        private void TreeList1_CustomDrawNodeCheckBox(object sender, DevExpress.XtraTreeList.CustomDrawNodeCheckBoxEventArgs e)
        {
            var pTypeObj = e.Node.GetValue("PermissionType");
            var modObj = e.Node.GetValue("ModuleId");

            if (pTypeObj != null && (pTypeObj.ToString() == "Special" || pTypeObj.ToString() == "5"))
            {
                e.Handled = true; // Özel yetkiler satırında CheckBox çizme
            }
            else if (pTypeObj != null && modObj != null)
            {
                var modType = (ModuleType)Convert.ToInt32(modObj);
                if (modType == ModuleType.EmailParameter || modType == ModuleType.SystemLicense || modType == ModuleType.KodLog || modType == ModuleType.TerminalYonetimi || modType == ModuleType.KurTanimlari)
                {
                    if (pTypeObj.ToString() == "Create" || pTypeObj.ToString() == "1" || 
                        pTypeObj.ToString() == "Delete" || pTypeObj.ToString() == "3")
                    {
                        e.Handled = true; // Boş/Kare çizme (Checkbox gizlenir, anlamsız olur)
                    }
                }
                else if (modType == ModuleType.UserInterfaceTemplate)
                {
                    if (pTypeObj.ToString() == "Create" || pTypeObj.ToString() == "1" || pTypeObj.ToString() == "2" ||
                        pTypeObj.ToString() == "Update" || pTypeObj.ToString() == "3")
                    {
                        e.Handled = true; // Boş/Kare çizme (Checkbox gizlenir, anlamsız olur)
                    }
                }
            }
        }

        private void TreeList1_CustomNodeCellEdit(object sender, DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs e)
        {
            if (e.Column.FieldName == "Name")
            {
                var pTypeObj = e.Node.GetValue("PermissionType");
                if (pTypeObj != null && (pTypeObj.ToString() == "Special" || pTypeObj.ToString() == "5"))
                {
                    e.RepositoryItem = repositoryItemButtonEdit1;
                }
            }
        }

        private void RepositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var node = treeList1.FocusedNode;
            if (node == null) return;

            var pTypeObj = node.GetValue("PermissionType");
            if (pTypeObj == null || (pTypeObj.ToString() != "Special" && pTypeObj.ToString() != "5"))
            {
                return;
            }

            var moduleIdObj = node.GetValue("ModuleId");
            if (moduleIdObj == null) return;

            int moduleIdInt = Convert.ToInt32(moduleIdObj);
            ModuleType moduleType = (ModuleType)moduleIdInt;

            string currentJson = node.GetValue("SpecialPermissions")?.ToString() ?? string.Empty;

            using (var frm = new OzelYetkiEditForm(moduleType, currentJson))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    node.SetValue("SpecialPermissions", frm.SpecialPermissionsJson);
                    Control_EditValueChanged(this, EventArgs.Empty); // Özel yetki eklendiğinde butonu aktif et
                }
            }
        }

        private void TreeList1_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Node.Id == DevExpress.XtraTreeList.TreeList.AutoFilterNodeId) return;

            if (e.Column.FieldName == "Name")
            {
                if (e.Node.HasChildren)
                {
                    int checkedCount = 0;
                    int validChildrenCount = 0;
                    foreach (DevExpress.XtraTreeList.Nodes.TreeListNode child in e.Node.Nodes)
                    {
                        var pTypeObj = child.GetValue("PermissionType");
                        if (pTypeObj != null && (pTypeObj.ToString() == "Special" || pTypeObj.ToString() == "5")) continue;

                        validChildrenCount++;
                        if (child.Checked)
                        {
                            checkedCount++;
                        }
                    }

                    if (validChildrenCount > 0)
                    {
                        if (checkedCount == 0)
                        {
                            e.Appearance.BackColor = Color.FromArgb(255, 230, 230);
                            e.Appearance.ForeColor = Color.DarkRed;
                        }
                        else if (checkedCount == validChildrenCount)
                        {
                            e.Appearance.BackColor = Color.FromArgb(230, 255, 230);
                            e.Appearance.ForeColor = Color.DarkGreen;
                        }
                        else
                        {
                            e.Appearance.BackColor = Color.FromArgb(255, 250, 205); // LemonChiffon (Light Yellow)
                            e.Appearance.ForeColor = Color.DarkGoldenrod;
                        }
                    }
                }
                else
                {
                    var pTypeObj = e.Node.GetValue("PermissionType");
                    if (pTypeObj != null && (pTypeObj.ToString() == "Special" || pTypeObj.ToString() == "5")) return; // Özel yetkiler node'unu renklendirme

                    if (e.Node.Checked)
                    {
                        e.Appearance.BackColor = Color.FromArgb(230, 255, 230);
                        e.Appearance.ForeColor = Color.DarkGreen;
                    }
                    else
                    {
                        e.Appearance.BackColor = Color.FromArgb(255, 230, 230);
                        e.Appearance.ForeColor = Color.DarkRed;
                    }
                }
            }
        }

        private List<ThermaCore.Presentation.WinForms.Models.PermissionNodeDto> ConvertToPermissionNodes(List<RolePermissionDto> dtoList)
        {
            var nodes = new List<ThermaCore.Presentation.WinForms.Models.PermissionNodeDto>();

            foreach (var dto in dtoList)
            {
                int moduleNodeId = dto.ModuleId;
                
                // Klasörler için (Görebilir vb. yetkiler yok, sadece başlık)
                bool isFolder = dtoList.Any(x => x.ParentId == moduleNodeId);

                nodes.Add(new ThermaCore.Presentation.WinForms.Models.PermissionNodeDto
                {
                    Id = moduleNodeId,
                    ParentId = dto.ParentId,
                    ModuleId = dto.ModuleId,
                    Name = dto.ModuleName,
                    PermissionType = null,
                    IsChecked = isFolder ? false : (dto.CanRead && dto.CanCreate && dto.CanUpdate && dto.CanDelete)
                });

                if (!isFolder)
                {
                    nodes.Add(new ThermaCore.Presentation.WinForms.Models.PermissionNodeDto
                    {
                        Id = moduleNodeId * 10000 + 1,
                        ParentId = moduleNodeId,
                        ModuleId = dto.ModuleId,
                        Name = "Görebilir",
                        PermissionType = ThermaCore.Presentation.WinForms.Models.PermissionType.Read,
                        IsChecked = dto.CanRead
                    });

                    nodes.Add(new ThermaCore.Presentation.WinForms.Models.PermissionNodeDto
                    {
                        Id = moduleNodeId * 10000 + 2,
                        ParentId = moduleNodeId,
                        ModuleId = dto.ModuleId,
                        Name = "Ekleyebilir",
                        PermissionType = ThermaCore.Presentation.WinForms.Models.PermissionType.Create,
                        IsChecked = dto.CanCreate
                    });

                    nodes.Add(new ThermaCore.Presentation.WinForms.Models.PermissionNodeDto
                    {
                        Id = moduleNodeId * 10000 + 3,
                        ParentId = moduleNodeId,
                        ModuleId = dto.ModuleId,
                        Name = "Düzenleyebilir",
                        PermissionType = ThermaCore.Presentation.WinForms.Models.PermissionType.Update,
                        IsChecked = dto.CanUpdate
                    });

                    nodes.Add(new ThermaCore.Presentation.WinForms.Models.PermissionNodeDto
                    {
                        Id = moduleNodeId * 10000 + 4,
                        ParentId = moduleNodeId,
                        ModuleId = dto.ModuleId,
                        Name = "Silebilir",
                        PermissionType = ThermaCore.Presentation.WinForms.Models.PermissionType.Delete,
                        IsChecked = dto.CanDelete
                    });

                    nodes.Add(new ThermaCore.Presentation.WinForms.Models.PermissionNodeDto
                    {
                        Id = moduleNodeId * 10000 + 5,
                        ParentId = moduleNodeId,
                        ModuleId = dto.ModuleId,
                        Name = "Özel Yetkiler",
                        PermissionType = ThermaCore.Presentation.WinForms.Models.PermissionType.Special,
                        IsChecked = false,
                        SpecialPermissions = dto.SpecialPermissions
                    });
                }
            }

            return nodes;
        }

        private List<RolePermissionDto> ConvertToRolePermissions(List<ThermaCore.Presentation.WinForms.Models.PermissionNodeDto> nodes)
        {
            var dtos = new List<RolePermissionDto>();
            var moduleGroups = nodes.GroupBy(x => x.ModuleId);
            
            foreach (var group in moduleGroups)
            {
                var moduleNode = group.FirstOrDefault(x => x.PermissionType == null);
                if (moduleNode == null) continue;

                var readNode = group.FirstOrDefault(x => x.PermissionType == ThermaCore.Presentation.WinForms.Models.PermissionType.Read);
                var createNode = group.FirstOrDefault(x => x.PermissionType == ThermaCore.Presentation.WinForms.Models.PermissionType.Create);
                var updateNode = group.FirstOrDefault(x => x.PermissionType == ThermaCore.Presentation.WinForms.Models.PermissionType.Update);
                var deleteNode = group.FirstOrDefault(x => x.PermissionType == ThermaCore.Presentation.WinForms.Models.PermissionType.Delete);
                var specialNode = group.FirstOrDefault(x => x.PermissionType == ThermaCore.Presentation.WinForms.Models.PermissionType.Special);

                dtos.Add(new RolePermissionDto
                {
                    ModuleId = moduleNode.ModuleId,
                    ParentId = moduleNode.ParentId,
                    ModuleName = moduleNode.Name,
                    CanRead = readNode?.IsChecked ?? false,
                    CanCreate = createNode?.IsChecked ?? false,
                    CanUpdate = updateNode?.IsChecked ?? false,
                    CanDelete = deleteNode?.IsChecked ?? false,
                    IsActive = true,
                    SpecialPermissions = specialNode?.SpecialPermissions
                });
            }

            return dtos;
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (RoleDto)OldEntity;
            
            txtRolKodu.Text = entity.Code;
            txtRolAdi.Text = entity.RoleName;
            txtAciklama.Text = entity.Description;
            tglDurum.IsOn = entity.IsActive;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new RoleDto
            {
                Id = Id,
                Code = txtRolKodu.Text,
                RoleName = txtRolAdi.Text,
                Description = txtAciklama.Text,
                IsActive = tglDurum.IsOn
            };
            
            ButonEnabledDurumu();
        }

        protected internal override void ButonEnabledDurumu()
        {
            if (!IsLoaded) return;

            if (txtRolKodu.Text == "ADMIN_ROLE" && BaseIslemTuru == ActionType.EntityUpdate)
            {
                if (btnKaydet != null) btnKaydet.Enabled = false;
                if (btnGerial != null) btnGerial.Enabled = false;
                if (btnSil != null) btnSil.Enabled = false;
                return;
            }

            bool isChanged = false;

            if (CurrentEntity != null && OldEntity != null)
            {
                isChanged = CurrentEntity.Code != OldEntity.Code ||
                            ((RoleDto)CurrentEntity).RoleName != ((RoleDto)OldEntity).RoleName ||
                            ((RoleDto)CurrentEntity).Description != ((RoleDto)OldEntity).Description ||
                            CurrentEntity.IsActive != OldEntity.IsActive;
            }

            if (treeList1.DataSource != null)
            {
                treeList1.PostEditor();
                var currentNodes = (List<ThermaCore.Presentation.WinForms.Models.PermissionNodeDto>)treeList1.DataSource;
                var currentJson = System.Text.Json.JsonSerializer.Serialize(currentNodes);
                
                if (currentJson != _originalPermissionsJson)
                {
                    isChanged = true;
                }
            }

            if (btnKaydet != null) btnKaydet.Enabled = isChanged;
            if (btnGerial != null) btnGerial.Enabled = isChanged;
            if (btnYeni != null) btnYeni.Enabled = !isChanged;
            if (btnSil != null) btnSil.Enabled = !isChanged && BaseIslemTuru == ActionType.EntityUpdate;
        }

        protected override bool EntityInsert()
        {
            var dto = (RoleDto)CurrentEntity;
            dto.Id = BaseIslemTuru.IdOlustur(dto);
            this.Id = dto.Id;
            return SaveRole();
        }

        protected override bool EntityUpdate()
        {
            if (txtRolKodu.Text == "ADMIN_ROLE")
            {
                Messages.UyariMesaji("Sistem Yöneticisi (ADMIN_ROLE) üzerinde değişiklik yapılamaz!");
                return false;
            }
            return SaveRole();
        }

        protected override void EntityDelete()
        {
            if (txtRolKodu.Text == "ADMIN_ROLE")
            {
                Messages.UyariMesaji("Sistem Yöneticisi (ADMIN_ROLE) silinemez!");
                return;
            }
            
            if (Id <= 0) return;
            if (Messages.SilMesaj("Rol") == DialogResult.Yes)
            {
                try
                {
                    _roleService.Delete(Id);
                    RefreshYapilacak = true;
                    Close();
                }
                catch (Exception ex)
                {
                    Messages.HataMesaji(ex.Message);
                }
            }
        }

        private bool SaveRole()
        {
            GuncelNesneOlustur();
            
            treeList1.CloseEditor();
            var roleDto = (RoleDto)CurrentEntity;
            var nodes = (List<ThermaCore.Presentation.WinForms.Models.PermissionNodeDto>)treeList1.DataSource;
            var permissions = ConvertToRolePermissions(nodes);
            
            try
            {
                Id = _roleService.SaveRoleWithPermissions(roleDto, permissions);
                
                // Başarılı kayıttan sonra mevcut durumu "orijinal" olarak güncelle,
                // böylece ButonEnabledDurumu formun kapanışı sırasında tekrar Kaydet sormaz.
                _originalPermissionsJson = System.Text.Json.JsonSerializer.Serialize(nodes);
                
                return true;
            }
            catch (FluentValidation.ValidationException ex)
            {
                Messages.UyariMesaji(string.Join("\n", System.Linq.Enumerable.Select(ex.Errors, e => e.ErrorMessage)));
                return false;
            }
            catch (Exception ex)
            {
                Messages.HataMesaji(ex.Message);
                return false;
            }
        }
    }
}