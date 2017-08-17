using System;
using System.Collections.Generic;

namespace DotvvmAcademy.Tutorial.ViewModels
{
    public class Lesson2ViewModel
    {
        public string AddedTaskTitle { get; set; }

        public List<TaskData> Tasks { get; set; } = new List<TaskData>();

        public void AddTask()
        {
            Tasks.Add(new TaskData() { Title = AddedTaskTitle });
            AddedTaskTitle = "";
        }

        public void CompleteTask(TaskData task)
        {
            task.IsCompleted = true;
        }
    }
}