﻿using System;
using System.Diagnostics;

namespace DotvvmAcademy.CourseFormat
{
    [DebuggerDisplay("StepId: {Path}")]
    public sealed class StepId
    {
        public StepId(LessonId lessonId, string moniker)
        {
            LessonId = lessonId;
            Moniker = moniker;
            Path = $"{lessonId.Path}/{moniker}";
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public LessonId LessonId { get; }

        public string Moniker { get; }

        public string Path { get; }
    }
}