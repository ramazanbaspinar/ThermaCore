using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Interfaces.Definitions;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Definitions;

namespace ThermaCore.Presentation.WinForms.UserControls
{
    public partial class ucBirimCevrimleri : UserControl
    {
        private IUnitConversionService _unitConversionService;
        private IRepository<Unit> _unitRepository;
        
        // This is kept for designer support if needed
        public ucBirimCevrimleri()
        {
            InitializeComponent();
        }

        // Dependency Injection constructor
        public ucBirimCevrimleri(IUnitConversionService unitConversionService, IRepository<Unit> unitRepository) : this()
        {
            _unitConversionService = unitConversionService;
            _unitRepository = unitRepository;
        }
        
        // If your framework doesn't use constructor injection for UserControls,
        // you can call this method to initialize dependencies.
        public void InitializeDependencies(IUnitConversionService unitConversionService, IRepository<Unit> unitRepository)
        {
            _unitConversionService = unitConversionService;
            _unitRepository = unitRepository;
        }

        public void Yukle(Guid entityId)
        {
            if (_unitConversionService == null || _unitRepository == null) return;
            
            // Hedef Birim LookUp doldurma
            var birimler = _unitRepository.GetAll().Select(u => new { u.Id, u.Code, u.Name }).ToList();
            repositoryItemGridLookUpEdit1.DataSource = birimler;
            repositoryItemGridLookUpEdit1.ValueMember = "Id";
            repositoryItemGridLookUpEdit1.DisplayMember = "Name";

            // Entity'e ait çevrimleri getir
            var conversions = _unitConversionService.GetByEntityId(entityId).ToList();
            
            // Grid'in DataSource'unu ayarlayalım, yeni satır eklenebilmesi için BindingList kullanabiliriz
            // DTO List formunda binding kolaylığı için
            var bindingList = new BindingList<UnitConversionDto>(
                conversions.Select(c => new UnitConversionDto 
                { 
                    Id = c.Id, 
                    EntityId = c.EntityId, 
                    UnitId = c.UnitId, 
                    Multiplier = c.Multiplier, 
                    Divisor = c.Divisor, 
                    IsMainUnit = c.IsMainUnit 
                }).ToList()
            );

            myGridControl1.DataSource = bindingList;
        }

        public void PostGridChanges()
        {
            gvBirimCevrimleri.PostEditor();
            gvBirimCevrimleri.UpdateCurrentRow();
        }

        public void Kaydet(Guid entityId)
        {
            if (_unitConversionService == null) return;
            
            PostGridChanges();
            
            var dataSource = myGridControl1.DataSource as BindingList<UnitConversionDto>;
            if (dataSource != null)
            {
                var conversionsToSave = dataSource.ToList();
                _unitConversionService.SaveChanges(entityId, conversionsToSave);
            }
        }
    }
}
