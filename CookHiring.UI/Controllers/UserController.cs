using CookHiring.Data;
using CookHiring.UI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookHiring.UI.Controllers
{
    
    public class UserController : Controller
    {
        // GET: User
        public UserRepository userRepository;
        public UserController()
        {
            userRepository = new UserRepository();
        }


        public ActionResult Index()
        {
            List<User> users = userRepository.GetUsers();
            return View(users);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            userRepository.AddUser(user);
            return RedirectToAction("Index");
            }
        public ActionResult Details(int id)
        {
           User user= userRepository.GetUserById(id);
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
            return RedirectToAction("Index");
        }
       
        public ActionResult Delete(int id)
        {
            userRepository.DeleteUser(id);
            return RedirectToAction("Index");
        }

    }
}