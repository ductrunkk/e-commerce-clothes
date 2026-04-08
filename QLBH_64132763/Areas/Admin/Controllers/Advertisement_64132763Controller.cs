using model_64132763.DAO;
using model_64132763.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH_64132763.Areas.Admin.Controllers
{
    public class Advertisement_64132763Controller : Base_64132763Controller
    {
        // GET: Admin/Advertisement_64132763
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new AdvertisementDAO();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;
            return View(model);
        }

        // GET: Admin/Advertisement_64132763/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        

        // GET: Admin/Advertisement_64132763/Create
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        public void SetViewBag(int? selectedID = null)
        {
            var dao = new CategoryDAO();
            ViewBag.ID_CATEGORY = new SelectList(dao.ListAll(), "ID_CATEGORY", "NAME_CATEGORY", selectedID);
        }
        // POST: Admin/Advertisement_64132763/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ADVERTISEMENT model)
        {
            if(ModelState.IsValid)
            {
                 
            }
            SetViewBag();
            return View();
        }


        // GET: Admin/Advertisement_64132763/Edit/5
        public ActionResult Edit(int id)
        {
            var dao = new AdvertisementDAO();
            var advertisement = dao.GetByID(id);

            SetViewBag(advertisement.ID_CATEGORY);
            return View();
        }

        // POST: Admin/Advertisement_64132763/Edit/5
        [HttpPost]
        public ActionResult Edit(ADVERTISEMENT model)
        {
            if (ModelState.IsValid)
            {

            }
            SetViewBag(model.ID_CATEGORY);
            return View();
        }

        // GET: Admin/Advertisement_64132763/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Advertisement_64132763/Delete/5
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
