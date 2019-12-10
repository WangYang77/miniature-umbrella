using HPIT.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.EF.DAL
{
    public  class TaskPage
    {
        public static TaskPage page = new TaskPage();
        public Task task { get; set; }

        public TaskPage()
        {
            this.task = new Task();
        }

        public object GetPageData(SearchModel<Task> search, out int count)
        {
            GetPageListParameter<Task, int> parameter = new GetPageListParameter<Task, int>();
            parameter.isAsc = true;
            parameter.orderByLambda = t => t.TaskID;
            parameter.pageIndex = search.PageIndex;
            parameter.pageSize = search.PageSize;
            parameter.whereLambda = t => t.TaskID != 0;
            DateLoginTask indsentes = new DateLoginTask();
            DBBaseService baseService = new DBBaseService(indsentes);
            List<Task> list = baseService.GetSimplePagedData<Task, int>(parameter, out count);
            return list;
        }

    }
}
