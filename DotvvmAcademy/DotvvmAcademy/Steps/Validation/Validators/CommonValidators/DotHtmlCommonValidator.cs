﻿using System;
using DotVVM.Framework.Compilation.ControlTree;
using DotVVM.Framework.Compilation.ControlTree.Resolved;
using DotVVM.Framework.Compilation.Parser.Dothtml.Parser;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Utils;
using DotvvmAcademy.Steps.Validation.Validators.PropertyAndControlType;
using System.Collections.Generic;
using System.Linq;

namespace DotvvmAcademy.Steps.Validation.Validators.CommonValidators
{
    public static class DotHtmlCommonValidator
    {
        public static ResolvedControl GetControlInRepeater<T>(ResolvedContentNode resolvedContentNode)
            where T : HtmlGenericControl
        {
            var repeaterTemplate = GetRepeaterTemplate(resolvedContentNode);
            return repeaterTemplate
                .GetDescendantControls<T>()
                .Single();
        }

        public static ResolvedPropertyTemplate GetRepeaterTemplate(ResolvedContentNode resolvedContentNode)
        {
            return resolvedContentNode.GetDescendantControls<Repeater>().Single()
                .Properties[Repeater.ItemTemplateProperty]
                .CastTo<ResolvedPropertyTemplate>();
        }

        public static void CheckControlTypeCount<T>(ResolvedContentNode resolvedTreeRoot, int count)
            where T : HtmlGenericControl
        {
            if (resolvedTreeRoot.GetDescendantControls<T>().Count() != count)
            {
                throw new CodeValidationException(string.Format(ValidationErrorMessages.TypeControlCountError, count,
                    typeof(T).Name));
            }
        }

        public static void CheckControlTypeCountInRepeater<T>(ResolvedContentNode resolvedTreeRoot, int count)
            where T : HtmlGenericControl
        {
            var repeaterTemplate = GetRepeaterTemplate(resolvedTreeRoot);
            if (repeaterTemplate.GetDescendantControls<T>().Count() != count)
            {
                throw new CodeValidationException(string.Format(ValidationErrorMessages.TypeControlCountError, count,
                    typeof(T).Name));
            }
        }

        public static void CheckCountOfHtmlTag(ResolvedContentNode resolvedTreeRoot, string htmlTag, int count, CodeValidationException codeValidationException = null)
        {
            var counter = resolvedTreeRoot
                .GetChildrenControls<HtmlGenericControl>()
                .Count(d => d.DothtmlNode.As<DothtmlElementNode>()?.TagName == htmlTag);
            if (counter != count)
            {
                if (codeValidationException == null)
                {
                    throw new CodeValidationException(string.Format(ValidationErrorMessages.HtmlTagCountError, count,
                   htmlTag));
                }
                throw codeValidationException;
            }
        }

        public static void CheckCountOfHtmlTagWithPropertyDescriptor(ResolvedContentNode resolvedTreeRoot, string htmlTag, int count, IPropertyDescriptor propertyDescriptor, CodeValidationException codeValidationException)
        {
            var counter = resolvedTreeRoot
                .GetChildrenControls<HtmlGenericControl>()
                .Where(d => d.DothtmlNode.As<DothtmlElementNode>()?.TagName == htmlTag)
                .Count(d => d.GetValueOrNull(propertyDescriptor) != null);
            if (counter != count)
            {
                throw codeValidationException;
            }
        }

        public static void ValidatePropertiesBindings(ResolvedContentNode resolvedContentNode,
            List<Property> propertiesToValidate)
        {
            foreach (var property in propertiesToValidate)
            {
                ValidatePropertyBinding(resolvedContentNode, property);
            }
        }

        public static void ValidatePropertyBinding(ResolvedContentNode resolvedContentNode, Property propertyToValidate)
        {
            var propertiesBindings = new List<string>();

            switch (propertyToValidate.TargetControlBindName)
            {
                case ControlBindName.TextBoxText:
                    FillTextBoxTextBinding(resolvedContentNode, ref propertiesBindings);
                    break;

                case ControlBindName.RadioButtonCheckedItem:
                    FillRadioButtonCheckedItemBinding(resolvedContentNode, ref propertiesBindings);
                    break;

                case ControlBindName.ComboBoxDataSource:
                    FillComboBoxDataSourceBinding(resolvedContentNode, ref propertiesBindings);
                    break;

                case ControlBindName.ComboBoxSelectedValue:
                    FillComboBoxSelectedValueBinding(resolvedContentNode, ref propertiesBindings);
                    break;

                case ControlBindName.ComboBoxValueMemberNotBind:
                    FillComboBoxValueMemberValue(resolvedContentNode, ref propertiesBindings);
                    break;

                case ControlBindName.ComboBoxDisplayMemberNotBind:
                    FillComboBoxDisplayMemberValue(resolvedContentNode, ref propertiesBindings);
                    break;

                case ControlBindName.RepeaterDataSource:
                    FillRepeaterDataSourceBinding(resolvedContentNode, ref propertiesBindings);
                    break;

                case ControlBindName.RepeaterLiteral:
                    FillRepeaterLiteralBinding(resolvedContentNode, ref propertiesBindings);
                    break;

                case ControlBindName.RepeaterDivClass:
                    propertiesBindings.AddRange(GetRepeaterDivClassBinding(resolvedContentNode));
                    break;

                case ControlBindName.CheckBoxCheckedItems:
                    FillCheckBoxCheckedItemsBinding(resolvedContentNode, ref propertiesBindings);
                    break;

                case ControlBindName.DivClass:
                    FillDivClassValue(resolvedContentNode, ref propertiesBindings);
                    break;

                case ControlBindName.DivDataContext:
                    FillDivDataContextValueBinding(resolvedContentNode, ref propertiesBindings);
                    break;

                case ControlBindName.DivValidatorValue:
                    FillDivValidatorValueBinding(resolvedContentNode, ref propertiesBindings);
                    break;

                case ControlBindName.DivValidatorInvalidCssClass:
                    FillDivValidatorInvalidCssClassValue(resolvedContentNode, ref propertiesBindings);
                    break;

                case ControlBindName.FormValidatorInvalidCssClass:
                    FillFormValidatorInvalidCssClassValue(resolvedContentNode, ref propertiesBindings);
                    break;

                case ControlBindName.DivValidatorInvalidCssClassRemove:
                    FillDivValidatorInvalidCssClassValue(resolvedContentNode, ref propertiesBindings);
                    break;

                case ControlBindName.ValidatorShowErrorMessageText:
                    FillValidatorShowErrorMessageTextValue(resolvedContentNode, ref propertiesBindings);
                    break;

                case ControlBindName.ValidatorValue:
                    FillValidatorValueBinding(resolvedContentNode, ref propertiesBindings);
                    break;

                default:
                    throw new ArgumentException($"Property {propertyToValidate.Name}, cant be validate in DotHtml.");
            }

            var propertyName = propertyToValidate.Name;
            if (propertyToValidate.TargetControlBindName.RemovePropertyFromCode())
            {
                if (propertiesBindings.Contains(propertyName))
                {
                    throw new CodeValidationException(string.Format(ValidationErrorMessages.DeleteCodeError,
                        propertyName, propertyToValidate.TargetControlBindName.ToDescriptionString()));
                }
            }
            else
            {
                if (!propertiesBindings.Contains(propertyName))
                {
                    throw new CodeValidationException(string.Format(ValidationErrorMessages.ValueBindingError,
                        propertyToValidate.TargetControlBindName.ToDescriptionString(), propertyName));
                }
            }
        }

        private static void FillComboBoxDataSourceBinding(ResolvedContentNode resolvedContentNode,
            ref List<string> propertiesBindings)
        {
            propertiesBindings.Add(resolvedContentNode.GetDescendantControls<ComboBox>()
                .Select(c => c.GetValueBindingText(ItemsControl.DataSourceProperty))
                .FirstOrDefault());
        }

        private static void FillComboBoxDisplayMemberValue(ResolvedContentNode resolvedContentNode,
            ref List<string> propertiesBindings)
        {
            propertiesBindings.AddRange(resolvedContentNode.GetDescendantControls<ComboBox>()
                .Select(c => c.GetValue(SelectorBase.ItemValueBindingProperty)));
        }

        private static void FillComboBoxSelectedValueBinding(ResolvedContentNode resolvedContentNode,
            ref List<string> propertiesBindings)
        {
            propertiesBindings.AddRange(resolvedContentNode.GetDescendantControls<ComboBox>()
                .Select(c => c.GetValueBindingText(Selector.SelectedValueProperty)));
        }

        private static void FillComboBoxValueMemberValue(ResolvedContentNode resolvedContentNode,
            ref List<string> propertiesBindings)
        {
            propertiesBindings.AddRange(resolvedContentNode.GetDescendantControls<ComboBox>()
                .Select(c => c.GetValue(SelectorBase.ItemValueBindingProperty)));
        }

        private static void FillDivClassValue(ResolvedContentNode resolvedContentNode,
            ref List<string> propertiesBindings)
        {
            var result = new List<string>();
            IEnumerable<ResolvedControl> divs = GetDivsInResolvedTreeRoot(resolvedContentNode);

            foreach (var resolvedControl in divs)
            {
                var divClassProperties = resolvedControl.Properties
                    .Where(p => p.Value.Property.Name == "Attributes:class")
                    .Select(p => p.Value)
                    .OfType<ResolvedPropertyBinding>()
                    .ToList();
                result.AddRange(divClassProperties.Select(a => a.Binding.Value));
            }
            propertiesBindings.AddRange(result);
        }

        private static void FillDivDataContextValueBinding(ResolvedContentNode resolvedContentNode,
            ref List<string> propertiesBindings)
        {
            IEnumerable<ResolvedControl> divs = GetDivsInResolvedTreeRoot(resolvedContentNode);
            propertiesBindings.AddRange(divs.Select(
                resolvedControl => resolvedControl.GetValueBindingText(DotvvmBindableObject.DataContextProperty)));
        }

        private static void FillDivValidatorInvalidCssClassValue(ResolvedContentNode resolvedContentNode,
            ref List<string> propertiesBindings)
        {
            IEnumerable<ResolvedControl> divs = GetDivsInResolvedTreeRoot(resolvedContentNode);
            IEnumerable<string> result = divs.Select(
                rs => rs.GetValueOrNull(Validator.InvalidCssClassProperty))
                .Where(rs => rs != null);

            propertiesBindings.AddRange(result);
        }

        private static void FillDivValidatorValueBinding(ResolvedContentNode resolvedContentNode,
            ref List<string> propertiesBindings)
        {
            IEnumerable<ResolvedControl> divs = GetDivsInResolvedTreeRoot(resolvedContentNode);
            IEnumerable<string> result = divs.Select(
                rs => rs.GetValueBindingTextOrNull(Validator.ValueProperty)).
                Where(rs => rs != null);
            propertiesBindings.AddRange(result);
        }

        private static void FillFormValidatorInvalidCssClassValue(ResolvedContentNode resolvedContentNode,
            ref List<string> propertiesBindings)
        {
            IEnumerable<ResolvedControl> forms = GetFormsInResolvedTreeRoot(resolvedContentNode);
            IEnumerable<string> result = forms.Select(
                rs => rs.GetValueOrNull(Validator.InvalidCssClassProperty))
                .Where(rs => rs != null);

            propertiesBindings.AddRange(result);
        }

        private static void FillCheckBoxCheckedItemsBinding(ResolvedContentNode resolvedContentNode,
            ref List<string> propertyBindings)
        {
            propertyBindings.AddRange(resolvedContentNode.GetDescendantControls<CheckBox>()
                .Select(c => c.GetValueBindingText(CheckBox.CheckedItemsProperty)));
        }

        private static void FillRadioButtonCheckedItemBinding(ResolvedContentNode resolvedContentNode,
            ref List<string> propertyBindings)
        {
            propertyBindings.AddRange(resolvedContentNode.GetDescendantControls<RadioButton>()
                .Select(c => c.GetValueBindingText(RadioButton.CheckedItemProperty)));
        }

        private static void FillRepeaterDataSourceBinding(ResolvedContentNode resolvedContentNode,
            ref List<string> propertyBindings)
        {
            propertyBindings.AddRange(resolvedContentNode.GetDescendantControls<Repeater>()
                .Select(c => c.GetValueBindingText(ItemsControl.DataSourceProperty)));
        }

        private static void FillRepeaterLiteralBinding(ResolvedContentNode resolvedContentNode,
            ref List<string> propertiesBindings)
        {
            var repeaterTemplate = GetRepeaterTemplate(resolvedContentNode);
            propertiesBindings.AddRange(repeaterTemplate.GetDescendantControls<Literal>()
                .Select(l => l.GetValueBindingOrNull(Literal.TextProperty))
                .Where(l => l != null).Select(l => l.Binding.Value));
        }

        private static void FillTextBoxTextBinding(ResolvedContentNode resolvedContentNode, ref List<string> propertyBindings)
        {
            propertyBindings.AddRange(resolvedContentNode.GetDescendantControls<TextBox>()
                .Select(c => c.GetValueBindingText(TextBox.TextProperty)));
        }

        private static void FillValidatorShowErrorMessageTextValue(ResolvedContentNode resolvedContentNode,
           ref List<string> propertiesBindings)
        {
            propertiesBindings.AddRange(resolvedContentNode.GetDescendantControls<Validator>()
                  .Select(l => l.GetValueOrNull(Validator.ShowErrorMessageTextProperty))
                  .Where(l => l != null));
        }

        private static void FillValidatorValueBinding(ResolvedContentNode resolvedContentNode,
                   ref List<string> propertiesBindings)
        {
            propertiesBindings.AddRange(resolvedContentNode.GetDescendantControls<Validator>()
                  .Select(l => l.GetValueBindingOrNull(Validator.ValueProperty))
                  .Where(l => l != null).Select(l => l.Binding.Value));
        }

        private static IEnumerable<ResolvedControl> GetDivsInResolvedTreeRoot(ResolvedContentNode resolvedContentNode)
        {
            return resolvedContentNode.GetChildrenControls<HtmlGenericControl>()
                            .Where(d => d.DothtmlNode.As<DothtmlElementNode>()?.TagName == "div").ToList();
        }

        private static IEnumerable<ResolvedControl> GetFormsInResolvedTreeRoot(ResolvedContentNode resolvedContentNode)
        {
            return resolvedContentNode.GetChildrenControls<HtmlGenericControl>()
                            .Where(d => d.DothtmlNode.As<DothtmlElementNode>()?.TagName == "form").ToList();
        }

        private static IEnumerable<string> GetRepeaterDivClassBinding(ResolvedContentNode resolvedContentNode)
        {
            var result = new List<string>();
            var divs = GetDivsInResolvedTreeRoot(resolvedContentNode);

            foreach (var resolvedControl in divs)
            {
                var divClassProperties = resolvedControl.Properties
                    .Where(p => p.Value.Property.Name == "Attributes:class")
                    .Select(p => p.Value)
                    .OfType<ResolvedPropertyBinding>()
                    .ToList();
                result.AddRange(divClassProperties.Select(a => a.Binding.Value));
            }
            return result;
        }
    }
}