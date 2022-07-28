using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ToDoWebApp.Models;

namespace ToDoWebApp.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext() : base("TodoContext") { }
        public DbSet<TaskItem> TaskItems { get;set;}
    }
}