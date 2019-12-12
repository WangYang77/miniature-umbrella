using HPIT.Survey.Portal.Filters;
using System.Web.Mvc;
using MVC.EF.DAL;
using HPIT.Data.Core;

namespace MVC.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        
        public ActionResult Index()
        {
            return View();
        }
        
        public DeluxeJsonResult QueryPageData(SearchModel<Task> search)
        {
            int total = 0;
            var result =TaskPage.page.GetPageData(search, out total);
            var totalPages = total % search.PageSize == 0 ? total / search.PageSize : total / search.PageSize + 1;
            return new DeluxeJsonResult(new
            {
                Data = result,
                Total = total,
                TotalPages = totalPages
            }, "yyyy-MM- dd HH: mm");
        }

    }
}