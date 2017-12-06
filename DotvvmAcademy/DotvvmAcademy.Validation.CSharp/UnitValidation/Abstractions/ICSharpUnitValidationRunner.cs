﻿using DotvvmAcademy.Validation.CSharp.DynamicAnalysis;
using DotvvmAcademy.Validation.CSharp.StaticAnalysis;
using System.Reflection;

namespace DotvvmAcademy.Validation.CSharp.UnitValidation.Abstractions
{
    public interface ICSharpUnitValidationRunner
    {
        (CSharpStaticAnalysisContext, CSharpDynamicAnalysisContext) Run(MethodInfo method);
    }
}