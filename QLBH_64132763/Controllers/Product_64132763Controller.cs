using model_64132763.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH_64132763.Controllers
{
    public class Product_64132763Controller : Controller
    {
        // GET: Product_64132763
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CateSidebar()
        {
            var model = new ProductCategoryDAO().ListAll();

            return View(model);
        }
        public ActionResult Category(int ID, int page = 1, int pageSize = 2)
        {
            var cate = new CategoryDAO().ViewDetail(ID);
            ViewBag.Category = cate;

            int totalRecord = 0;
            var model = new ProductDAO().ListByCategoryID(ID,ref totalRecord,page,pageSize);
            
            ViewBag.Total = totalRecord;
            ViewBag.page = page;

            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)totalRecord / pageSize);

            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = maxPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }
        public ActionResult Detail(int ID)
        {
            var product = new ProductDAO().ViewDetail(ID);
            ViewBag.Category = new ProductCategoryDAO().ViewDetail(product.ID_CATEGORY.Value);
            return View(product);
        }
        public ActionResult Search(string keyword, int page = 1, int pageSize = 1)
        {
            int totalRecord = 0;
            var model = new ProductDAO().Search(keyword, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.Keyword = keyword;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }
        public JsonResult ListName(string q)
        {
            var data = new ProductDAO().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}