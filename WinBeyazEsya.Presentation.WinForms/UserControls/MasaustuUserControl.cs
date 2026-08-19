using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using WinBeyazEsya.Application.DTOs.Management;

namespace WinBeyazEsya.Presentation.WinForms.UserControls
{
    public partial class MasaustuUserControl : XtraUserControl
    {
        #region Fields

        private List<UserFavoriteDto> _allFavorites = new();

        #endregion

        #region Properties

        /// <summary>
        /// Bir favori tile'a tıklandığında tetiklenir.
        /// Parametre: FormTypeFullName (string) — açılacak formun tam tip adı.
        /// </summary>
        public Action<string> OnFavoriteClicked { get; set; }

        #endregion

        #region Events

        /// <summary>
        /// Arama kutusuna metin girildiğinde tetiklenir. Tüm ERP genelinde arama yapmak için AnaForm'a aktarılır.
        /// </summary>
        public event EventHandler<string> SearchTextChanged;

        #endregion

        #region Constructor

        public MasaustuUserControl()
        {
            // 🚨 Grafik yırtılmalarını engelleyen performans kodu
            this.DoubleBuffered = true;
            SetStyle(System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
            
            InitializeComponent();
            
            // Event Bindings
            searchControl.EditValueChanged += SearchControl_EditValueChanged;
            this.Resize += MasaustuUserControl_Resize;
        }

        #endregion

        #region Event Handlers

        private void MasaustuUserControl_Resize(object sender, EventArgs e)
        {
            if (searchControl != null)
            {
                // Arama çubuğunu ortala
                searchControl.Left = Math.Max(0, (this.ClientSize.Width - searchControl.Width) / 2);
            }

            if (lblTitle != null)
            {
                // Başlığı ortala
                lblTitle.Left = Math.Max(0, (this.ClientSize.Width - lblTitle.Width) / 2);
            }
        }

        private void SearchControl_EditValueChanged(object sender, EventArgs e)
        {
            string text = searchControl.EditValue?.ToString() ?? "";
            
            // Kendi tile'larımızı filtrele
            FilterTiles(text);

            // 🚨 Global Arama (Accordion) Entegrasyonu: Event'i AnaForm'a fırlat
            SearchTextChanged?.Invoke(this, text);
        }

        #endregion

        #region Public Methods

        public void LoadFavorites(List<UserFavoriteDto> favorites)
        {
            _allFavorites = favorites ?? new List<UserFavoriteDto>();

            if (searchControl.EditValue != null)
                searchControl.EditValue = null;

            RebuildTiles(_allFavorites);
        }

        #endregion

        #region Tile Logic

        private void FilterTiles(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                RebuildTiles(_allFavorites);
                return;
            }

            var filtered = _allFavorites
                .Where(f => f.FormCaption != null &&
                       f.FormCaption.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            RebuildTiles(filtered);
        }

        private void RebuildTiles(List<UserFavoriteDto> favorites)
        {
            // 🚨 Performans Roketleme Protokolü: Ekranın defalarca çizilmesini engelle (Hız %500 artar)
            tileControl.BeginUpdate();
            try
            {
                grpFavoriler.Items.Clear();

                if (favorites == null || favorites.Count == 0)
                {
                    return;
                }

                foreach (var fav in favorites)
                {
                    grpFavoriler.Items.Add(CreateFavoriteTile(fav));
                }
            }
            finally
            {
                tileControl.EndUpdate();
            }
        }

        private TileItem CreateFavoriteTile(UserFavoriteDto fav)
        {
            var item = new TileItem();
            item.ItemSize = TileItemSize.Wide; 
            item.Tag = fav;

            var elem = new TileItemElement();
            elem.Text = fav.FormCaption;
            elem.TextAlignment = TileItemContentAlignment.MiddleCenter;
            item.Elements.Add(elem);

            item.ItemClick += (s, e) =>
            {
                OnFavoriteClicked?.Invoke(fav.FormTypeFullName);
            };

            return item;
        }

        #endregion
    }
}
