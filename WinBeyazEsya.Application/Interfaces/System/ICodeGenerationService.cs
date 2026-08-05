using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Application.DTOs.Management;
using System.Threading.Tasks;

namespace WinBeyazEsya.Application.Interfaces.System;

public interface ICodeGenerationService
{
    Task<string> GetNewCodeAsync(ModuleType modul, long firmaId = 0);
    Task<CodeGenerationResultDto> GetNewCodeAsync(CodeGenerationRequestDto request);
    Task SaveCodeAsync(ModuleType modul, long firmaId, string generatedCode, long? branchId = null);
    Task UpdateLastCodeValueAsync(long logId, int newValue);
}

