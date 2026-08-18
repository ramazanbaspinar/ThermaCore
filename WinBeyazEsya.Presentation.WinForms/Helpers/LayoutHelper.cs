using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Text;
using System.Xml.Linq;
using WinBeyazEsya.Application.Interfaces.System;

namespace WinBeyazEsya.Presentation.WinForms.Helpers
{
    public static class LayoutHelper
    {
        #region Form Şablonları

        public static void YukleForm(XtraForm form)
        {
            try
            {
                var layoutService = Program.ServiceProvider?.GetService<ILayoutService>();
                if (layoutService == null) return;

                var xml = layoutService.GetLayout(1, form.Name, form.Name); // 1 is dummy user id
                if (string.IsNullOrWhiteSpace(xml)) return;

                var doc = XDocument.Parse(xml);

                var loc = doc.Descendants("Location").FirstOrDefault();
                var size = doc.Descendants("FormSize").FirstOrDefault();

                if (loc != null &&
                    int.TryParse(loc.Attribute("Left")?.Value, out int left) &&
                    int.TryParse(loc.Attribute("Top")?.Value, out int top))
                {
                    form.Location = new Point(left, top);
                }

                if (size != null)
                {
                    string widthStr = size.Attribute("Width")?.Value;
                    string heightStr = size.Attribute("Height")?.Value;

                    if (widthStr == "-1" && heightStr == "-1")
                    {
                        form.WindowState = FormWindowState.Maximized;
                    }
                    else if (int.TryParse(widthStr, out int width) && int.TryParse(heightStr, out int height))
                    {
                        form.Size = new Size(width, height);
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.HataMesaji("Form şablonu yüklenemedi: " + ex.Message);
            }
        }

        public static void KaydetForm(XtraForm form)
        {
            try
            {
                var layoutService = Program.ServiceProvider?.GetService<ILayoutService>();
                if (layoutService == null) return;

                var xml = new XDocument(
                    new XElement("Tablo",
                        new XElement("Location",
                            new XAttribute("Left", form.Left),
                            new XAttribute("Top", form.Top)
                        ),
                        new XElement("FormSize",
                            new XAttribute("Width", form.WindowState == FormWindowState.Maximized ? "-1" : form.Width.ToString()),
                            new XAttribute("Height", form.WindowState == FormWindowState.Maximized ? "-1" : form.Height.ToString())
                        )
                    )
                );

                layoutService.SaveLayout(1, form.Name, form.Name, xml.ToString());
            }
            catch (Exception ex)
            {
                Messages.HataMesaji("Form şablonu kaydedilemedi: " + ex.Message);
            }
        }

        public static void SifirlaForm(XtraForm form)
        {
            // Sifirla form implemented via layout service if needed, currently dummy
        }

        #endregion

        #region Grid Şablonları

        public static void YukleGrid(GridView grid)
        {
            YukleGrid(grid, GetSablonAdi(grid));
        }

        public static void KaydetGrid(GridView grid)
        {
            KaydetGrid(grid, GetSablonAdi(grid));
        }

        public static void SifirlaGrid(GridView grid)
        {
            SifirlaGrid(GetSablonAdi(grid));
        }

        public static void YukleGrid(GridView grid, string sablonAdi)
        {
            try
            {
                var layoutService = Program.ServiceProvider?.GetService<ILayoutService>();
                if (layoutService == null) return;

                var xml = layoutService.GetLayout(1, "Grid", sablonAdi);
                if (string.IsNullOrWhiteSpace(xml)) return;

                var bytes = Encoding.UTF8.GetBytes(xml);
                using (var ms = new MemoryStream(bytes))
                {
                    grid.RestoreLayoutFromStream(ms);
                }
            }
            catch (Exception ex)
            {
                Messages.HataMesaji($"Grid şablonu yüklenemedi:{ex.Message}");
            }
        }

        public static void KaydetGrid(GridView grid, string sablonAdi)
        {
            try
            {
                var layoutService = Program.ServiceProvider?.GetService<ILayoutService>();
                if (layoutService == null) return;

                using (var ms = new MemoryStream())
                {
                    grid.SaveLayoutToStream(ms);
                    ms.Position = 0;
                    var xml = new StreamReader(ms, Encoding.UTF8).ReadToEnd();

                    layoutService.SaveLayout(1, "Grid", sablonAdi, xml);
                }
            }
            catch (Exception ex)
            {
                Messages.HataMesaji($"Grid şablonu kaydedilemedi: {ex.Message}");
            }
        }

        public static void SifirlaGrid(string sablonAdi)
        {
        }

        private static string GetSablonAdi(GridView grid)
        {
            var gridControl = grid?.GridControl;
            var form = gridControl?.FindForm();
            return form != null ? $"{form.Name}.{grid.Name}" : grid.Name;
        }

        #endregion
    }
}

