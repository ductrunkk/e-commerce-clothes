using model_64132763.DAO;
using model_64132763.EF;
using QLBH_64132763.Areas.Admin.Models;
using QLBH_64132763.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH_64132763.Areas.Admin.Controllers
{
    public class Login_64132763Controller : Controller
    {
        // GET: Admin/Login_64132763
        public ActionResult index_64132763()
        {
            return View();
        }
        public ActionResult login_64132763(LoginModel_64132763 model)
        {
            if (ModelState.IsValid) 
            {
                var dao = new UserDAO();
                var result = dao.Login(model.UserName, Encryptor.HashPassword(model.Password));
                
                if (result == 1)
                {
                    var user = dao.GetByID(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.NAME_USER;
                    userSession.UserID = user.ID_USER;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home_64132763");
                }
                else if (result == 0)
                    ModelState.AddModelError("", "Tài khoản không tồn tại");                
                else if (result == -1)
                    ModelState.AddModelError("", "Tài khoản đang bị khóa");
                else if (result == -2)
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                else
                    ModelState.AddModelError("", "Đăng nhập không đúng.");
                
            }
            return View("index_64132763");
        }
    }
}