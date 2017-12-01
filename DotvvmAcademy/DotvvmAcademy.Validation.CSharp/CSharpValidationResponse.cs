﻿using DotvvmAcademy.Validation.Abstractions;
using System.Collections.Immutable;
using System.Reflection;

namespace DotvvmAcademy.Validation.CSharp
{
    public class CSharpValidationResponse : IValidationResponse
    {
        public ImmutableArray<ValidationDiagnostic> Diagnostics { get; set; } = ImmutableArray.Create<ValidationDiagnostic>();

        public Assembly EmittedAssembly { get; set; }
    }
}