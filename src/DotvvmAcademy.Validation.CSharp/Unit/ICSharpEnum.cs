﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;

namespace DotvvmAcademy.Validation.CSharp.Unit
{
    /// <summary>
    /// A C# enum.
    /// </summary>
    [SyntaxKind(SyntaxKind.EnumDeclaration)]
    [SymbolKind(SymbolKind.NamedType)]
    public interface ICSharpEnum : ICSharpAllowsAccessModifier, ICSharpObject, ICSharpType
    {
        IList<string> Members { get; set; }
    }
}