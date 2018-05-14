﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;

namespace DotvvmAcademy.Validation.CSharp
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class SymbolAccessibilityAnalyzer : ValidationDiagnosticAnalyzer
    {
        public const string MetadataKey = "Accessibility";

        public static readonly DiagnosticDescriptor WrongAccessibilityDiagnostic = new DiagnosticDescriptor(
            id: "TEMP04",
            title: "Wrong Accessibility",
            messageFormat: "Symbol {0} must have one of these accesibility levels: {1}.",
            category: "Temporary",
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        private readonly SymbolLocator locator;
        private readonly ImmutableArray<MetadataName> names;

        public SymbolAccessibilityAnalyzer(MetadataCollection<MetadataName> metadata, SymbolLocator locator) : base(metadata)
        {
            names = GetNamesWithProperty(MetadataKey);
            this.locator = locator;
        }

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; }
            = ImmutableArray.Create(WrongAccessibilityDiagnostic);

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterCompilationAction(ValidateCompilation);
        }

        private void ValidateCompilation(CompilationAnalysisContext context)
        {
            foreach(var name in names)
            {
                var desired = Metadata.GetRequiredProperty<Accessibility>(name, MetadataKey);
                if(locator.TryLocate(name, out var symbol) 
                    && (desired ^ symbol.DeclaredAccessibility) != 0)
                {
                    foreach(var location in symbol.Locations)
                    {
                        context.ReportDiagnostic(Diagnostic.Create(WrongAccessibilityDiagnostic, location, name, desired.ToString("G")));
                    }
                }
            }
        }
    }
}