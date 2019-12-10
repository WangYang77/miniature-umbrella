using MVC.EF.DAL;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            TaskDal taskDal = new TaskDal();
            List<Task> tasks = taskDal.List();
            return View(tasks);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateModel(Task task)
        {
            TaskDal taskDal = new TaskDal();
            if (taskDal.AddUser(task) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Create");
            }
        }
        public ActionResult Edit(int id)
        {
            TaskDal taskDal = new TaskDal();
            Task task = taskDal.GetTaskById(id);
            return View(task);
        }
        [HttpPost]
        public ActionResult UpModel(Task task)
        {
            TaskDal taskDal = new TaskDal();
            if (taskDal.UpUser(task) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Edit");
            }
        }
        public ActionResult Delete(int id)
        {
            TaskDal taskDal = new TaskDal();
            if (taskDal.DelUser(id) > 0)
            {
                return View("Index", taskDal.List());

            }
            else
            {
                return Content("删除失败");
            }
        }

        public JsonResult JsonResult()
        {
            TaskDal task = new TaskDal();
            List<Task> tasks = task.List();
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            result.Data = tasks;
            return result;
        }
        //[HttpPost]
        //public ActionResult UpModel(Task task)
        //{
        //    try
        //    {
        //        DateLoginTask db = new DateLoginTask();
        //       
        //        if (ModelState != null)
        //        {
        //            
        //            db.Entry(task).State = System.Data.Entity.EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(task);

        //    }
        //    catch (Exception ex)
        //    {
        //        return Content("修改失败" + ex.Message);
        //    }
        //}

    }
}