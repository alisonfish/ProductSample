using System.Web.Mvc;

namespace ProductSample.ActionFilters
{
    public class ShareDataAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Message = "Your application description page.";

            //if (!filterContext.HttpContext.Request.IsLocal)
            //{
            //    filterContext.Result = new RedirectResult("/");
            //}

            base.OnActionExecuting(filterContext);
        }
    }
}