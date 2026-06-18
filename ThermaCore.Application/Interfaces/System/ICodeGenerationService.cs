using ThermaCore.Domain.Enums;
using ThermaCore.Application.DTOs.Management;
using System.Threading.Tasks;

namespace ThermaCore.Application.Interfaces.System;

public interface ICodeGenerationService
{
    Task<string> GetNewCodeAsync(ModuleType modul, long firmaId = 0);
    Task<CodeGenerationResultDto> GetNewCodeAsync(CodeGenerationRequestDto request);
    Task SaveCodeAsync(ModuleType modul, long firmaId, string generatedCode, long? branchId = null);
}
