﻿using DotvvmAcademy.Steps.Validation.Interfaces;
using DotvvmAcademy.Steps.Validation.ValidatorProvision;
using DotvvmAcademy.Steps.Validation.Validators.CommonValidators;
using DotvvmAcademy.Steps.Validation.Validators.PropertyAndControlType;
using DotVVM.Framework.Compilation.ControlTree.Resolved;
using DotVVM.Framework.Controls;

namespace DotvvmAcademy.Steps.Validation.Validators.Lesson4
{
    [StepValidation(ValidatorKey = "Lesson4Step4Validator")]
    public class Lesson4Step4Validator : IDotHtmlCodeValidationObject
    {
        public void Validate(ResolvedTreeRoot resolvedTreeRoot)
        {
            Lesson4CommonValidator.ValidateStep3Properties(resolvedTreeRoot);

            var property = new Property("has-error","none",ControlBindName.DivValidatorInvalidCssClass);
            DotHtmlCommonValidator.ValidatePropertyBinding(resolvedTreeRoot,property);


            var invalidCssException = new CodeValidationException("You should add Validator.InvalidCssClass=\"has-error\" on every div element");

            DotHtmlCommonValidator.CheckCountOfHtmlTagWithPropertyDescriptor(resolvedTreeRoot, "div",3, Validator.InvalidCssClassProperty, invalidCssException);


        }
    }
}