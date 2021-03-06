﻿using DotVVM.Framework.Compilation.ControlTree.Resolved;
using DotvvmAcademy.Steps.Validation.Interfaces;
using DotvvmAcademy.Steps.Validation.ValidatorProvision;

namespace DotvvmAcademy.Steps.Validation.Validators.Lesson2
{
    [StepValidation(ValidatorKey = "Lesson2Step2Validator")]
    public class Lesson2Step2Validator : IDotHtmlCodeValidationObject
    {
        public void Validate(ResolvedTreeRoot resolvedTreeRoot)
        {
            Lesson2CommonValidator.ValidateAddTaskControls(resolvedTreeRoot);
        }
    }
}