﻿using Microsoft.CodeAnalysis;
using System;

namespace DotvvmAcademy.Validation.CSharp.UnitValidation
{
    [AttributeUsage(AttributeTargets.Interface, Inherited = true, AllowMultiple = true)]
    public sealed class SymbolKindAttribute : Attribute
    {
        public SymbolKindAttribute(SymbolKind symbolKind)
        {
            SymbolKind = symbolKind;
        }

        public SymbolKind SymbolKind { get; }
    }
}