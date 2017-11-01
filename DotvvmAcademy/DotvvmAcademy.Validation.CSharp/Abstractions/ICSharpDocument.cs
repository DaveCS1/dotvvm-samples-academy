﻿namespace DotvvmAcademy.Validation.CSharp.Abstractions
{
    /// <summary>
    /// A C# document.
    /// </summary>
    public interface ICSharpDocument
    {
        ICSharpNamespace GetGlobalNamespace();

        ICSharpNamespace GetNamespace(string name);

        void Remove<TCSharpObject>(TCSharpObject csharpObject)
            where TCSharpObject : ICSharpObject;
    }
}