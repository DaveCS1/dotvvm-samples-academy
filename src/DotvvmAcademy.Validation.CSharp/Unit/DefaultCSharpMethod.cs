﻿using DotvvmAcademy.Validation.CSharp.Unit.Abstractions;

namespace DotvvmAcademy.Validation.CSharp.Unit
{
    public class DefaultCSharpMethod : DefaultCSharpObject, ICSharpMethod
    {
        public DefaultCSharpMethod(ICSharpNameStack nameStack) : base(nameStack)
        {
        }

        public CSharpAccessModifier AccessModifier { get; set; }

        public bool IsAbstract { get; set; }

        public bool IsAsync { get; set; }

        public bool IsOverriding { get; set; }

        public bool IsStatic { get; set; }

        public bool IsVirtual { get; set; }

        public CSharpTypeDescriptor ReturnType { get; set; }
    }
}