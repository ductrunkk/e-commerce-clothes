using QLBH_64132763.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QLBH_64132763.Areas.Admin.Controllers
{
    public class Base_64132763Controller : Controller
    {
        // GET: Admin/Base_64132763
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var sess = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (sess == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new 
                { 
                    Controller = "Login_64132763", Action = "index_64132763", Areas = "Admin" 
                }));
            }
            base.OnActionExecuted(filterContext);
        }
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if(type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if(type == "warning")
            {
                TempData["AlertTyupe"] = "alert-warning";
            }
            else if(type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }

        }
    }
}