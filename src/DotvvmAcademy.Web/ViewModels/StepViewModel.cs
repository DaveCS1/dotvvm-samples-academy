﻿using DotVVM.Framework.ViewModel;
using DotvvmAcademy.CourseFormat;
using DotvvmAcademy.Validation.Unit;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace DotvvmAcademy.Web.ViewModels
{
    public class StepViewModel : SiteViewModel
    {
        private readonly StepRenderer stepRenderer;
        private readonly CodeTaskValidator validator;
        private readonly CourseWorkspace workspace;
        private Lesson lesson;
        private RenderedStep renderedStep;
        private Step step;

        public StepViewModel(CourseWorkspace workspace, CodeTaskValidator validator, StepRenderer stepRenderer)
        {
            this.workspace = workspace;
            this.validator = validator;
            this.stepRenderer = stepRenderer;
        }

        public string Code { get; set; }

        [Bind(Direction.None)]
        public string CodeLanguage { get; set; }

        [Bind(Direction.ServerToClient)]
        public List<CodeTaskDiagnostic> Diagnostics { get; set; }

        [Bind(Direction.ServerToClient)]
        public bool HasCodeTask { get; set; }

        [Bind(Direction.None)]
        public bool IsNextVisible { get; set; }

        [Bind(Direction.None)]
        public bool IsPreviousVisible { get; set; }

        [FromRoute("Lesson")]
        public string Lesson { get; set; }

        [Bind(Direction.ServerToClient)]
        public string NextStep { get; set; }

        [Bind(Direction.ServerToClient)]
        public string PreviousStep { get; set; }

        [FromRoute("Step"), Bind(Direction.None)]
        public string Step { get; set; }

        [Bind(Direction.None)]
        public string Text { get; set; }

        public override async Task Load()
        {
            lesson = await workspace.LoadLesson(Language, Lesson);
            step = await workspace.LoadStep(Language, Lesson, Step);
            renderedStep = stepRenderer.Render(step);
            SetButtonProperties();
            Text = renderedStep.Html;
            await base.Load();
        }

        public async Task Validate()
        {
            var unit = await validator.GetUnit(renderedStep.CodeTaskPath);
            Diagnostics = (await validator.Validate(unit, Code)).ToList();
        }

        protected override async Task<IEnumerable<string>> GetAvailableLanguages()
        {
            var root = await workspace.LoadRoot();
            var builder = ImmutableArray.CreateBuilder<string>();
            foreach (var variant in root.Variants)
            {
                var step = await workspace.LoadStep(variant, Lesson, Step);
                if (step != null)
                {
                    builder.Add(variant);
                }
            }
            return builder.ToImmutable();
        }

        private void SetButtonProperties()
        {
            var index = lesson.Steps.IndexOf(Step);
            IsPreviousVisible = index > 0;
            IsNextVisible = index < lesson.Steps.Length - 1;
            if (IsPreviousVisible)
            {
                PreviousStep = lesson.Steps[index - 1];
            }
            if (IsNextVisible)
            {
                NextStep = lesson.Steps[index + 1];
            }
        }

        private async Task SetEditorProperties()
        {
            HasCodeTask = renderedStep.CodeTaskPath != null;
            if (!Context.IsPostBack && HasCodeTask)
            {
                var unit = await validator.GetUnit(renderedStep.CodeTaskPath);
                var defaultCodeResource = await workspace.Load<Resource>(unit.GetDefaultCodePath());
                Code = defaultCodeResource?.Text;
                CodeLanguage = renderedStep.CodeTaskLanguage;
            }
        }
    }
}