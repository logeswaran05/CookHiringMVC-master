using CookHiring.Data;
using CookHiring.UI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookHiring.UI.Controllers
{
    public class AdminController : Controller
    {
        public UserRepository userRepository;
        public AdminController()
        {
            userRepository = new UserRepository();
        }
        // GET: Admin
      
        public ActionResult DashBoard()
        {
            var users= userRepository.GetUsers(); 

            return View(users);
        }
        public ActionResult AddUser(User data)
        {
            userRepository.AddUser(data);
            return RedirectToAction("DashBoard");
        }
        public ActionResult Details(int id)
        {
            User user = userRepository.GetUserById(id);
            return View(user);
        }
        public ActionResult Edit(int id)
        {
            User user = userRepository.GetUserById(id);
            return View(user);
        }
        [HttpPut]
        public ActionResult Edit(User data)
        {
            userRepository.EditUser(data);
            return RedirectToAction("DashBoard");
        }

        public ActionResult Delete(int id)
        {
            userRepository.DeleteUser(id);
            return RedirectToAction("DashBoard");
        }

    }
}