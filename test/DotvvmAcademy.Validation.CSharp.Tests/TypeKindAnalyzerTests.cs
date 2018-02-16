﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotvvmAcademy.Validation.CSharp.Tests
{
    [TestClass]
    public class TypeKindAnalyzerTests : AnalyzerTestBase
    {
        public const string Sample = @"
public class SampleClass
{
}

public struct SampleStruct
{
}

public enum SampleEnum
{
One
}

public delegate void SampleDelegate();";

        [TestMethod]
        public async Task BasicTypeKingAnalyzerTest()
        {
            var sampleClass = MetadataName.CreateTypeName("", "SampleClass");
            var sampleStruct = MetadataName.CreateTypeName("", "SampleStruct");
            var sampleEnum = MetadataName.CreateTypeName("", "SampleEnum");
            var sampleDelegate = MetadataName.CreateTypeName("", "SampleDelegate");

            var metadata = new MetadataCollection();
            metadata[sampleClass, TypeKindAnalyzer.MetadataKey] = DesiredTypeKind.Class;
            metadata[sampleStruct, TypeKindAnalyzer.MetadataKey] = DesiredTypeKind.Class | DesiredTypeKind.Struct;
            metadata[sampleEnum, TypeKindAnalyzer.MetadataKey] = DesiredTypeKind.Array | DesiredTypeKind.Pointer;

            var compilation = GetCompilation(Sample);
            var nameProvider = new RoslynMetadataNameProvider();
            var locator = new SymbolLocator(compilation, nameProvider);
            var analyzer = new TypeKindAnalyzer(metadata, locator);

            var result = await TestAnalyzer(compilation, analyzer);
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(result[0].Id, "TEMP07");
        }
    }
}