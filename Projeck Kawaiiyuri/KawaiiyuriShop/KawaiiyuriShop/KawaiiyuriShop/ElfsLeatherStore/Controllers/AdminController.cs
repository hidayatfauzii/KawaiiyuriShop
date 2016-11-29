using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ElfsLeatherStore.ViewModels;

namespace ElfsLeatherStore.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult ShowAllUser()
        {
            List<UserViewModel> lstUser = new List<UserViewModel>();
            foreach (var user in UserManager.Users)
            {
                lstUser.Add(new UserViewModel
                {
                    UserId = user.Id,
                    Email = user.Email,
                    Username = user.UserName
                });
            }
            return View(lstUser);
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(string username)
        {
            var userName = UserManager.FindByName(username);
            if (userName.UserName != null)
            {
                UserViewModel model = new UserViewModel
                {
                    Username = userName.UserName
                };
                return View(model);
            }
            return RedirectToAction("ShowAllUser");
        }

        [HttpPost]
        public ActionResult Edit(string Username, string OldPassword, string NewPassword)
        {
            var user = UserManager.FindByName(Username);
            var status = UserManager.ChangePassword(user.Id, OldPassword, NewPassword);
            if (status.Succeeded)
            {
                ViewBag.Pesan =
                    "<div class='alert alert-success'>Password berhasil diubah.</div>";
            }
            else
            {
                ViewBag.Pesan =
                    "<div class='alert alert-warning'>Gagal ubah password.</div>";
            }
            var model = new UserViewModel
            {
                Username = Username,
                OldPassword = OldPassword,
                NewPassword = NewPassword
            };
            return View(model);
        }

        public ActionResult Delete(string username)
        {
            var userName = UserManager.FindByName(username);
            if (userName.UserName != null)
            {
                var result = UserManager.Delete(userName);
            }
            return RedirectToAction("ShowAllUser");
        }
    }
}
