using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinBeyazEsya.Application.DTOs.Definitions;

namespace WinBeyazEsya.Presentation.WinForms.Forms.UretimForms
{
    public partial class UrunMaliyetDetaylariForm : DevExpress.XtraEditors.XtraForm
    {
        public UrunMaliyetDetaylariForm(
            ProductRecipeDto currentRecipe,
            string urunAdi,
            decimal netMalzemeTutari,
            decimal toplamFireTutari,
            decimal gugTutari,
            decimal genelToplam,
            string paraBirimi)
        {
            InitializeComponent();

            // === HEADER ===
            lblUrunKodu.Text = currentRecipe.Code;
            lblReceteAdi.Text = currentRecipe.Name;
            lblUrunAdi.Text = urunAdi;
            lblRevizyon.Text = currentRecipe.RevisionNumber;

            // === GRID ===
            if (currentRecipe.Lines != null && currentRecipe.Lines.Count > 0)
            {
                gridControl.DataSource = currentRecipe.Lines.ToList();
            }

            // Satır Maliyeti summary'ye para birimini ekle
            colSatirMaliyeti.Summary.Clear();
            colSatirMaliyeti.Summary.Add(new DevExpress.XtraGrid.GridColumnSummaryItem(
                DevExpress.Data.SummaryItemType.Sum, "TotalMaterialCost", $"Toplam: {{0:n2}} {paraBirimi}"));

            // === FOOTER ===
            lblNetMalzemeDeger.Text = $"{netMalzemeTutari:n2} {paraBirimi}";
            lblFireDeger.Text = $"{toplamFireTutari:n2} {paraBirimi}";
            lblGugDeger.Text = $"{gugTutari:n2} {paraBirimi}";
            lblToplamDeger.Text = $"{genelToplam:n2} {paraBirimi}";

            // === KAPAT BUTONU ===
            btnKapat.Click += (s, e) => this.Close();
        }
    }
}
