using System.Web.Mvc;

namespace ToDoDotNet.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnException(System.Web.Mvc.ExceptionContext filterContext)
        {
            NLog.LogManager.GetCurrentClassLogger().Error(filterContext.Exception, filterContext.Exception.Message);
            filterContext.ExceptionHandled = true;
            filterContext.Result = this.View("Error");
        }
    }
}