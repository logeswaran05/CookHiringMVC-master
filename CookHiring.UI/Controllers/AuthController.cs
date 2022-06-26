using CookHiring.Data;
using CookHiring.UI.Models;
using CookHiring.UI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookHiring.UI.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public AuthRepository authRepository;
        public AuthController()
        {
            authRepository = new AuthRepository();
        }
        public ActionResult Login()
        {
            return View();
        }
            [HttpGet]
        public ActionResult Login(LoginModel data)
        {
            User userData = authRepository.Login(data);
            if (userData != null)
                return RedirectToAction("Login");
            else
                return View();
        }
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User data)
        {
            if (data == null)
                return View();
            else
            {
                authRepository.Signup(data);
                return View();
            }
                
        }
    }
}