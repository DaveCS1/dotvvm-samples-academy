﻿using DotVVM.Framework.Compilation.ControlTree.Resolved;

namespace DotvvmAcademy.Steps.Validation.Interfaces
{
    public interface IDotHtmlCodeStepValidationObject : ILessonValidationObject
    {
        void Validate(ResolvedTreeRoot resolvedTreeRoot);
    }
}