using DotVVM.Framework.Compilation.ControlTree.Resolved;
using DotvvmAcademy.Steps.Validation.Interfaces;
using DotvvmAcademy.Steps.Validation.ValidatorProvision;

namespace DotvvmAcademy.Steps.Validation.Validators.Lesson1
{
    [StepValidation(ValidatorKey = "Lesson1Step6Validator")]
    public class Lesson1Step6Validator : IDotHtmlCodeValidationObject
    {
        public void Validate(ResolvedTreeRoot resolvedTreeRoot)
        {
            Lesson1CommonValidator.ValidateTextBoxBindings(resolvedTreeRoot);
        }
    }
}