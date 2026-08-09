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
using WinBeyazEsya.Application.DTOs.Security;
using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Application.Interfaces.Security;
using WinBeyazEsya.Application.Interfaces.Management;
using WinBeyazEsya.Presentation.WinForms.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;
using WinBeyazEsya.Domain.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.YetkilendirmeForms
{
    public partial class KullaniciYetkiEditForm : BaseEditForm
    {
        private readonly IUserPermissionService _userPermissionService;
        private readonly IUserService _userService;
        private string _originalPermissionsJson = string.Empty;

        protected override string CodeControlName => "txtKod";

        public KullaniciYetkiEditForm()
        {
            InitializeComponent();
            _userPermissionService = Program.ServiceProvider.GetService<IUserPermissionService>()!;
            _userService = Program.ServiceProvider.GetService<IUserService>()!;

            DataLayoutControl = myDataLayoutControl1;
            Bll = _userService; // Form can use user service as base BLL if needed for Kaydet
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.User;
        }

        public override void Yukle()
        {
            treeList1.KeyFieldName = "Id";
            treeList1.ParentFieldName = "ParentId";

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                Messages.UyariMesaji("Kullanıcı Yetki formu sadece mevcut kullanıcılar için açılabilir.");
                Close();
                return;
            }
            
            OldEntity = _userService.GetById(Id);
            
            // Sadece veritabanında olan istisnai yetkileri yükle (yoksa boş gelir)
            var permissionDtos = _userPermissionService.GetUserPermissions(Id).ToList();
            
            var permissionNodes = ConvertToPermissionNodes(permissionDtos);
            _originalPermissionsJson = System.Text.Json.JsonSerializer.Serialize(permissionNodes);
            treeList1.DataSource = permissionNodes;

            treeList1.OptionsView.ShowCheckBoxes = true;
            treeList1.CheckBoxFieldName = "IsChecked";
            treeList1.OptionsBehavior.AllowRecursiveNodeChecking = false; 
            treeList1.OptionsView.ShowAutoFilterRow = true;
            treeList1.NodeCellStyle += TreeList1_NodeCellStyle;
            treeList1.CustomNodeCellEdit += TreeList1_CustomNodeCellEdit;
            treeList1.CustomDrawNodeCheckBox += TreeList1_CustomDrawNodeCheckBox;
            treeList1.BeforeCheckNode += TreeList1_BeforeCheckNode;
            treeList1.ShowingEditor += TreeList1_ShowingEditor;
            repositoryItemButtonEdit1.ButtonClick += RepositoryItemButtonEdit1_ButtonClick;
            repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            treeList1.PopupMenuShowing += TreeList1_PopupMenuShowing;

            treeList1.PopulateColumns();
            foreach (DevExpress.XtraTreeList.Columns.TreeListColumn col in treeList1.Columns)
            {
                if (col.FieldName == "Name")
                {
                    col.Caption = "Yetki / Modül Adı";
                    col.Visible = true;
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

            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode node in treeList1.GetNodeList())
            {
                if (!node.HasChildren)
                {
                    UpdateParentChecked(node);
                }
            }

            if (treeList1.DataSource != null)
            {
                var currentNodes = (List<WinBeyazEsya.Presentation.WinForms.Models.PermissionNodeDto>)treeList1.DataSource;
                _originalPermissionsJson = System.Text.Json.JsonSerializer.Serialize(currentNodes);
            }

            txtKod.EditValueChanged += Control_EditValueChanged;
            txtAdSoyad.EditValueChanged += Control_EditValueChanged;
            tglDurum.EditValueChanged += Control_EditValueChanged;
            
            treeList1.CellValueChanged += (s, e) => {
                GuncelNesneOlustur();
                ButonEnabledDurumu();
            };
            treeList1.AfterCheckNode += TreeList1_AfterCheckNode;
            
            // Buton Eventleri
            btnModulEkle.Click += BtnModulEkle_Click;
            btnTumModulleriEkle.Click += BtnTumModulleriEkle_Click;
            btnSeciliModuluCikar.Click += BtnSeciliModuluCikar_Click;
            btnTumunuTemizle.Click += BtnTumunuTemizle_Click;
        }

        private void BtnModulEkle_Click(object sender, EventArgs e)
        {
            var currentNodes = (List<WinBeyazEsya.Presentation.WinForms.Models.PermissionNodeDto>)treeList1.DataSource;
            var existingModuleIds = currentNodes.Select(x => x.ModuleId).Distinct().ToList();
            var allModules = Enum.GetValues(typeof(ModuleType)).Cast<ModuleType>().ToList();
            
            var availableModules = allModules.Where(m => (int)m != 0 && !existingModuleIds.Contains((int)m)).ToList();
            
            if (!availableModules.Any())
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Eklenebilecek yeni bir modül bulunmamaktadır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var args = new DevExpress.XtraEditors.XtraInputBoxArgs();
            args.Caption = "Modül Ekle";
            args.Prompt = "İstisna eklenecek modülü seçiniz:";
            args.DefaultButtonIndex = 0;
            
            var editor = new DevExpress.XtraEditors.ImageComboBoxEdit();
            foreach(var mod in availableModules)
            {
                editor.Properties.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(mod.GetDescription(), mod, -1));
            }
            args.Editor = editor;

            var result = DevExpress.XtraEditors.XtraInputBox.Show(args);
            if (result != null)
            {
                var selectedMod = (ModuleType)result;
                AddModuleToTree(selectedMod);
            }
        }

        private void BtnTumModulleriEkle_Click(object sender, EventArgs e)
        {
            if (DevExpress.XtraEditors.XtraMessageBox.Show("Sistemdeki tüm modüller istisna olarak eklenecek. Emin misiniz?", "Tüm Modülleri Ekle", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var currentNodes = (List<WinBeyazEsya.Presentation.WinForms.Models.PermissionNodeDto>)treeList1.DataSource;
                var existingModuleIds = currentNodes.Select(x => x.ModuleId).Distinct().ToList();
                var allModules = Enum.GetValues(typeof(ModuleType)).Cast<ModuleType>().ToList();
                
                foreach (var mod in allModules)
                {
                    if ((int)mod != 0 && !existingModuleIds.Contains((int)mod))
                    {
                        AddModuleToTree(mod);
                    }
                }
            }
        }

        private void BtnSeciliModuluCikar_Click(object sender, EventArgs e)
        {
            var focusedNode = treeList1.FocusedNode;
            if (focusedNode != null)
            {
                var moduleIdObj = focusedNode.GetValue("ModuleId");
                if (moduleIdObj != null)
                {
                    int modId = Convert.ToInt32(moduleIdObj);
                    RemoveModuleFromTree(modId);
                }
            }
        }

        private void BtnTumunuTemizle_Click(object sender, EventArgs e)
        {
            if (DevExpress.XtraEditors.XtraMessageBox.Show("Tüm istisna modülleri temizlenecek. Emin misiniz?", "Tümünü Temizle", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var currentNodes = (List<WinBeyazEsya.Presentation.WinForms.Models.PermissionNodeDto>)treeList1.DataSource;
                currentNodes.Clear();
                treeList1.RefreshDataSource();
                Control_EditValueChanged(this, EventArgs.Empty);
            }
        }
        
        private bool IsModuleFolder(ModuleType mod)
        {
            var allModules = Enum.GetValues(typeof(ModuleType)).Cast<ModuleType>().ToList();
            return allModules.Any(x => x.GetParentModule() == mod);
        }

        private void AddModuleToTree(ModuleType mod)
        {
            var currentNodes = (List<WinBeyazEsya.Presentation.WinForms.Models.PermissionNodeDto>)treeList1.DataSource;
            int moduleId = (int)mod;
            
            if (currentNodes.Any(x => x.ModuleId == moduleId)) return;

            var parent = mod.GetParentModule();
            if (parent != null && (int)parent.Value != 0)
            {
                if (!currentNodes.Any(x => x.ModuleId == (int)parent.Value))
                {
                    AddModuleToTree(parent.Value);
                }
            }

            bool isFolder = IsModuleFolder(mod);

            
            // Eğer eklenecek modül özel kısıtlamalara sahipse parent/child ilişkilerini ona göre kurmalıyız.
            // RolEditForm'daki standart yapıyı ekleyelim
            currentNodes.Add(new WinBeyazEsya.Presentation.WinForms.Models.PermissionNodeDto
            {
                Id = moduleId,
                ParentId = mod.GetParentModule() != null ? (int)mod.GetParentModule()! : 0, 
                ModuleId = moduleId,
                Name = mod.GetDescription(), 
                PermissionType = null,
                IsChecked = false
            });
            
            if (!isFolder)
            {
                currentNodes.Add(new WinBeyazEsya.Presentation.WinForms.Models.PermissionNodeDto { Id = moduleId * 10000 + 1, ParentId = moduleId, ModuleId = moduleId, Name = "Görebilir", PermissionType = WinBeyazEsya.Presentation.WinForms.Models.PermissionType.Read, IsChecked = false });
                currentNodes.Add(new WinBeyazEsya.Presentation.WinForms.Models.PermissionNodeDto { Id = moduleId * 10000 + 2, ParentId = moduleId, ModuleId = moduleId, Name = "Ekleyebilir", PermissionType = WinBeyazEsya.Presentation.WinForms.Models.PermissionType.Create, IsChecked = false });
                currentNodes.Add(new WinBeyazEsya.Presentation.WinForms.Models.PermissionNodeDto { Id = moduleId * 10000 + 3, ParentId = moduleId, ModuleId = moduleId, Name = "Düzenleyebilir", PermissionType = WinBeyazEsya.Presentation.WinForms.Models.PermissionType.Update, IsChecked = false });
                currentNodes.Add(new WinBeyazEsya.Presentation.WinForms.Models.PermissionNodeDto { Id = moduleId * 10000 + 4, ParentId = moduleId, ModuleId = moduleId, Name = "Silebilir", PermissionType = WinBeyazEsya.Presentation.WinForms.Models.PermissionType.Delete, IsChecked = false });
                currentNodes.Add(new WinBeyazEsya.Presentation.WinForms.Models.PermissionNodeDto { Id = moduleId * 10000 + 5, ParentId = moduleId, ModuleId = moduleId, Name = "Özel Yetkiler", PermissionType = WinBeyazEsya.Presentation.WinForms.Models.PermissionType.Special, IsChecked = false });
            }

            treeList1.RefreshDataSource();
            treeList1.ExpandAll();
            Control_EditValueChanged(this, EventArgs.Empty);
        }

        private void RemoveModuleFromTree(int moduleId)
        {
            var currentNodes = (List<WinBeyazEsya.Presentation.WinForms.Models.PermissionNodeDto>)treeList1.DataSource;
            currentNodes.RemoveAll(x => x.ModuleId == moduleId);
            treeList1.RefreshDataSource();
            Control_EditValueChanged(this, EventArgs.Empty);
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
                    if (modType == ModuleType.EmailParameter || modType == ModuleType.KodLog || modType == ModuleType.TerminalYonetimi || modType == ModuleType.GenelParametreler)
                    {
                        if (pTypeObj.ToString() == "Create" || pTypeObj.ToString() == "1" || 
                            pTypeObj.ToString() == "Delete" || pTypeObj.ToString() == "3")
                        {
                            continue;
                        }
                    }
                    else if (modType == ModuleType.SystemLicense)
                    {
                        if (pTypeObj.ToString() == "Create" || pTypeObj.ToString() == "1" || 
                            pTypeObj.ToString() == "Update" || pTypeObj.ToString() == "2" ||
                            pTypeObj.ToString() == "Delete" || pTypeObj.ToString() == "3")
                        {
                            continue;
                        }
                    }
                    else if (modType == ModuleType.UserInterfaceTemplate)
                    {
                        if (pTypeObj.ToString() == "Create" || pTypeObj.ToString() == "1" || pTypeObj.ToString() == "2" ||
                            pTypeObj.ToString() == "Update" || pTypeObj.ToString() == "3")
                        {
                            continue;
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
                        if (modType == ModuleType.EmailParameter || modType == ModuleType.KodLog || modType == ModuleType.TerminalYonetimi || modType == ModuleType.GenelParametreler)
                        {
                            if (pTypeObj.ToString() == "Create" || pTypeObj.ToString() == "1" || 
                                pTypeObj.ToString() == "Delete" || pTypeObj.ToString() == "3")
                            {
                                continue;
                            }
                        }
                        else if (modType == ModuleType.SystemLicense)
                        {
                            if (pTypeObj.ToString() == "Create" || pTypeObj.ToString() == "1" || 
                                pTypeObj.ToString() == "Update" || pTypeObj.ToString() == "2" ||
                                pTypeObj.ToString() == "Delete" || pTypeObj.ToString() == "3")
                            {
                                continue;
                            }
                        }
                        else if (modType == ModuleType.UserInterfaceTemplate)
                        {
                            if (pTypeObj.ToString() == "Create" || pTypeObj.ToString() == "1" || pTypeObj.ToString() == "2" ||
                                pTypeObj.ToString() == "Update" || pTypeObj.ToString() == "3")
                            {
                                continue;
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
            e.Allow = false;

            var menu = new DevExpress.Utils.Menu.DXPopupMenu();

            var itemRemove = new DevExpress.Utils.Menu.DXMenuItem("Seçili Modülü Çıkar");
            itemRemove.Click += BtnSeciliModuluCikar_Click;
            menu.Items.Add(itemRemove);

            var itemExpand = new DevExpress.Utils.Menu.DXMenuItem("Ağacı Genişlet");
            itemExpand.Click += (s, ev) => treeList1.ExpandAll();
            itemExpand.BeginGroup = true;
            menu.Items.Add(itemExpand);

            var itemCollapse = new DevExpress.Utils.Menu.DXMenuItem("Ağacı Daralt");
            itemCollapse.Click += (s, ev) => treeList1.CollapseAll();
            menu.Items.Add(itemCollapse);

            DevExpress.Utils.Menu.MenuManagerHelper.ShowMenu(menu, treeList1.LookAndFeel, treeList1.MenuManager, treeList1, e.Point);
        }

        private void TreeList1_ShowingEditor(object sender, CancelEventArgs e)
        {
            var node = treeList1.FocusedNode;
            if (node == null) return;

            var pTypeObj = node.GetValue("PermissionType");
            if (pTypeObj == null || (pTypeObj.ToString() != "Special" && pTypeObj.ToString() != "5"))
            {
                e.Cancel = true;
            }
        }

        private void TreeList1_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            var pTypeObj = e.Node.GetValue("PermissionType");
            var modObj = e.Node.GetValue("ModuleId");
            if (pTypeObj != null && modObj != null)
            {
                var modType = (ModuleType)Convert.ToInt32(modObj);
                if (modType == ModuleType.EmailParameter || modType == ModuleType.KodLog || modType == ModuleType.TerminalYonetimi || modType == ModuleType.KurTanimlari || modType == ModuleType.GenelParametreler)
                {
                    if (pTypeObj.ToString() == "Create" || pTypeObj.ToString() == "1" || 
                        pTypeObj.ToString() == "Delete" || pTypeObj.ToString() == "3")
                    {
                        e.CanCheck = false;
                    }
                }
                else if (modType == ModuleType.SystemLicense)
                {
                    if (pTypeObj.ToString() == "Create" || pTypeObj.ToString() == "1" || 
                        pTypeObj.ToString() == "Update" || pTypeObj.ToString() == "2" ||
                        pTypeObj.ToString() == "Delete" || pTypeObj.ToString() == "3")
                    {
                        e.CanCheck = false;
                    }
                }
                else if (modType == ModuleType.UserInterfaceTemplate)
                {
                    if (pTypeObj.ToString() == "Create" || pTypeObj.ToString() == "1" || pTypeObj.ToString() == "2" ||
                        pTypeObj.ToString() == "Update" || pTypeObj.ToString() == "3")
                    {
                        e.CanCheck = false;
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
                e.Handled = true;
            }
            else if (pTypeObj != null && modObj != null)
            {
                var modType = (ModuleType)Convert.ToInt32(modObj);
                if (modType == ModuleType.EmailParameter || modType == ModuleType.KodLog || modType == ModuleType.TerminalYonetimi || modType == ModuleType.KurTanimlari || modType == ModuleType.GenelParametreler)
                {
                    if (pTypeObj.ToString() == "Create" || pTypeObj.ToString() == "1" || 
                        pTypeObj.ToString() == "Delete" || pTypeObj.ToString() == "3")
                    {
                        e.Handled = true;
                    }
                }
                else if (modType == ModuleType.SystemLicense)
                {
                    if (pTypeObj.ToString() == "Create" || pTypeObj.ToString() == "1" || 
                        pTypeObj.ToString() == "Update" || pTypeObj.ToString() == "2" ||
                        pTypeObj.ToString() == "Delete" || pTypeObj.ToString() == "3")
                    {
                        e.Handled = true;
                    }
                }
                else if (modType == ModuleType.UserInterfaceTemplate)
                {
                    if (pTypeObj.ToString() == "Create" || pTypeObj.ToString() == "1" || pTypeObj.ToString() == "2" ||
                        pTypeObj.ToString() == "Update" || pTypeObj.ToString() == "3")
                    {
                        e.Handled = true;
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
                    Control_EditValueChanged(this, EventArgs.Empty);
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
                        var modObj = child.GetValue("ModuleId");

                        if (pTypeObj != null && (pTypeObj.ToString() == "Special" || pTypeObj.ToString() == "5")) continue;

                        if (pTypeObj != null && modObj != null)
                        {
                            var modType = (ModuleType)Convert.ToInt32(modObj);
                            if (modType == ModuleType.EmailParameter || modType == ModuleType.KodLog || modType == ModuleType.TerminalYonetimi || modType == ModuleType.GenelParametreler || modType == ModuleType.KurTanimlari)
                            {
                                if (pTypeObj.ToString() == "Create" || pTypeObj.ToString() == "1" || 
                                    pTypeObj.ToString() == "Delete" || pTypeObj.ToString() == "3")
                                {
                                    continue; // Sayıma katma
                                }
                            }
                            else if (modType == ModuleType.SystemLicense)
                            {
                                if (pTypeObj.ToString() == "Create" || pTypeObj.ToString() == "1" || 
                                    pTypeObj.ToString() == "Update" || pTypeObj.ToString() == "2" ||
                                    pTypeObj.ToString() == "Delete" || pTypeObj.ToString() == "3")
                                {
                                    continue; // Sayıma katma
                                }
                            }
                            else if (modType == ModuleType.UserInterfaceTemplate)
                            {
                                if (pTypeObj.ToString() == "Create" || pTypeObj.ToString() == "1" || pTypeObj.ToString() == "2" ||
                                    pTypeObj.ToString() == "Update" || pTypeObj.ToString() == "3")
                                {
                                    continue; // Sayıma katma
                                }
                            }
                        }

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
                            e.Appearance.BackColor = Color.FromArgb(255, 250, 205);
                            e.Appearance.ForeColor = Color.DarkGoldenrod;
                        }
                    }
                }
                else
                {
                    var pTypeObj = e.Node.GetValue("PermissionType");
                    if (pTypeObj != null && (pTypeObj.ToString() == "Special" || pTypeObj.ToString() == "5")) return;

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

        private List<WinBeyazEsya.Presentation.WinForms.Models.PermissionNodeDto> ConvertToPermissionNodes(List<UserPermissionDto> dtoList)
        {
            var nodes = new List<WinBeyazEsya.Presentation.WinForms.Models.PermissionNodeDto>();

            foreach (var dto in dtoList)
            {
                int moduleNodeId = dto.ModuleId;
                
                bool isFolder = IsModuleFolder((ModuleType)moduleNodeId);

                nodes.Add(new WinBeyazEsya.Presentation.WinForms.Models.PermissionNodeDto
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
                    nodes.Add(new WinBeyazEsya.Presentation.WinForms.Models.PermissionNodeDto
                    {
                        Id = moduleNodeId * 10000 + 1,
                        ParentId = moduleNodeId,
                        ModuleId = dto.ModuleId,
                        Name = "Görebilir",
                        PermissionType = WinBeyazEsya.Presentation.WinForms.Models.PermissionType.Read,
                        IsChecked = dto.CanRead
                    });

                    nodes.Add(new WinBeyazEsya.Presentation.WinForms.Models.PermissionNodeDto
                    {
                        Id = moduleNodeId * 10000 + 2,
                        ParentId = moduleNodeId,
                        ModuleId = dto.ModuleId,
                        Name = "Ekleyebilir",
                        PermissionType = WinBeyazEsya.Presentation.WinForms.Models.PermissionType.Create,
                        IsChecked = dto.CanCreate
                    });

                    nodes.Add(new WinBeyazEsya.Presentation.WinForms.Models.PermissionNodeDto
                    {
                        Id = moduleNodeId * 10000 + 3,
                        ParentId = moduleNodeId,
                        ModuleId = dto.ModuleId,
                        Name = "Düzenleyebilir",
                        PermissionType = WinBeyazEsya.Presentation.WinForms.Models.PermissionType.Update,
                        IsChecked = dto.CanUpdate
                    });

                    nodes.Add(new WinBeyazEsya.Presentation.WinForms.Models.PermissionNodeDto
                    {
                        Id = moduleNodeId * 10000 + 4,
                        ParentId = moduleNodeId,
                        ModuleId = dto.ModuleId,
                        Name = "Silebilir",
                        PermissionType = WinBeyazEsya.Presentation.WinForms.Models.PermissionType.Delete,
                        IsChecked = dto.CanDelete
                    });

                    nodes.Add(new WinBeyazEsya.Presentation.WinForms.Models.PermissionNodeDto
                    {
                        Id = moduleNodeId * 10000 + 5,
                        ParentId = moduleNodeId,
                        ModuleId = dto.ModuleId,
                        Name = "Özel Yetkiler",
                        PermissionType = WinBeyazEsya.Presentation.WinForms.Models.PermissionType.Special,
                        IsChecked = false,
                        SpecialPermissions = dto.SpecialPermissions
                    });
                }
            }

            return nodes;
        }

        private List<UserPermissionDto> ConvertToUserPermissions(List<WinBeyazEsya.Presentation.WinForms.Models.PermissionNodeDto> nodes)
        {
            var dtos = new List<UserPermissionDto>();
            var moduleGroups = nodes.GroupBy(x => x.ModuleId);
            
            foreach (var group in moduleGroups)
            {
                var moduleNode = group.FirstOrDefault(x => x.PermissionType == null);
                if (moduleNode == null) continue;

                var readNode = group.FirstOrDefault(x => x.PermissionType == WinBeyazEsya.Presentation.WinForms.Models.PermissionType.Read);
                var createNode = group.FirstOrDefault(x => x.PermissionType == WinBeyazEsya.Presentation.WinForms.Models.PermissionType.Create);
                var updateNode = group.FirstOrDefault(x => x.PermissionType == WinBeyazEsya.Presentation.WinForms.Models.PermissionType.Update);
                var deleteNode = group.FirstOrDefault(x => x.PermissionType == WinBeyazEsya.Presentation.WinForms.Models.PermissionType.Delete);
                var specialNode = group.FirstOrDefault(x => x.PermissionType == WinBeyazEsya.Presentation.WinForms.Models.PermissionType.Special);

                dtos.Add(new UserPermissionDto
                {
                    UserId = this.Id, // Set the current User ID
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
            if (OldEntity is UserDto entity)
            {
                txtKod.Text = entity.Code;
                txtAdSoyad.Text = $"{entity.FirstName} {entity.LastName}".Trim();
                tglDurum.IsOn = entity.IsActive;
            }
        }

        protected override void GuncelNesneOlustur()
        {
            if (OldEntity is UserDto entity)
            {
                CurrentEntity = new UserDto
                {
                    Id = Id,
                    Code = txtKod.Text,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Email = entity.Email,
                    Password = entity.Password,
                    UserRoleId = entity.UserRoleId,
                    RoleName = entity.RoleName,
                    IsActive = tglDurum.IsOn
                };
            }
            
            ButonEnabledDurumu();
        }

        protected internal override void ButonEnabledDurumu()
        {
            if (!IsLoaded) return;

            bool isChanged = false;

            if (CurrentEntity != null && OldEntity != null)
            {
                isChanged = CurrentEntity.Code != OldEntity.Code ||
                            CurrentEntity.IsActive != OldEntity.IsActive;
            }

            if (treeList1.DataSource != null)
            {
                treeList1.PostEditor();
                var currentNodes = (List<WinBeyazEsya.Presentation.WinForms.Models.PermissionNodeDto>)treeList1.DataSource;
                var currentJson = System.Text.Json.JsonSerializer.Serialize(currentNodes);
                
                if (currentJson != _originalPermissionsJson)
                {
                    isChanged = true;
                }
            }

            if (btnKaydet != null) btnKaydet.Enabled = isChanged;
            if (btnGerial != null) btnGerial.Enabled = isChanged;
            if (btnYeni != null) btnYeni.Enabled = false; // Yeni ekleme bu formdan yapılmaz
            if (btnSil != null) btnSil.Enabled = false; // Silme bu formdan yapılmaz
        }

        protected override bool EntityUpdate()
        {
            if (txtKod.Text.ToLower() == "winbeyazesya")
            {
                Messages.UyariMesaji("Sistem Yöneticisi (winbeyazesya) kullanıcıları üzerinde yetki kısıtlaması/istisnası yapılamaz!");
                return false;
            }
            
            return SaveUserPermissions();
        }
        
        protected override bool EntityInsert()
        {
            return false; // Not allowed
        }
        
        protected override void EntityDelete()
        {
            // Not allowed
        }

        private bool SaveUserPermissions()
        {
            GuncelNesneOlustur();
            
            treeList1.CloseEditor();
            var nodes = (List<WinBeyazEsya.Presentation.WinForms.Models.PermissionNodeDto>)treeList1.DataSource;
            var permissions = ConvertToUserPermissions(nodes);
            
            try
            {
                // Sadece yetkileri kaydet, kullanıcı kartını güncellemeye gerek yoksa (örneğin sadece yetkiler değiştiyse)
                // Eğer IsActive gibi alanlar da değiştiyse Update de çağrılabilir
                if (CurrentEntity.Code != OldEntity.Code || CurrentEntity.IsActive != OldEntity.IsActive)
                {
                    _userService.Update((UserDto)CurrentEntity);
                }

                _userPermissionService.SaveUserPermissions(this.Id, permissions);
                
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



