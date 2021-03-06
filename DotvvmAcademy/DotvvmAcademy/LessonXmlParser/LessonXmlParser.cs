﻿using System;
using DotvvmAcademy.Steps.StepBuilder;
using DotvvmAcademy.Steps.StepsBases.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace DotvvmAcademy.LessonXmlParser
{
    /// <summary>
    ///     Parser for creating lesson.
    /// </summary>
    public class LessonXmlParser
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public LessonXmlParser(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        ///     Parse xml file to steps.
        /// </summary>
        /// <param name="lessonXmlRelativePath"> Relative path to lesson xml file. </param>
        /// <returns> Collection of parsed steps for current lesson. </returns>
        public List<IStep> ParseXmlToSteps(string lessonXmlRelativePath)
        {
            var xmlFileAbsolutePath = GetXmlTextAbsolutePath(lessonXmlRelativePath);
            var xmlText = GetTextFromXml(xmlFileAbsolutePath);
            var rootElement = CreateXElementFromText(xmlText);
            var stepChildCollection = rootElement.GetChildCollection(LessonXmlElements.StepsElement,
                LessonXmlElements.StepElement);
            return CreateSteps(stepChildCollection);
        }

        private static List<IStep> CreateSteps(IEnumerable<XElement> stepChildCollection)
        {
            var result = new List<IStep>();
            var iterator = 1;
            foreach (var stepElement in stepChildCollection)
            {
                var stepBuilder = new StepBuilder();
                var step = stepBuilder.CreateStep(stepElement, iterator);
                result.Add(step);
                iterator++;
            }
            return result;
        }

        private static XElement CreateXElementFromText(string xmlText)
        {
            try
            {
                return XElement.Parse(xmlText);
            }
            catch (Exception)
            {
                //todo UI Exception
                throw;
            }
        }

        private static string GetTextFromXml(string absolutePath)
        {
            try
            {
                var result = File.ReadAllText(absolutePath);
                return result;
            }
            catch (Exception)
            {
                //todo UI Exception
                throw;
            }
        }

        private string GetXmlTextAbsolutePath(string lessonXmlRelativePath)
        {
            return Path.Combine(hostingEnvironment.ContentRootPath, lessonXmlRelativePath);
        }
    }
}