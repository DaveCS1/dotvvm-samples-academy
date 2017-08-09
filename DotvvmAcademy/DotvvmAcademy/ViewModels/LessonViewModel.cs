using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;
using DotvvmAcademy.BL.DTO;
using DotvvmAcademy.BL.Facades;
using DotvvmAcademy.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotvvmAcademy.ViewModels
{
    public class LessonViewModel : DotvvmAcademyViewModelBase
    {
        private LessonFacade lessonFacade;
        private StepFacade stepFacade;

        public LessonViewModel(LessonFacade lessonFacade, StepFacade stepFacade)
        {
            this.lessonFacade = lessonFacade;
            this.stepFacade = stepFacade;
        }

        public bool ContinueButtonVisible { get; set; } = true;

        public bool IsValid { get; set; } = true;

        public int LessonStepCount { get; private set; }

        public int LessonIndex { get; private set; }

        public string Language { get; set; } = "en";

        [Bind(Direction.None)]
        public StepDTO Step { get; set; }

        public int StepIndex { get; private set; }

        public List<SampleDTO> Samples { get; set; } = new List<SampleDTO>();

        public void Continue()
        {
            var storage = new LessonProgressStorage(Context.GetAspNetCoreContext());

            if (IsValid)
            {
                if (StepIndex < LessonStepCount - 1)
                {
                    storage.UpdateLessonLastStep(LessonIndex + 1, StepIndex + 2);
                    RedirectToNextLesson();
                }
                else
                {
                    storage.UpdateLessonLastStep(LessonIndex + 1, LessonProgressStorage.FinishedLessonStepNumber);
                    Context.RedirectToRoute("Default");
                }
            }
        }

        public override Task Init()
        {
            LessonIndex = Convert.ToInt32(Context.Parameters["Lesson"]) - 1;
            StepIndex = Convert.ToInt32(Context.Parameters["Step"]) - 1;
            Step = stepFacade.GetStep(LessonIndex, Language, StepIndex);
            LessonStepCount = lessonFacade.GetLessonStepCount(LessonIndex, Language);

            AfterLoad();

            return base.Init();
        }

        protected virtual void AfterLoad()
        {
        }

        protected virtual void RedirectToNextLesson()
        {
            Context.RedirectToRoute("Lesson", new { Step = StepIndex + 2 });
        }
    }
}