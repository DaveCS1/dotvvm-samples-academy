﻿using System;
using System.Collections.Immutable;

namespace DotvvmAcademy.Validation.CSharp.Unit
{
    public interface ICSharpObjectFactory
    {
        IServiceProvider Provider { get; }

        ImmutableDictionary<string, ICSharpObject> GetAllObjects();

        ICSharpDocument GetDocument();

        TCSharpObject GetObject<TCSharpObject>(string fullName)
            where TCSharpObject : ICSharpObject;

        void RemoveObject<TCSharpObject>(TCSharpObject csharpObject)
            where TCSharpObject : ICSharpObject;
    }
}