using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;

using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;
using DevExpress.XtraGrid.Menu;
using DevExpress.Utils.Menu;

namespace WinBeyazEsya.Presentation.WinForms.Forms.UretimForms
{
    public partial class UrunReceteEditForm : BaseEditForm
    {
        private readonly IProductRecipeService? _productRecipeService;
        private readonly IServiceProvider? _serviceProvider;
        private ProductRecipeDto _currentDto = new ProductRecipeDto();
        private BindingList<ProductRecipeLineDto> _lines = new BindingList<ProductRecipeLineDto>();

        public UrunReceteEditForm(IProductRecipeService? productRecipeService = null, IServiceProvider? serviceProvider = null)
        {
            InitializeComponent();
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.ProductRecipe;
            _productRecipeService = productRecipeService;
            _serviceProvider = serviceProvider;

            DataLayoutControl = myDataLayoutControl1;
            DataLayoutControls = new object[] { myDataLayoutControl2 };
            Bll = _productRecipeService;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            if (!DesignMode)
            {
                txtRevizyonNo.Properties.ReadOnly = true;

                if (_serviceProvider != null)
                {
                    var finishedGoodService = _serviceProvider.GetService<IFinishedGoodService>();
                    if (finishedGoodService != null)
                    {
                        glufMamul.Properties.DataSource = finishedGoodService.GetAll().Where(x => x.IsActive).ToList();
                    }
                }

                TreeListDoldur();

                tglDurum.IsOn = true;
                
                myGridControl1.DataSource = _lines;
                
                // Allow drag-drop setup
                treeList1.OptionsBehavior.DragNodes = true;
                myGridControl1.AllowDrop = true;
            }
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();
            
            if (glufMamul != null) glufMamul.SearchButtonClicked += glufMamul_SearchButtonClicked;

            if (!DesignMode)
            {
                treeList1.MouseDown -= TreeList1_MouseDown;
                treeList1.MouseMove -= TreeList1_MouseMove;
                myGridControl1.DragOver -= MyGridControl1_DragOver;
                myGridControl1.DragDrop -= MyGridControl1_DragDrop;
                treeList1.NodeCellStyle -= TreeList1_NodeCellStyle;
                treeList1.PopupMenuShowing -= TreeList1_PopupMenuShowing;
                myGridView1.PopupMenuShowing -= MyGridView1_PopupMenuShowing;

                treeList1.MouseDown += TreeList1_MouseDown;
                treeList1.MouseMove += TreeList1_MouseMove;
                myGridControl1.DragOver += MyGridControl1_DragOver;
                myGridControl1.DragDrop += MyGridControl1_DragDrop;
                treeList1.NodeCellStyle += TreeList1_NodeCellStyle;
                treeList1.PopupMenuShowing += TreeList1_PopupMenuShowing;
                myGridView1.PopupMenuShowing += MyGridView1_PopupMenuShowing;
            }
        }

        private string GetEnumDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field == null) return value.ToString();
            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }

        private class MaterialDragDropBox
        {
            public long MaterialId { get; set; }
            public string MaterialCode { get; set; }
            public string MaterialName { get; set; }
            public long UnitId { get; set; }
            public string UnitName { get; set; }
            public MaterialType MaterialType { get; set; }
        }

        private void TreeListDoldur()
        {
            treeList1.ClearNodes();
            treeList1.Columns.Clear();
            var col = treeList1.Columns.Add();
            col.Caption = "Hammadde Grupları";
            col.VisibleIndex = 0;
            col.OptionsColumn.AllowEdit = false;

            if (_serviceProvider == null) return;

            var metalService = _serviceProvider.GetService<IMetalSheetGroupService>();
            if (metalService != null)
            {
                var parent = treeList1.AppendNode(new object[] { GetEnumDescription(MaterialType.MetalAndSheet) }, null);
                parent.Tag = MaterialType.MetalAndSheet;
                foreach(var item in metalService.GetAll().Where(x => x.IsActive))
                {
                    var child = treeList1.AppendNode(new object[] { item.Name }, parent);
                    child.Tag = new MaterialDragDropBox { MaterialId = item.Id, MaterialCode = item.Code, MaterialName = item.Name, UnitId = item.BaseUnitId, UnitName = item.BaseUnitName, MaterialType = MaterialType.MetalAndSheet };
                }
            }

            var elecService = _serviceProvider.GetService<IElectricalElectronicGroupService>();
            if (elecService != null)
            {
                var parent = treeList1.AppendNode(new object[] { GetEnumDescription(MaterialType.ElectricalElectronic) }, null);
                parent.Tag = MaterialType.ElectricalElectronic;
                foreach(var item in elecService.GetAll().Where(x => x.IsActive))
                {
                    var child = treeList1.AppendNode(new object[] { item.Name }, parent);
                    child.Tag = new MaterialDragDropBox { MaterialId = item.Id, MaterialCode = item.Code, MaterialName = item.Name, UnitId = item.BaseUnitId, UnitName = item.BaseUnitName, MaterialType = MaterialType.ElectricalElectronic };
                }
            }
            
            var gasService = _serviceProvider.GetService<IGasAndIgnitionGroupService>();
            if (gasService != null)
            {
                var parent = treeList1.AppendNode(new object[] { GetEnumDescription(MaterialType.GasAndIgnition) }, null);
                parent.Tag = MaterialType.GasAndIgnition;
                foreach(var item in gasService.GetAll().Where(x => x.IsActive))
                {
                    var child = treeList1.AppendNode(new object[] { item.Name }, parent);
                    child.Tag = new MaterialDragDropBox { MaterialId = item.Id, MaterialCode = item.Code, MaterialName = item.Name, UnitId = item.BaseUnitId, UnitName = item.BaseUnitName, MaterialType = MaterialType.GasAndIgnition };
                }
            }

            var plasticService = _serviceProvider.GetService<IPlasticAndVisualPartsGroupService>();
            if (plasticService != null)
            {
                var parent = treeList1.AppendNode(new object[] { GetEnumDescription(MaterialType.PlasticAndVisualParts) }, null);
                parent.Tag = MaterialType.PlasticAndVisualParts;
                foreach(var item in plasticService.GetAll().Where(x => x.IsActive))
                {
                    var child = treeList1.AppendNode(new object[] { item.Name }, parent);
                    child.Tag = new MaterialDragDropBox { MaterialId = item.Id, MaterialCode = item.Code, MaterialName = item.Name, UnitId = item.BaseUnitId, UnitName = item.BaseUnitName, MaterialType = MaterialType.PlasticAndVisualParts };
                }
            }

            var chemicalService = _serviceProvider.GetService<IChemicalAndInsulationGroupService>();
            if (chemicalService != null)
            {
                var parent = treeList1.AppendNode(new object[] { GetEnumDescription(MaterialType.ChemicalAndInsulation) }, null);
                parent.Tag = MaterialType.ChemicalAndInsulation;
                foreach(var item in chemicalService.GetAll().Where(x => x.IsActive))
                {
                    var child = treeList1.AppendNode(new object[] { item.Name }, parent);
                    child.Tag = new MaterialDragDropBox { MaterialId = item.Id, MaterialCode = item.Code, MaterialName = item.Name, UnitId = item.BaseUnitId, UnitName = item.BaseUnitName, MaterialType = MaterialType.ChemicalAndInsulation };
                }
            }

            var mechService = _serviceProvider.GetService<IMechanicalAndHardwareGroupService>();
            if (mechService != null)
            {
                var parent = treeList1.AppendNode(new object[] { GetEnumDescription(MaterialType.MechanicalAndHardware) }, null);
                parent.Tag = MaterialType.MechanicalAndHardware;
                foreach(var item in mechService.GetAll().Where(x => x.IsActive))
                {
                    var child = treeList1.AppendNode(new object[] { item.Name }, parent);
                    child.Tag = new MaterialDragDropBox { MaterialId = item.Id, MaterialCode = item.Code, MaterialName = item.Name, UnitId = item.BaseUnitId, UnitName = item.BaseUnitName, MaterialType = MaterialType.MechanicalAndHardware };
                }
            }

            var packService = _serviceProvider.GetService<IPackagingAndPrintingGroupService>();
            if (packService != null)
            {
                var parent = treeList1.AppendNode(new object[] { GetEnumDescription(MaterialType.PackagingAndPrinting) }, null);
                parent.Tag = MaterialType.PackagingAndPrinting;
                foreach(var item in packService.GetAll().Where(x => x.IsActive))
                {
                    var child = treeList1.AppendNode(new object[] { item.Name }, parent);
                    child.Tag = new MaterialDragDropBox { MaterialId = item.Id, MaterialCode = item.Code, MaterialName = item.Name, UnitId = item.BaseUnitId, UnitName = item.BaseUnitName, MaterialType = MaterialType.PackagingAndPrinting };
                }
            }

            var wireService = _serviceProvider.GetService<IWireAndGridGroupService>();
            if (wireService != null)
            {
                var parent = treeList1.AppendNode(new object[] { GetEnumDescription(MaterialType.WireAndGrid) }, null);
                parent.Tag = MaterialType.WireAndGrid;
                foreach(var item in wireService.GetAll().Where(x => x.IsActive))
                {
                    var child = treeList1.AppendNode(new object[] { item.Name }, parent);
                    child.Tag = new MaterialDragDropBox { MaterialId = item.Id, MaterialCode = item.Code, MaterialName = item.Name, UnitId = item.BaseUnitId, UnitName = item.BaseUnitName, MaterialType = MaterialType.WireAndGrid };
                }
            }

            var otherService = _serviceProvider.GetService<IOtherMaterialGroupService>();
            if (otherService != null)
            {
                var parent = treeList1.AppendNode(new object[] { GetEnumDescription(MaterialType.OtherMaterial) }, null);
                parent.Tag = MaterialType.OtherMaterial;
                foreach(var item in otherService.GetAll().Where(x => x.IsActive))
                {
                    var child = treeList1.AppendNode(new object[] { item.Name }, parent);
                    child.Tag = new MaterialDragDropBox { MaterialId = item.Id, MaterialCode = item.Code, MaterialName = item.Name, UnitId = item.BaseUnitId, UnitName = item.BaseUnitName, MaterialType = MaterialType.OtherMaterial };
                }
            }
            
            treeList1.ExpandAll();
        }

        private void glufMamul_SearchButtonClicked(object? sender, EventArgs e)
        {
            if (_serviceProvider != null)
            {
                var form = _serviceProvider.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MamulForms.MamulListForm>();
                if (form != null)
                {
                    form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                    form.ShowDialog();
                    
                    var finishedGoodService = _serviceProvider.GetService<IFinishedGoodService>();
                    if (finishedGoodService != null && glufMamul != null)
                    {
                        glufMamul.Properties.DataSource = finishedGoodService.GetAll().Where(x => x.IsActive).ToList();
                    }
                    
                    if (form.DialogResult == DialogResult.OK && form.SelectedEntities?.Count > 0 && glufMamul != null)
                    {
                        var secilenId = form.SelectedEntities[0].Id;
                        glufMamul.EditValue = secilenId;
                        _currentDto.FinishedGoodId = secilenId;
                    }
                }
            }
        }

        protected override void NesneyiKontrollereBagla()
        {
            CurrentEntity = _currentDto;
            
            if (_currentDto == null) return;
            
            if (this.Id <= 0 || BaseIslemTuru == ActionType.EntityInsert)
            {
                _currentDto.RevisionNumber = "01";
            }

            txtKod.Text = _currentDto.Code;
            txtReceteAdi.Text = _currentDto.Name;
            glufMamul.EditValue = _currentDto.FinishedGoodId > 0 ? _currentDto.FinishedGoodId : null;
            txtAciklama.Text = _currentDto.Description;
            tglDurum.IsOn = _currentDto.IsActive;
            
            if (int.TryParse(_currentDto.RevisionNumber, out int revNo))
            {
                txtRevizyonNo.Value = revNo;
            }
            else
            {
                txtRevizyonNo.Text = _currentDto.RevisionNumber;
            }
            
            txtRevizyonNo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtRevizyonNo.Properties.DisplayFormat.FormatString = "00";

            _lines.Clear();
            if (_currentDto.Lines != null)
            {
                foreach(var line in _currentDto.Lines)
                {
                    _lines.Add(line);
                }
            }
        }

        protected override void GuncelNesneOlustur()
        {
            if (_currentDto == null) _currentDto = new ProductRecipeDto();

            _currentDto.Code = txtKod.Text;
            _currentDto.Name = txtReceteAdi.Text;
            _currentDto.FinishedGoodId = Convert.ToInt64(glufMamul.EditValue);
            _currentDto.Description = txtAciklama.Text;
            _currentDto.IsActive = tglDurum.IsOn;
            
            _currentDto.RevisionNumber = Convert.ToInt32(txtRevizyonNo.Value).ToString("00");
            
            _currentDto.Lines = _lines.ToList();
            CurrentEntity = _currentDto;
        }

        private void TreeList1_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Node.ParentNode == null)
            {
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        private DevExpress.XtraTreeList.Nodes.TreeListNode? _dragNode;

        private void TreeList1_MouseDown(object sender, MouseEventArgs e)
        {
            var hitInfo = treeList1.CalcHitInfo(e.Location);
            _dragNode = hitInfo.Node;
        }

        private void TreeList1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _dragNode != null)
            {
                treeList1.DoDragDrop(_dragNode, DragDropEffects.Copy);
            }
        }

        private void TreeList1_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            // DevExpress varsayılan menülerini Türkçeleştirme
            foreach (DXMenuItem menuItem in e.Menu.Items)
            {
                if (menuItem.Caption == "Full Expand") menuItem.Caption = "Tümünü Genişlet";
                if (menuItem.Caption == "Full Collapse") menuItem.Caption = "Tümünü Daralt";
            }

            if (e.HitInfo.InRow)
            {
                treeList1.FocusedNode = e.HitInfo.Node;
                var item = new DXMenuItem("Seçileni Reçeteye Ekle", new EventHandler(TreeListEkle_Click));
                e.Menu.Items.Add(item);
            }
        }

        private void MyGridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.Menu == null)
            {
                e.Menu = new GridViewMenu(myGridView1);
            }

            if (e.HitInfo.InRow)
            {
                if (e.HitInfo.RowHandle < 0) // Group Row
                {
                    var item = new DXMenuItem("Gruptaki Tümünü Reçeteden Çıkar", new EventHandler(MiDeleteGroup_Click));
                    item.Tag = e.HitInfo.RowHandle;
                    e.Menu.Items.Add(item);

                    e.Menu.Items.Add(new DXMenuItem("Genişlet", (s, ev) => myGridView1.ExpandGroupRow(e.HitInfo.RowHandle)));
                    e.Menu.Items.Add(new DXMenuItem("Daralt", (s, ev) => myGridView1.CollapseGroupRow(e.HitInfo.RowHandle)));
                }
                else
                {
                    var item = new DXMenuItem("Reçeteden Çıkar", new EventHandler(MiDelete_Click));
                    e.Menu.Items.Add(item);
                }
            }

            // Genel Menüler
            e.Menu.Items.Add(new DXMenuItem("Tümünü Genişlet", (s, ev) => myGridView1.ExpandAllGroups()));
            e.Menu.Items.Add(new DXMenuItem("Tümünü Daralt", (s, ev) => myGridView1.CollapseAllGroups()));
        }

        private void MyGridControl1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(typeof(DevExpress.XtraTreeList.Nodes.TreeListNode)))
            {
                var node = e.Data.GetData(typeof(DevExpress.XtraTreeList.Nodes.TreeListNode)) as DevExpress.XtraTreeList.Nodes.TreeListNode;
                if (node != null && node.Tag is MaterialDragDropBox)
                {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }
            
            e.Effect = DragDropEffects.None;
        }

        private void MyGridControl1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetData(typeof(DevExpress.XtraTreeList.Nodes.TreeListNode)) is DevExpress.XtraTreeList.Nodes.TreeListNode node)
            {
                if (node.Tag is MaterialDragDropBox dragData)
                {
                    EkleHammadde(dragData);
                }
            }
        }

        private void TreeListEkle_Click(object? sender, EventArgs e)
        {
            var node = treeList1.FocusedNode;
            if (node != null && node.Tag is MaterialDragDropBox dragData)
            {
                EkleHammadde(dragData);
            }
        }

        private void MiDelete_Click(object? sender, EventArgs e)
        {
            var row = myGridView1.GetFocusedRow() as ProductRecipeLineDto;
            if (row != null)
            {
                _lines.Remove(row);
                myGridView1.RefreshData();
            }
        }

        private void MiDeleteGroup_Click(object? sender, EventArgs e)
        {
            if (sender is DXMenuItem menuItem && menuItem.Tag is int groupRowHandle)
            {
                var childRowCount = myGridView1.GetChildRowCount(groupRowHandle);
                var rowsToDelete = new List<ProductRecipeLineDto>();
                for (int i = 0; i < childRowCount; i++)
                {
                    var childRowHandle = myGridView1.GetChildRowHandle(groupRowHandle, i);
                    var row = myGridView1.GetRow(childRowHandle) as ProductRecipeLineDto;
                    if (row != null)
                        rowsToDelete.Add(row);
                }
                
                foreach(var row in rowsToDelete)
                {
                    _lines.Remove(row);
                }
                myGridView1.RefreshData();
            }
        }

        private void EkleHammadde(MaterialDragDropBox dragData)
        {
            if (dragData == null) return;
            
            if (_lines.Any(x => x.MaterialId == dragData.MaterialId && x.MaterialType == dragData.MaterialType))
            {
                if (XtraMessageBox.Show("Bu hammadde reçetede zaten ekli. Yine de eklemek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }
            
            var newLine = new ProductRecipeLineDto
            {
                MaterialId = dragData.MaterialId,
                MaterialName = dragData.MaterialName,
                MaterialGroupName = GetEnumDescription(dragData.MaterialType),
                UnitId = dragData.UnitId,
                UnitName = dragData.UnitName,
                MaterialType = dragData.MaterialType,
                Quantity = 1,
                WasteRate = 0
            };
            
            _lines.Add(newLine);
            myGridView1.RefreshData();
        }
    }
}
