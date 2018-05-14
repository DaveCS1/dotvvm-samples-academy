﻿using System.Collections.Immutable;

namespace DotvvmAcademy.CourseFormat
{
    internal class Lesson : ILesson
    {
        public Lesson(LessonId id)
        {
            Id = id;
        }

        public string Annotation { get; set; }

        public LessonId Id { get; }

        public ImmutableDictionary<string, StepId> Steps { get; set; }
    }
}