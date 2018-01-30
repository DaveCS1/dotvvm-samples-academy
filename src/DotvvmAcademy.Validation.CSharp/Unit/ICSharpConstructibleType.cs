﻿using System.Collections.Generic;

namespace DotvvmAcademy.Validation.CSharp.Unit
{
    /// <summary>
    /// A C# type that can be constructed i.e. a class or a struct.
    /// </summary>
    public interface ICSharpConstructibleType : ICSharpMemberedType, ICSharpObject
    {
        ICSharpClass GetClass(string name, IEnumerable<CSharpGenericParameterDescriptor> genericParameters);

        ICSharpConstructor GetConstructor(IEnumerable<CSharpTypeDescriptor> parameters);

        ICSharpConversionOperator GetConversionOperator(CSharpTypeDescriptor parameterType, CSharpTypeDescriptor returnType);

        ICSharpDelegate GetDelegate(string name, IEnumerable<CSharpGenericParameterDescriptor> genericParameters);

        ICSharpEnum GetEnum(string name);

        ICSharpEvent GetEvent(string name);

        ICSharpField GetField(string name);

        ICSharpInterface GetInterface(string name, IEnumerable<CSharpGenericParameterDescriptor> genericParameters);

        ICSharpMethod GetOperator(string operationName);

        ICSharpStruct GetStruct(string name, IEnumerable<CSharpGenericParameterDescriptor> genericParameters);
    }
}