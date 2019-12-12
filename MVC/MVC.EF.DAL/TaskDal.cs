using System.Collections.Generic;
using System.Linq;

namespace MVC.EF.DAL
{
    public class TaskDal
    {
        public List<Task> List()
        {
            DateLoginTask db = new DateLoginTask();
            List<Task> task = db.Task.ToList();
            return task;
        }

        public int AddUser(Task task)
        {
            DateLoginTask db = new DateLoginTask();
            db.Task.Add(task);
            return db.SaveChanges();
        }
        public Task GetTaskById(int id)
        {
            DateLoginTask db = new DateLoginTask();
            return db.Task.FirstOrDefault(u => u.TaskID == id);
        }
        public int UpUser(Task task)
        {
            DateLoginTask db = new DateLoginTask();
            db.Entry(task).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int DelUser(int id)
        {
            DateLoginTask db = new DateLoginTask();
            var num = db.Task.Where(x => x.TaskID == id);
            db.Task.Remove(num.ToList()[0]);
            return db.SaveChanges();
        }
        public List<Task> LoginSel(string name,int passward)
        {
            DateLoginTask db = new DateLoginTask();
            var query = db.Task.Where(o => o.name == name && o.passward==passward).ToList();
            //var prod = from u in db.Task
            //           where u.passward.ToString().Contains(passward.ToString())
            //           && u.name.Contains(name)
            //           select u;
                return query;
        }

       

    }
}
