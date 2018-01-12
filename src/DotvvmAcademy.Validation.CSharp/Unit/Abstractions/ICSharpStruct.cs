﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;

namespace DotvvmAcademy.Validation.CSharp.Unit.Abstractions
{
    /// <summary>
    /// A C# struct.
    /// </summary>
    [SyntaxKind(SyntaxKind.StructDeclaration)]
    public interface ICSharpStruct : ICSharpConstructibleType, ICSharpObject
    {
    }
}