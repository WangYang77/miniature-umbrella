using MVC.EF.DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult LoginIn(string name, int pwd)
        {
            TaskDal dal = new TaskDal();
            List<Task> tasks = dal.LoginSel(name, pwd);
            JsonResult jsonResult = new JsonResult();
            if (tasks != null && tasks.Count >= 1)
            {
                string json = JsonConvert.SerializeObject(tasks.FirstOrDefault());
                HttpCookie cookie = new HttpCookie("Login", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(json)));
                Response.Cookies.Add(cookie);
                jsonResult.Data = new { data = json, state = "200" };
                jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return jsonResult;
            }
            else
            {
                jsonResult.Data = new { data = "未找到用户！", state = "403" };
                return jsonResult;
            }
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOff()
        {
            Request.Cookies.Clear();
            Response.Cookies.Clear();
            return View("Login");
        }

    }
}