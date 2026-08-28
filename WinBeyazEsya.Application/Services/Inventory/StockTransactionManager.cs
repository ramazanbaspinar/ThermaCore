using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinBeyazEsya.Application.DTOs.Inventory;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Interfaces.Services;
using WinBeyazEsya.Domain.Entities.Inventory;
using WinBeyazEsya.Domain.Entities.Production;
using WinBeyazEsya.Domain.Entities.Definitions;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.Services.Inventory;

public class StockTransactionManager : IStockTransactionService
{
    private readonly IRepository<StockTransaction> _stockTransactionRepository;
    private readonly IRepository<Warehouse> _warehouseRepository;
    private readonly IRepository<Unit> _unitRepository;

    private readonly IRepository<MetalSheetGroup> _metalRepository;
    private readonly IRepository<ElectricalElectronicGroup> _electricRepository;
    private readonly IRepository<PlasticAndVisualPartsGroup> _plasticRepository;
    private readonly IRepository<ChemicalAndInsulationGroup> _chemicalRepository;
    private readonly IRepository<MechanicalAndHardwareGroup> _mechanicRepository;
    private readonly IRepository<PackagingAndPrintingGroup> _packRepository;
    private readonly IRepository<WireAndGridGroup> _wireRepository;
    private readonly IRepository<OtherMaterialGroup> _otherRepository;
    private readonly IRepository<RawMaterial> _rawRepository;

    public StockTransactionManager(
        IRepository<StockTransaction> stockTransactionRepository,
        IRepository<Warehouse> warehouseRepository,
        IRepository<Unit> unitRepository,
        IRepository<MetalSheetGroup> metalRepository,
        IRepository<ElectricalElectronicGroup> electricRepository,
        IRepository<PlasticAndVisualPartsGroup> plasticRepository,
        IRepository<ChemicalAndInsulationGroup> chemicalRepository,
        IRepository<MechanicalAndHardwareGroup> mechanicRepository,
        IRepository<PackagingAndPrintingGroup> packRepository,
        IRepository<WireAndGridGroup> wireRepository,
        IRepository<OtherMaterialGroup> otherRepository,
        IRepository<RawMaterial> rawRepository)
    {
        _stockTransactionRepository = stockTransactionRepository;
        _warehouseRepository = warehouseRepository;
        _unitRepository = unitRepository;

        _metalRepository = metalRepository;
        _electricRepository = electricRepository;
        _plasticRepository = plasticRepository;
        _chemicalRepository = chemicalRepository;
        _mechanicRepository = mechanicRepository;
        _packRepository = packRepository;
        _wireRepository = wireRepository;
        _otherRepository = otherRepository;
        _rawRepository = rawRepository;
    }

    private class MatInfo
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public long? BaseUnitId { get; set; }
    }

    public async Task<List<InventoryStatusListDto>> GetInventoryStatusAsync()
    {
        var transactions = _stockTransactionRepository.GetAll().Where(x => !x.IsDeleted).ToList();
        var warehouses = _warehouseRepository.GetAll().ToList();
        var units = _unitRepository.GetAll().ToList();

        var allMaterials = new List<MatInfo>();
        allMaterials.AddRange(_metalRepository.GetAll().Where(x => !x.IsDeleted).Select(x => new MatInfo { Id = x.Id, Code = x.Code, Name = x.Name, BaseUnitId = x.BaseUnitId }));
        allMaterials.AddRange(_electricRepository.GetAll().Where(x => !x.IsDeleted).Select(x => new MatInfo { Id = x.Id, Code = x.Code, Name = x.Name, BaseUnitId = x.BaseUnitId }));
        allMaterials.AddRange(_plasticRepository.GetAll().Where(x => !x.IsDeleted).Select(x => new MatInfo { Id = x.Id, Code = x.Code, Name = x.Name, BaseUnitId = x.BaseUnitId }));
        allMaterials.AddRange(_chemicalRepository.GetAll().Where(x => !x.IsDeleted).Select(x => new MatInfo { Id = x.Id, Code = x.Code, Name = x.Name, BaseUnitId = x.BaseUnitId }));
        allMaterials.AddRange(_mechanicRepository.GetAll().Where(x => !x.IsDeleted).Select(x => new MatInfo { Id = x.Id, Code = x.Code, Name = x.Name, BaseUnitId = x.BaseUnitId }));
        allMaterials.AddRange(_packRepository.GetAll().Where(x => !x.IsDeleted).Select(x => new MatInfo { Id = x.Id, Code = x.Code, Name = x.Name, BaseUnitId = x.BaseUnitId }));
        allMaterials.AddRange(_wireRepository.GetAll().Where(x => !x.IsDeleted).Select(x => new MatInfo { Id = x.Id, Code = x.Code, Name = x.Name, BaseUnitId = x.BaseUnitId }));
        allMaterials.AddRange(_otherRepository.GetAll().Where(x => !x.IsDeleted).Select(x => new MatInfo { Id = x.Id, Code = x.Code, Name = x.Name, BaseUnitId = x.BaseUnitId }));
        allMaterials.AddRange(_rawRepository.GetAll().Where(x => !x.IsDeleted).Select(x => new MatInfo { Id = x.Id, Code = x.Code, Name = x.Name, BaseUnitId = x.BaseUnitId }));

        var grouped = transactions.GroupBy(x => new { x.WarehouseId, x.MaterialId });

        var result = new List<InventoryStatusListDto>();

        foreach (var group in grouped)
        {
            var warehouse = warehouses.FirstOrDefault(w => w.Id == group.Key.WarehouseId);
            var material = allMaterials.FirstOrDefault(m => m.Id == group.Key.MaterialId);
            var unit = material?.BaseUnitId.HasValue == true ? units.FirstOrDefault(u => u.Id == material.BaseUnitId.Value) : null;

            decimal totalIn = group.Where(x => x.MovementType == MovementType.In).Sum(x => x.Quantity);
            decimal totalOut = group.Where(x => x.MovementType == MovementType.Out).Sum(x => x.Quantity);

            result.Add(new InventoryStatusListDto
            {
                WarehouseId = group.Key.WarehouseId,
                WarehouseName = warehouse?.Name ?? "Bilinmiyor",
                MaterialId = group.Key.MaterialId,
                MaterialCode = material?.Code ?? "Bilinmiyor",
                MaterialName = material?.Name ?? "Bilinmiyor",
                UnitName = unit?.Name ?? "Bilinmiyor",
                TotalIn = totalIn,
                TotalOut = totalOut,
                Balance = totalIn - totalOut
            });
        }

        return await Task.FromResult(result);
    }
}
