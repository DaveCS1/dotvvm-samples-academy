﻿using DotVVM.Framework.Compilation.ControlTree.Resolved;
using DotVVM.Framework.Controls;
using DotvvmAcademy.Steps.Validation.Interfaces;
using DotvvmAcademy.Steps.Validation.ValidatorProvision;
using DotvvmAcademy.Steps.Validation.Validators.CommonValidators;
using DotvvmAcademy.Steps.Validation.Validators.PropertyAndControlType;

namespace DotvvmAcademy.Steps.Validation.Validators.Lesson4
{
    [StepValidation(ValidatorKey = "Lesson4Step4Validator")]
    public class Lesson4Step4Validator : IDotHtmlCodeValidationObject
    {
        public void Validate(ResolvedTreeRoot resolvedTreeRoot)
        {
            DotHtmlCommonValidator.CheckCountOfHtmlTag(resolvedTreeRoot, "div", 3);
            Lesson4CommonValidator.ValidateStep2ValidationProperties(resolvedTreeRoot);
            Lesson4CommonValidator.ValidateOnlyStep3Properties(resolvedTreeRoot);

            var property = new Property("has-error", "none", ControlBindName.DivValidatorInvalidCssClass);
            DotHtmlCommonValidator.ValidatePropertyBinding(resolvedTreeRoot, property);

            var invalidCssException = new CodeValidationException(Lesson4Texts.AllDivsMustHaveInvalidCssClass);
            DotHtmlCommonValidator.CheckCountOfHtmlTagWithPropertyDescriptor(resolvedTreeRoot, "div", 3, Validator.InvalidCssClassProperty, invalidCssException);
        }
    }
}