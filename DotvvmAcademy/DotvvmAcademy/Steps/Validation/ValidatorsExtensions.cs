﻿using System;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Compilation.ControlTree;
using DotVVM.Framework.Compilation.ControlTree.Resolved;
using DotvvmAcademy.Steps.Validation.Validators;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CSharp.RuntimeBinder;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace DotvvmAcademy.Steps.Validation
{
    public static class ValidatorsExtensions
    {
        public static Assembly CompileToAssembly(this CSharpCompilation compilation)
        {
            using (var ms = new MemoryStream())
            {
                var emitResult = compilation.Emit(ms);
                if (!emitResult.Success)
                {
                    throw new CodeValidationException("The code couldn't be compiled!\r\n" + string.Join("\r\n", emitResult.Diagnostics));
                }
                ms.Position = 0;

                return AssemblyLoadContext.Default.LoadFromStream(ms);
            }
        }

        public static void ExecuteSafe(Action action)
        {
            try
            {
                action();
            }
            catch (RuntimeBinderException ex)
            {
                throw new CodeValidationException(ValidationErrorMessages.CommandMethodError, ex);
            }
            catch (CodeValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new CodeValidationException("Unexpected exception has occurred.", ex);
            }
        }

        public static string GetCommandBindingText(this ResolvedControl control, IPropertyDescriptor property)
        {
            IAbstractPropertySetter binding;
            if (!control.TryGetProperty(property, out binding) || !(binding is ResolvedPropertyBinding))
            {
                throw new CodeValidationException(string.Format(ValidationErrorMessages.MissingPropertyError,
                    control.Metadata.Type.Name,
                    property.Name));
            }

            var typedBinding = (ResolvedPropertyBinding)binding;
            if (typedBinding.Binding.BindingType != typeof(CommandBindingExpression))
            {
                throw new CodeValidationException(string.Format(ValidationErrorMessages.CommandBindingExpected,
                    control.Metadata.Type.Name,
                    property.Name));
            }

            return typedBinding.Binding.Value.Trim();
        }

        public static IEnumerable<ResolvedControl> GetDescendantControls<T>(this ResolvedPropertyTemplate node)
        {
            return GetDescendants(node).OfType<ResolvedControl>().Where(c => c.Metadata.Type == typeof(T));
        }

        public static IEnumerable<ResolvedControl> GetDescendantControls<T>(this ResolvedContentNode node)
        {
            return GetDescendants(node).OfType<ResolvedControl>().Where(c => c.Metadata.Type == typeof(T));
        }

        public static IEnumerable<ResolvedTreeNode> GetDescendants(this ResolvedContentNode node)
        {
            yield return node;
            foreach (ResolvedTreeNode child in node.Content.SelectMany(n => n.GetDescendants()))
            {
                yield return child;
            }
        }

        public static IEnumerable<ResolvedTreeNode> GetDescendants(this ResolvedPropertyTemplate node)
        {
            foreach (var child in node.Content.SelectMany(n => n.GetDescendants()))
            {
                yield return child;
            }
        }

        public static IEnumerable<ResolvedControl> GetChildrenControls<T>(this ResolvedContentNode node)
        {
            return node.Content.OfType<ResolvedControl>().Where(c => c.Metadata.Type == typeof(T));
        }

        public static string GetValue(this ResolvedControl control, IPropertyDescriptor property)
        {
            IAbstractPropertySetter value;
            if (!control.TryGetProperty(property, out value) || !(value is ResolvedPropertyValue))
            {
                throw new CodeValidationException(string.Format(ValidationErrorMessages.MissingPropertyError,
                    control.Metadata.Type.Name,
                    property.Name));
            }
            return ((ResolvedPropertyValue)value).Value?.ToString();
        }

        public static ResolvedPropertyBinding GetValueBindingOrNull(this ResolvedControl control,
                    IPropertyDescriptor property)
        {
            IAbstractPropertySetter binding;
            if (!control.TryGetProperty(property, out binding))
            {
                return null;
            }
            return binding as ResolvedPropertyBinding;
        }

        public static string GetValueBindingText(this ResolvedControl control, IPropertyDescriptor property)
        {
            IAbstractPropertySetter binding;
            if (!control.TryGetProperty(property, out binding) || !(binding is ResolvedPropertyBinding))
            {
                throw new CodeValidationException(string.Format(ValidationErrorMessages.MissingPropertyError,
                    control.Metadata.Type.Name,
                    property.Name));
            }

            var typedBinding = (ResolvedPropertyBinding)binding;
            if (typedBinding.Binding.BindingType != typeof(ValueBindingExpression))
            {
                throw new CodeValidationException(string.Format(ValidationErrorMessages.ValueBindingExpected,
                    control.Metadata.Type.Name,
                    property.Name));
            }

            return typedBinding.Binding.Value.Trim();
        }

        public static string GetValueBindingTextOrNull(this ResolvedControl control, IPropertyDescriptor property)
        {
            IAbstractPropertySetter binding;
            if (!control.TryGetProperty(property, out binding) || !(binding is ResolvedPropertyBinding))
            {
                return null;
            }
            var typedBinding = (ResolvedPropertyBinding)binding;
            if (typedBinding.Binding.BindingType != typeof(ValueBindingExpression))
            {
                return null;
            }
            return typedBinding.Binding.Value.Trim();
        }

        public static string GetValueOrNull(this ResolvedControl control, IPropertyDescriptor property)
        {
            IAbstractPropertySetter value;
            if (!control.TryGetProperty(property, out value) || !(value is ResolvedPropertyValue))
            {
                return null;
            }
            return ((ResolvedPropertyValue)value).Value?.ToString();
        }

        public static bool CheckNameAndType(this IPropertySymbol symbol, string name, string type)
        {
            return (symbol.Name == name)
                   && (symbol.Type.ToDisplayString() == type)
                   && (symbol.DeclaredAccessibility == Accessibility.Public)
                   && (symbol.GetMethod != null)
                   && (symbol.SetMethod != null);
        }

        public static bool CheckNameAndType(this IMethodSymbol symbol, string name, string type)
        {
            return (symbol.Name == name)
                   && (symbol.ReturnType.ToDisplayString() == type)
                   && (symbol.DeclaredAccessibility == Accessibility.Public);
        }

        public static bool CheckNameAndVoid(this IMethodSymbol symbol, string name)
        {
            return (symbol.Name == name)
                   && symbol.ReturnsVoid
                   && (symbol.DeclaredAccessibility == Accessibility.Public);
        }

        public static void ValidateCommandBindingExpression(this ResolvedControl control, IPropertyDescriptor property,
                                    string desiredExpression)
        {
            var binding = GetCommandBindingText(control, property).Replace(" ", "");
            if ((binding != desiredExpression) && binding.StartsWith(desiredExpression))
            {
                throw new CodeValidationException(string.Format(ValidationErrorMessages.CommandDoesNotHaveParenthesis,
                    desiredExpression));
            }
            if (binding != desiredExpression)
            {
                throw new CodeValidationException(string.Format(ValidationErrorMessages.MethodWasNotCalled,
                    desiredExpression));
            }
        }
    }
}