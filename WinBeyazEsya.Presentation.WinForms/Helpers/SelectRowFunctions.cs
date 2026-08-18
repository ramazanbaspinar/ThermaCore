using DevExpress.Data;
using DevExpress.XtraGrid.Views.Grid;
using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Presentation.WinForms.Helpers
{
    public class SelectRowFunctions : IDisposable
    {
        private GridView _tablo;
        private readonly List<BaseDto> _selectedRows;

        public SelectRowFunctions(GridView tablo)
        {
            _tablo = tablo ?? throw new ArgumentNullException(nameof(tablo));
            _selectedRows = new List<BaseDto>();

            ConfigureGridSelection();

            _tablo.SelectionChanged += Tablo_SelectionChanged;

            SyncSelectedRows();
        }

        private void ConfigureGridSelection()
        {
            _tablo.OptionsSelection.MultiSelect = true;

            if (_tablo.OptionsSelection.MultiSelectMode != GridMultiSelectMode.CheckBoxRowSelect)
            {
                _tablo.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                _tablo.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
            }
        }

        private void Tablo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SyncSelectedRows();
        }

        private void SyncSelectedRows()
        {
            _selectedRows.Clear();

            foreach (var rowHandle in _tablo.GetSelectedRows())
            {
                if (_tablo.IsDataRow(rowHandle))
                {
                    var row = _tablo.GetRow(rowHandle) as BaseDto;
                    if (row != null && !_selectedRows.Any(x => x.Id == row.Id))
                    {
                        _selectedRows.Add(row);
                    }
                }
            }
        }

        public int SelectedRowCount => _selectedRows.Count;

        public BaseDto GetSelectedRow(int index) => _selectedRows[index];

        public IList<BaseDto> GetSelectedRows() => _selectedRows.ToList();

        public int GetSelectedRowIndex(BaseDto row) =>
            _selectedRows.FindIndex(x => x.Id == row?.Id);

        public bool IsRowSelected(int rowHandle)
        {
            var row = _tablo.GetRow(rowHandle) as BaseDto;
            return row != null && _selectedRows.Any(x => x.Id == row.Id);
        }

        public void SelectAll()
        {
            _tablo.SelectAll();
        }

        public void ClearSelection()
        {
            _tablo.ClearSelection();
        }

        public void Dispose()
        {
            if (_tablo != null)
            {
                _tablo.SelectionChanged -= Tablo_SelectionChanged;
                _tablo = null;
            }
        }
    }
}

