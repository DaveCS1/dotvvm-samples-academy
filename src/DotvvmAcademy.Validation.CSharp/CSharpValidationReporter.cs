﻿using Microsoft.CodeAnalysis;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DotvvmAcademy.Validation.CSharp
{
    public class CSharpValidationReporter : ValidationReporter
    {
        private readonly CSharpSourceCodeProvider sourceCodeProvider;

        public CSharpValidationReporter(CSharpSourceCodeProvider sourceCodeProvider)
        {
            this.sourceCodeProvider = sourceCodeProvider;
        }

        public void Report(Diagnostic diagnostic)
        {
            var source = sourceCodeProvider.GetSourceCode(diagnostic.Location.SourceTree);
            Report(new CompilationCSharpDiagnostic(diagnostic, source));
        }

        public void Report(string message, ISymbol symbol, ValidationSeverity severity = default)
        {
            Report(message, Enumerable.Empty<object>(), symbol, severity);
        }

        public void Report(string message, IEnumerable<object> arguments, ISymbol symbol, ValidationSeverity severity = default)
        {
            foreach (var reference in symbol.DeclaringSyntaxReferences)
            {
                var source = sourceCodeProvider.GetSourceCode(reference.SyntaxTree);
                var syntax = reference.GetSyntax();
                var start = reference.Span.Start;
                var end = reference.Span.End;
                switch(syntax)
                {
                    case NamespaceDeclarationSyntax namespaceDeclaration:
                        start = namespaceDeclaration.Name.Span.Start;
                        end = namespaceDeclaration.Name.Span.End;
                        break;

                    case BaseTypeDeclarationSyntax typeDeclaration:
                        start = typeDeclaration.Identifier.Span.Start;
                        end = typeDeclaration.Identifier.Span.End;
                        break;

                    case PropertyDeclarationSyntax propertyDeclaration:
                        start = propertyDeclaration.Identifier.Span.Start;
                        end = propertyDeclaration.Identifier.Span.End;
                        break;

                    case EventDeclarationSyntax eventDeclaration:
                        start = eventDeclaration.Identifier.Span.Start;
                        end = eventDeclaration.Identifier.Span.End;
                        break;
                    // TODO: Eventually handler fields
                }
                Report(new SymbolCSharpDiagnostic(
                    message: message,
                    arguments: arguments,
                    start: start,
                    end: end,
                    source: source,
                    symbol: symbol,
                    severity: severity));
            }
        }
    }
}