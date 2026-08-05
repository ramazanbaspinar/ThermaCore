using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Domain.Entities.Definitions;

namespace WinBeyazEsya.Presentation.WinForms.UserControls
{
    public partial class ucBirimCevrimleri : UserControl
    {
        private IUnitConversionService _unitConversionService;
        private IRepository<Unit> _unitRepository;

        public bool IsDirty { get; private set; }
        public event EventHandler OnDirtyChanged;

        public ucBirimCevrimleri()
        {
            InitializeComponent();

            btnEkle.Click += btnEkle_Click;
            gvBirimCevrimleri.RowDeleted += (s, e) => SetDirty();
            gvBirimCevrimleri.PopupMenuShowing += GvBirimCevrimleri_PopupMenuShowing;

            // Set default values and masks
            txtCevrimMiktari.Properties.Mask.EditMask = "n5";
            txtCevrimMiktari.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtCevrimMiktari.EditValue = 1m;
            
            txtAnaBirimMiktari.Properties.Mask.EditMask = "n5";
            txtAnaBirimMiktari.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtAnaBirimMiktari.EditValue = 1m;
            
            txtAnaBirimAd.Properties.ReadOnly = true;
        }

        private void GvBirimCevrimleri_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var deleteItem = new DXMenuItem("Seçili Satırı Sil");
                deleteItem.Click += (s, args) =>
                {
                    if (DevExpress.XtraEditors.XtraMessageBox.Show("Seçili birim çevrimini silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                        return;

                    var bindingList = myGridControl1.DataSource as BindingList<UnitConversionListDto>;
                    var row = gvBirimCevrimleri.GetFocusedRow() as UnitConversionListDto;
                    if (bindingList != null && row != null)
                    {
                        bindingList.Remove(row);
                        SetDirty();
                    }
                };
                e.Menu.Items.Add(deleteItem);

                var clearItem = new DXMenuItem("Tümünü Temizle");
                clearItem.Click += (s, args) =>
                {
                    if (DevExpress.XtraEditors.XtraMessageBox.Show("Tüm birim çevrimlerini silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                        return;

                    var bindingList = myGridControl1.DataSource as BindingList<UnitConversionListDto>;
                    if (bindingList != null)
                    {
                        bindingList.Clear();
                        SetDirty();
                    }
                };
                e.Menu.Items.Add(clearItem);
            }
        }

        public void InitializeDependencies(IUnitConversionService unitConversionService, IRepository<Unit> unitRepository)
        {
            _unitConversionService = unitConversionService;
            _unitRepository = unitRepository;
        }

        private void SetDirty()
        {
            if (!IsDirty)
            {
                IsDirty = true;
                OnDirtyChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Yukle(long entityId, string anaBirimAdi)
        {
            if (_unitConversionService == null || _unitRepository == null) return;

            txtAnaBirimAd.Text = anaBirimAdi;

            var birimler = _unitRepository.GetAll().Where(x => x.IsActive).Select(u => new { u.Id, u.Code, u.Name }).ToList();
            glufCevrilecekBirim.Properties.DataSource = birimler;
            glufCevrilecekBirim.Properties.ValueMember = "Id";
            glufCevrilecekBirim.Properties.DisplayMember = "Name";

            var conversions = _unitConversionService.GetByEntityId(entityId).ToList();
            
            foreach (var c in conversions)
            {
                c.UnitName = birimler.FirstOrDefault(b => b.Id == c.UnitId)?.Name ?? string.Empty;
            }

            var bindingList = new BindingList<UnitConversionListDto>(conversions);
            myGridControl1.DataSource = bindingList;

            IsDirty = false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (glufCevrilecekBirim.EditValue == null || glufCevrilecekBirim.EditValue.ToString() == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Lütfen çevrilecek birimi seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var divisor = Convert.ToDecimal(txtCevrimMiktari.EditValue);
            var multiplier = Convert.ToDecimal(txtAnaBirimMiktari.EditValue);

            if (divisor <= 0 || multiplier <= 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Miktarlar 0'dan büyük olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var unitId = Convert.ToInt64(glufCevrilecekBirim.EditValue);
            var unitName = glufCevrilecekBirim.Text;

            var bindingList = myGridControl1.DataSource as BindingList<UnitConversionListDto>;
            if (bindingList != null)
            {
                if (bindingList.Any(x => x.UnitId == unitId))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Bu birim zaten listeye eklenmiş.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newDto = new UnitConversionListDto
                {
                    UnitId = unitId,
                    UnitName = unitName,
                    Divisor = divisor,
                    Multiplier = multiplier,
                    IsMainUnit = false
                };

                bindingList.Add(newDto);
                SetDirty();

                txtCevrimMiktari.EditValue = 1m;
                txtAnaBirimMiktari.EditValue = 1m;
                glufCevrilecekBirim.EditValue = null;
                
                gvBirimCevrimleri.MoveLast();
            }
        }

        public void PostGridChanges()
        {
            gvBirimCevrimleri.PostEditor();
            gvBirimCevrimleri.UpdateCurrentRow();
        }

        public void Kaydet(long entityId)
        {
            if (_unitConversionService == null) return;

            PostGridChanges();

            var dataSource = myGridControl1.DataSource as BindingList<UnitConversionListDto>;
            if (dataSource != null)
            {
                var conversionsToSave = dataSource.Select(c => new UnitConversionDto
                {
                    Id = c.Id,
                    EntityId = entityId,
                    UnitId = c.UnitId,
                    Multiplier = c.Multiplier,
                    Divisor = c.Divisor,
                    IsMainUnit = c.IsMainUnit
                }).ToList();

                _unitConversionService.SaveChanges(entityId, conversionsToSave);
                IsDirty = false;
            }
        }
    }
}

