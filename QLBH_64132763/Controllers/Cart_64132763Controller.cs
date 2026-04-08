using model_64132763.DAO;
using model_64132763.EF;
using QLBH_64132763.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using QLBH_64132763.Common;
using System.IO;
using Common;

namespace QLBH_64132763.Controllers
{
    public class Cart_64132763Controller : Controller
    {
        private const string CartSession = "CartSession";
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem64132763>>(cartModel);
            var sessionCart = (List<CartItem64132763>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID_PRODUCT == item.Product.ID_PRODUCT);
                if (jsonItem != null)
                {
                    item.QUANTITY = jsonItem.QUANTITY;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(int id)
        {
            var sessionCart = (List<CartItem64132763>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.ID_PRODUCT == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        // GET: Cart_64132763
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem64132763>();
            if (cart != null)
            {
                list = (List<CartItem64132763>)cart;

            }
            return View(list);
        }
        public ActionResult AddItem(int ID_PRODUCT, int QUANTITY)
        {
            var product = new ProductDAO().ViewDetail(ID_PRODUCT);
            var cart = Session[CartSession];
            if(cart != null)
            {
                var list = (List<CartItem64132763>)cart;
                if (list.Exists(x => x.Product.ID_PRODUCT == ID_PRODUCT))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID_PRODUCT == ID_PRODUCT)
                        {
                            item.QUANTITY += QUANTITY;
                        }
                    }
                }
                else
                {
                    // Tạo mới đối tượng cart item
                    var item = new CartItem64132763();
                    item.Product = product;
                    item.QUANTITY = QUANTITY;
                    list.Add(item);
                }
                // Gắn vào session 
                Session[CartSession] = list;
            }
            else
            {
                // Tạo mới đối tượng cart item
                var item = new CartItem64132763();
                item.Product = product;
                item.QUANTITY = QUANTITY;
                var list = new List<CartItem64132763>();
                list.Add(item);
                // Gắn vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem64132763>();
            if (cart != null)
            {
                list = (List<CartItem64132763>)cart;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Payment(string SHIP_NAME, string SHIP_MOBILE, string SHIP_ADDRESS, string SHIP_EMAIL)
        {
            var cart = new CART();
            cart.CREATED_DATE = DateTime.Now;
            cart.SHIP_ADDRESS = SHIP_ADDRESS;
            cart.SHIP_MOBILE = SHIP_MOBILE;
            cart.SHIP_NAME = SHIP_NAME;
            cart.SHIP_EMAIL = SHIP_EMAIL;

            try
            {
                var id = new CartDAO().Insert(cart);
                var Cart = (List<CartItem64132763>)Session[CartSession];
                var detailDao = new CartDetailDAO();
                decimal total = 0;
                foreach (var item in Cart)
                {
                    var cartDetail = new CART_DETAIL();
                    cartDetail.ID_PRODUCT = item.Product.ID_PRODUCT;
                    cartDetail.ID_CART = id;
                    cartDetail.PRICE = item.Product.PRICE;
                    cartDetail.QUANTITY = item.QUANTITY;
                    detailDao.Insert(cartDetail);

                    total += (item.Product.PRICE.Value * item.QUANTITY);
                }
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Content/assets/template/newOrder.html"));

                content = content.Replace("{{CustomerName}}", SHIP_NAME);
                content = content.Replace("{{Phone}}", SHIP_MOBILE);
                content = content.Replace("{{Email}}", SHIP_EMAIL);
                content = content.Replace("{{Address}}", SHIP_ADDRESS);
                content = content.Replace("{{Total}}", total.ToString("N0"));
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                new MailHelper().SendMail(SHIP_EMAIL, "New oder from DucTrung64132763", content);
                new MailHelper().SendMail(toEmail, "New oder from DucTrung64132763", content);
            }
            catch (Exception ex)
            {
                //ghi log
                return Redirect("/error-payment");
            }
            return Redirect("/finish");
        }

        public ActionResult Success()
        {
            return View();
        }
        public ActionResult Failture()
        {
            return View();
        }
        

    }
}