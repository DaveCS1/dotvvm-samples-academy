﻿using DotVVM.Framework.ViewModel;
using DotvvmAcademy.Steps.StepsBases.Interfaces;
using DotvvmAcademy.Steps.Validation.Interfaces;

namespace DotvvmAcademy.Steps.StepsBases
{
    public abstract class CodeStepBase<T> : ValidableStepBase, ICodeStep<T>
        where T : ILessonValidationObject
    {
        public string Code { get; set; } = "";

        [Bind(Direction.None)]
        public string FinalCode { get; set; }

        public string ShadowBoxDescription { get; set; }

        [Bind(Direction.None)]
        public string StartupCode { get; set; }

        public abstract T Validator { get; set; }

        public void ResetCode()
        {
            Code = StartupCode;
        }

        public void ShowCorrectCode()
        {
            Code = FinalCode;
        }
    }
}