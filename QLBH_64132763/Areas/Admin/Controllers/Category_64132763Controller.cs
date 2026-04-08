using model_64132763.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH_64132763.Areas.Admin.Controllers
{
    public class Category_64132763Controller : Base_64132763Controller
    {
        // GET: Admin/Category_64132763
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Category_64132763/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Category_64132763/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category_64132763/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category_64132763/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Category_64132763/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category_64132763/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Category_64132763/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
