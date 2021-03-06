﻿using System;
using DotVVM.Framework.Compilation.ControlTree;
using DotVVM.Framework.Compilation.ControlTree.Resolved;
using DotVVM.Framework.Compilation.Parser.Dothtml.Parser;
using DotVVM.Framework.Compilation.Parser.Dothtml.Tokenizer;
using DotVVM.Framework.Configuration;
using DotvvmAcademy.Steps.StepsBases;
using DotvvmAcademy.Steps.Validation;
using DotvvmAcademy.Steps.Validation.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace DotvvmAcademy.Steps
{
    public class CodeStepDotHtml : CodeStepBase<IDotHtmlCodeValidationObject>
    {
        public override IDotHtmlCodeValidationObject Validator { get; set; }

        protected override IEnumerable<string> GetValidationErrors()
        {
            try
            {
                ResolvedTreeRoot root;
                try
                {
                    var tokenizer = new DothtmlTokenizer();
                    tokenizer.Tokenize(Code);
                    var parser = new DothtmlParser();
                    var node = parser.Parse(tokenizer.Tokens);
                    var configuration = DotvvmConfiguration.CreateDefault();
                    var resolver = configuration.ServiceProvider.GetService<IControlTreeResolver>();

                    root = (ResolvedTreeRoot)resolver.ResolveTree(node, Guid.NewGuid() + ".dothtml");
                }
                catch (Exception ex)
                {
                    throw new CodeValidationException("Syntax error in the DOTHTML code.", ex);
                }
                Validator.Validate(root);

                return Enumerable.Empty<string>();
            }
            catch (CodeValidationException ex)
            {
                return new[] { ex.Message };
            }
        }
    }
}