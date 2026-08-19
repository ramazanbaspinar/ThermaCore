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

        #region Constructor

        public MasaustuUserControl()
        {
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
                // Arama çubuğunu panellere hapsetmeden, arka planın üzerinde havada ortala
                searchControl.Left = Math.Max(0, (this.ClientSize.Width - searchControl.Width) / 2);
            }
        }

        private void SearchControl_EditValueChanged(object sender, EventArgs e)
        {
            string text = searchControl.EditValue?.ToString() ?? "";
            FilterTiles(text);
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
            grpFavoriler.Items.Clear();

            if (favorites == null || favorites.Count == 0)
            {
                CreateEmptyStateTile();
                return;
            }

            foreach (var fav in favorites)
            {
                grpFavoriler.Items.Add(CreateFavoriteTile(fav));
            }
        }

        private TileItem CreateFavoriteTile(UserFavoriteDto fav)
        {
            var item = new TileItem();
            
            // 🚨 Sadece dikdörtgen (Wide) kutular
            item.ItemSize = TileItemSize.Wide; 
            item.Tag = fav;

            // 🚨 Emojiler İptal: Sadece formun adı, tam orta hizalama
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

        private void CreateEmptyStateTile()
        {
            var item = new TileItem();
            item.ItemSize = TileItemSize.Wide;
            item.Enabled = false;

            var elem = new TileItemElement();
            elem.Text = "Henüz favori eklenmemiş";
            elem.TextAlignment = TileItemContentAlignment.MiddleCenter;
            item.Elements.Add(elem);

            grpFavoriler.Items.Add(item);
        }

        #endregion
    }
}
