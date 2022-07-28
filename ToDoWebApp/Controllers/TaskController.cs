using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToDoWebApp.Data;
using ToDoWebApp.Models;
using ToDoWebApp.ViewModels;

namespace ToDoWebApp.Controllers
{
    public class TaskController : Controller
    {
        private TodoContext db = new TodoContext();

        public async Task<ActionResult> Index()
        {
            var taskViewModel = new TaskViewModel();
            taskViewModel.TaskItems = await db.TaskItems.ToListAsync();

            return View(taskViewModel);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TaskViewModel taskItem)
        {
            if (ModelState.IsValid)
            {
                db.TaskItems.Add(taskItem.CreateTaskItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(taskItem);
        }
        public async Task<ActionResult> Finished(int id)
        {
            var entity = await db.TaskItems.FindAsync(id);
            if (entity == null) return HttpNotFound();
            entity.IsCompleted = !entity.IsCompleted;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await db.TaskItems.FindAsync(id);
            if (entity == null) return HttpNotFound();
            db.TaskItems.Remove(entity);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<JsonResult> Edit(int id,string title)
        {
            if(string.IsNullOrWhiteSpace(title))return Json(false);
            var entity = await db.TaskItems.FindAsync(id);
            if (entity == null) return Json(false);
            entity.Title=title;
            await db.SaveChangesAsync();
            return Json(true);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
