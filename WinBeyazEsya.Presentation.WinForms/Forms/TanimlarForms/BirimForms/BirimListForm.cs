using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Interfaces.Repositories.Definitions;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BirimForms
{
    public partial class BirimListForm : BaseListForm
    {
        private readonly IUnitRepository _unitRepository = default!;
        private readonly IUnitOfWork _uow = default!;

        public BirimListForm()
        {
            InitializeComponent();
        }

        public BirimListForm(IUnitRepository unitRepository, IUnitOfWork uow)
        {
            InitializeComponent();
            _unitRepository = unitRepository;
            _uow = uow;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridViewPro1;
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.BirimTanimlari; // Assume this enum exists
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = true;
        }

        protected override void Listele()
        {
            var units = _unitRepository.Find(x => x.IsActive == AktifKartlariGoster).ToList();
            var dtoList = units.Select(x => new UnitDto
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
                IsActive = x.IsActive
            }).ToList();

            Tablo.GridControl.DataSource = dtoList;
        }

        protected override void ShowEditForm(long id)
        {
            var form = Program.ServiceProvider.GetRequiredService<BirimEditForm>();
            if (form != null)
            {
                form.IdAtaVeAc(id);
                Listele();
                if (form.Id > 0)
                {
                    Tablo.RowFocus("Id", form.Id);
                }
            }
        }

        protected override void EntityDelete()
        {
            if (Tablo.FocusedRowHandle < 0) return;

            long entityId = 0;
            long.TryParse(Tablo.GetFocusedRowCellValue("Id")?.ToString(), out entityId);
            
            if (entityId <= 0) return;

            if (XtraMessageBox.Show("Seçili birimi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var entity = _unitRepository.GetById(entityId);
                    if (entity != null)
                    {
                        _unitRepository.Remove(entity);
                        _uow.SaveChanges();
                        Listele();
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
