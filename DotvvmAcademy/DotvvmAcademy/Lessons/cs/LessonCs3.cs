﻿using DotvvmAcademy.Services;
using Microsoft.AspNetCore.Hosting;

namespace DotvvmAcademy.Lessons
{
    public class LessonCs3 : LessonBase
    {
        public LessonCs3(IHostingEnvironment hostingEnvironment)
        {
            var XmlRelativePath = @"Lessons/cs/Lesson3.xml";
            var lessonProvider = new LessonUserInterfaceProvider(XmlRelativePath, hostingEnvironment);
            Steps = lessonProvider.LessonSteps;
        }
    }
}