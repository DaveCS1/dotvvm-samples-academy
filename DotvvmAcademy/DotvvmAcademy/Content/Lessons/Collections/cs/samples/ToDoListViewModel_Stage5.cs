using System;
using System.Collections.Generic;

namespace DotvvmAcademy.Lessons.Collections.ViewModels
{
    public class ToDoListViewModel
    {
        public ToDoListViewModel()
        {
            Tasks = new List<TaskData>();
        }

        public string AddedTaskTitle { get; set; }

        public List<TaskData> Tasks { get; set; }

        public void AddTask()
        {
            //p�idejte do seznamu Tasks nov� �kol a vypl�t� jeho vlastnost `Title` �et�zcem `AddedTaskTitle`

            //p�enastavte vlastnost `AddedTaskTitle` na pr�zdn� �et�zec.
        }
    }
}