using CNPMNC_BANHANG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CNPMNC_BANHANG.Controllers
{
    public class AuthenticationController : Controller
    {
        BANHANGDBDataContext data = new BANHANGDBDataContext();

        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                var user = collection["username"];
                var pass = collection["password"];
                if (String.IsNullOrEmpty(user))
                    ViewData["Loi1"] = "Phải nhập tên đăng nhập";
                if (String.IsNullOrEmpty(pass))
                    ViewData["Loi2"] = "Phải nhập mật khẩu";
                if (!String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(pass))
                {
                    ADMIN ad = data.ADMINs.SingleOrDefault(n => n.useradmin == user && n.passadmin == pass);
                    if (ad != null)
                    {
                        FormsAuthentication.SetAuthCookie(ad.hoten, false);
                        Session["Admin"] = ad;
                        return RedirectToAction("Index", "Admin");
                       
                    }
                    else
                    {
                        ModelState.AddModelError("CredentialError", "Tên đăng nhập hoặc mật khẩu không đúng");
                        return View();
                        //ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                    }
                }
            }
            return View();

        }
        public ActionResult Logout()
        {
            Session["Admin"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}