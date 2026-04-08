using model_64132763.DAO;
using QLBH_64132763.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static QLBH_64132763.Common.CommonConstants;

namespace QLBH_64132763.Controllers
{
    public class Home_64132763Controller : Controller
    {
        public ActionResult Index()
        {
            var productDAO = new ProductDAO();
            ViewBag.NewProduct = productDAO.ListNewProduct(5);
            ViewBag.ListHotProducts = productDAO.ListHotProduct(10);
            return View();
        }
        
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDAO().ListByGroupID("main");
            
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            var model = new MenuDAO().ListByGroupID("top");

            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[Common.CommonConstants.CartSession];
            var list = new List<CartItem64132763>();
            if (cart != null)
            {
                list = (List<CartItem64132763>)cart;

            }

            return PartialView(list);
        }
        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new MenuDAO().ListByGroupID("footer");

            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult Menu_ProductCategory()
        {
            var model = new ProductCategoryDAO().ListAll();

            return PartialView(model);
        }

    }
}