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
       
       

        //public int UpUser(Task task)
        //{
        //    DateLoginTask db = new DateLoginTask();
        //    //1.将实体对象加入EF对象容器中，并获取伪包装类对象
        //    Task task = db.Task(task);
        //    DbEntityEntry entry = db.Entry(task);
        //    //2.将包装类对象的状态设置为unchanged
        //    entry.State = System.Data.Entity.EntityState.Unchanged;
        //    //3.设置 被改变的属性
        //    entry.Property(a => a.Name).IsModified = true;
        //    entry.Property(a => a.name).IsModified = true;
        //    //4.提交到数据库
        //    db.SaveChanges();
        //    return db.SaveChanges();
        //}

    }
}
