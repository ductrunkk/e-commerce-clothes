using model_64132763.DAO;
using model_64132763.EF;
using QLBH_64132763.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace QLBH_64132763.Areas.Admin.Controllers
{
    public class User_64132763Controller : Base_64132763Controller
    {
        // GET: Admin/User_64132763
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new UserDAO();
            var model = dao.ListAllPaging(searchString,page, pageSize); // Trả về danh sách rỗng nếu không có dữ liệu
            ViewBag.SearchString = searchString;
            return View(model);
        }

        // GET: Admin/User_64132763/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/User_64132763/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Admin/User_64132763/Create
        [HttpPost]
        public ActionResult Create(USER_ROLE user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var encryptSHA_256Pas = Encryptor.HashPassword(user.PASSWORD_USER);
                user.PASSWORD_USER = encryptSHA_256Pas;
                int id = dao.Insert(user);
                if (id > 0)
                {
                    TempData["AlertMessage"] = "Thêm người dùng thành công!";
                    TempData["AlertType"] = "alert-success";
                    return RedirectToAction("Index", "User_64132763");

                }
                else
                    ModelState.AddModelError("", "Thêm người dùng không thất bại");
            }
            return View("Index");
        }

        // GET: Admin/User_64132763/Edit/5
        public ActionResult Edit(int id)
        {
            var user = new UserDAO().ViewDetail(id);
            return View(user);
        }

        // POST: Admin/User_64132763/Edit/5
        [HttpPost]
        public ActionResult Edit(USER_ROLE user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                if (!string.IsNullOrEmpty(user.PASSWORD_USER))
                {
                    var encryptSHA_256Pas = Encryptor.HashPassword(user.PASSWORD_USER);
                    user.PASSWORD_USER = encryptSHA_256Pas;
                }
                var result = dao.Updated(user);
                if (result)
                {
                    TempData["AlertMessage"] = "Cập nhật người dùng thành công!";
                    TempData["AlertType"] = "alert-success";
                    return RedirectToAction("Index", "User_64132763");
                }
                else
                    ModelState.AddModelError("", "Cập nhật người dùng thất bại");
            }
            return View("Index");
        }

        // DELETE: Admin/User_64132763/Delete/3
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDAO().Delete(id);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var result = new UserDAO().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}
