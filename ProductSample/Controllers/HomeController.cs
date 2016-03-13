using ProductSample.ActionFilters;
using System;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace ProductSample.Controllers
{
    [ActionTime]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ShareData]
        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //指定不同的ExceptionType顯示不同的View
        [HandleError(ExceptionType = typeof(ArgumentException), View ="ErrorArgument")]
        [HandleError(ExceptionType = typeof(SqlException), View = "ErrorSQL")]
        public ActionResult ErrorTest(string errorType)
        {
            if (errorType == "1")
            {
                throw new Exception("Error 1");
            }

            if (errorType == "2")
            {
                throw new ArgumentException("Error 2");
            }

            return Content("No Error");
        }
    }
}