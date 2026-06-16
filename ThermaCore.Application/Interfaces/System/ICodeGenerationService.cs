using ThermaCore.Domain.Enums;

namespace ThermaCore.Application.Interfaces.System;

public interface ICodeGenerationService
{
    string GetNewCode(ModulTuru modul);
}
