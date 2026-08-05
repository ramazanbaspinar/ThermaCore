using System;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Domain.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class ParentModuleAttribute : Attribute
{
    public ModuleType Parent { get; }

    public ParentModuleAttribute(ModuleType parent)
    {
        Parent = parent;
    }
}

