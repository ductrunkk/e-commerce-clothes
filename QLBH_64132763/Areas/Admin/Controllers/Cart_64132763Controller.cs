using model_64132763.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH_64132763.Areas.Admin.Controllers
{
    public class Cart_64132763Controller : Controller
    {
        // GET: Admin/Cart_64132763
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Revenue()
        {
            var dao = new CartDAO();
            var revenueData = dao.GetRevenueByMonth();
            return View(revenueData);
        }
        public JsonResult GetRevenueChartData()
        {
            var dao = new CartDAO();
            var data = dao.GetRevenueByMonth();
            var chartData = data.Select(r => new
            {
                MonthYear = $"{r.Month}/{r.Year}",
                Revenue = r.TotalRevenue
            }).ToList();

            return Json(chartData, JsonRequestBehavior.AllowGet);
        }
    }
}