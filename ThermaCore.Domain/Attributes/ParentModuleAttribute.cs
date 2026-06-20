using System;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class ParentModuleAttribute : Attribute
{
    public ModuleType Parent { get; }

    public ParentModuleAttribute(ModuleType parent)
    {
        Parent = parent;
    }
}
