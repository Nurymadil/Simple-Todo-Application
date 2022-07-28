using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoWebApp.Models;

namespace ToDoWebApp.ViewModels
{
    public class TaskViewModel
    {
        public TaskItem CreateTaskItem { get;set;}
        public List<TaskItem> TaskItems { get;set;}
    }
}