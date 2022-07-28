using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoWebApp.Models
{
    public class TaskItem
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}