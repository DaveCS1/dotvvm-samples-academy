﻿using DotvvmAcademy.Validation.Dothtml.ValidationTree;
using DotvvmAcademy.Validation.Unit;
using System;
using System.Collections.Immutable;

namespace DotvvmAcademy.Validation.Dothtml.Unit
{
    public class DothtmlQueryConstraint<TResult> : IConstraint
        where TResult : ValidationTreeNode
    {
        private readonly Action<ConstraintContext, ImmutableArray<TResult>> action;
        private readonly bool overwrite;
        private readonly DothtmlQuery<TResult> query;

        public DothtmlQueryConstraint(
            Action<ConstraintContext, ImmutableArray<TResult>> action,
            DothtmlQuery<TResult> query,
            bool overwrite)
        {
            this.action = action;
            this.query = query;
            this.overwrite = overwrite;
        }

        public bool CanOverwrite(IConstraint other)
        {
            return overwrite
                && other is DothtmlQueryConstraint<TResult> otherConstraint
                && action.Method.Equals(otherConstraint.action.Method)
                && query.XPath.Expression.Equals(otherConstraint.query.XPath.Expression.ToString());
        }

        public int GetOverwriteHashCode()
        {
            return query.XPath.Expression.GetHashCode();
        }

        public void Validate(ConstraintContext context)
        {
            var result = context.Locate<TResult>(query.XPath);
            action(context, result);
        }
    }
}