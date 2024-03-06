using EstellaAppCRUD.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EstellaAppCRUD.Controllers
{
    // Set filter to this controller (must login)
    [Authorize(Roles = "User, Manager")]
    public class HomeController : BaseController
    {
        // GET: HOme
        public ActionResult Index()
        {
            List<User> userList = _userRepo.GetAll();

            return View(userList);
        }
        
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index");
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        // Not set to allow anonymouse during POST submit
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(User u)
        {
            var user = _userRepo.GetAll().FirstOrDefault(m => m.userName == u.userName);
            if (user != null && user.passWord == u.passWord)
            {
                // User is correct userName and passWord
                FormsAuthentication.SetAuthCookie(u.userName, false);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "User not Exist or Incorrect Password");

            return View(u);
        }

        [Authorize(Roles = "Manager")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User u)
        {
            _userRepo.Create(u);
            TempData["Msg"] = $"User {u.userName } has been Added!";

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(_userRepo.Get(id));
        }

        [Authorize(Roles = "Manager")]
        public ActionResult Edit(int id)
        {
            return View(_userRepo.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(User u)
        {
            _userRepo.Update(u.id, u);
            TempData["Msg"] = $"User {u.userName} has been Updated!";

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Manager")]
        public ActionResult Delete(int id)
        {
            var userToDelete = _userRepo.Get(id);
            _userRepo.Delete(id);
            TempData["Msg"] = $"User {userToDelete.userName} has been Deleted!";

            return RedirectToAction("Index");
        }
    }
}