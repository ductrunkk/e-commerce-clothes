using model_64132763.DAO;
using QLBH_64132763.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBH_64132763.Models;
using model_64132763.EF;
using BotDetect.Web.Mvc;

namespace QLBH_64132763.Controllers
{
    public class User_64132763Controller : Controller
    {
        // GET: User_64132763
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [CaptchaValidationActionFilter("CaptchaCode", "registerCapcha", "Wrong Captcha!")]
        public ActionResult Register(RegisterModel64132763 model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                if (dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Username already exists");
                }
                else if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email already exists");
                }
                else
                {
                    var user = new USER_ROLE();
                    user.NAME_USER = model.UserName;
                    user.PASSWORD_USER = Encryptor.HashPassword(model.Password);
                    user.LAST_NAME = model.LastName;
                    user.FIRST_NAME = model.FirstName;
                    user.PHONE = model.Phone;
                    user.EMAIL = model.Email;
                    user.ADDRESS_CUSTOMER = model.Address;
                    user.CREATED_DATE = DateTime.Now;
                    user.STATUS_SLIDE = true;

                    var result = dao.Insert(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new RegisterModel64132763();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công.");
                    }
                }
            }
            return View(model);
        }
    
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel64132763 model)
        {
            if (ModelState.IsValid) // If the model state is valid
            {
                var dao = new UserDAO(); // Create a UserDao object
                var result = dao.Login(model.UserName, Encryptor.HashPassword(model.Password)); // Call the login method with the username and MD5-hashed password
                if (result == 1) // If the result is 1 (login successful)
                {
                    var user = dao.GetByID(model.UserName); // Retrieve user information based on the username
                    var userSession = new UserLogin(); // Create a user session object
                    userSession.UserName = user.NAME_USER; // Assign the username to the session
                    userSession.UserID = user.ID_USER; // Assign the user ID to the session
                    Session.Add(CommonConstants.USER_SESSION, userSession); // Add the user session to the Session
                    return Redirect("/"); // Redirect to the homepage
                }
                else if (result == 0) // If the result is 0 (account does not exist)
                {
                    ModelState.AddModelError("", "The account does not exist.");
                }
                else if (result == -1) // If the result is -1 (account is locked)
                {
                    ModelState.AddModelError("", "The account is locked.");
                }
                else if (result == -2) // If the result is -2 (incorrect password)
                {
                    ModelState.AddModelError("", "The password is incorrect.");
                }
                else // Other cases (login failed)
                {
                    ModelState.AddModelError("", "Login failed.");
                }
            }
            return View(model); // Return the view with the current model

        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }

    }
}