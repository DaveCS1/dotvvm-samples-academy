﻿using System.Collections.Immutable;

namespace DotvvmAcademy.CourseFormat
{
    public interface ILesson
    {
        string Annotation { get; }

        LessonId Id { get; }

        ImmutableArray<StepId> Steps { get; }
    }
}