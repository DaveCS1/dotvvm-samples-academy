﻿namespace DotvvmAcademy.Validation.CSharp.UnitValidation.Abstractions
{
    /// <summary>
    /// A C# event field or property.
    /// </summary>
    public interface ICSharpEvent : ICSharpAllowsAccessModifier, ICSharpAllowsAbstractModifier, ICSharpAllowsStaticModifier, ICSharpAllowsVirtualModifier, ICSharpObject
    {
        CSharpTypeDescriptor Type { get; set; }

        bool IsProperty { get; set; }
    }
}