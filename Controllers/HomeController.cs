using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginReg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoginReg.Controllers
{
    public class HomeController : Controller
    {
        private HomeContext _context;
        public HomeController(HomeContext context)
        {
        	_context = context;
        } 

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // ViewBag.hasUserMessage = TempData["hasUserMessage"];            
            return View();
        }

        [HttpPost]
        [RouteAttribute("LoginUser")]
        public IActionResult LoginUser(LogUser logUser)
        {
            User userLoggingIn = _context.Users.Where((user) => user.Email == logUser.LogEmail).SingleOrDefault();
            
            if (userLoggingIn != null && logUser.LogPassword != null)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(userLoggingIn, userLoggingIn.Password ,logUser.LogPassword))
                {
                    HttpContext.Session.SetInt32("UserId", userLoggingIn.UserId);
                    return RedirectToAction("Display", "Main");
                }
                if (0 == Hasher.VerifyHashedPassword(userLoggingIn, userLoggingIn.Password ,logUser.LogPassword))
                {
                    TempData["LoginPasswordError"] = "Password is invalid";
                }
            }         
            if(userLoggingIn == null)
            {
                TempData["LoginEmailError"] = "Email Address is not in the database";
            }
            return View("Index");
        }

        [HttpPost]
        [RouteAttribute("Register")]
        public IActionResult Register(UserViewModel model)
        {
            bool hasUser = _context.Users.Any((user) => user.Email == model.Email);
            if(hasUser)
            {
                ViewBag.Exists = "User with that email already exists!";
                // TempData["hasUserMessage"] = "User with that email already exists!";
                // return RedirectToAction("Index");
            }
            if (ModelState.IsValid && hasUser == false)
            {
                User NewUser = new User
                {
                    FName = model.FName,
                    LName = model.LName,
                    Email = model.Email,
                    Password = model.Password
                };
                // hash password and create a new user
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                NewUser.Password = Hasher.HashPassword(NewUser, model.Password);
                _context.Add(NewUser);
                _context.SaveChanges();
                int UserId = _context.Users.Last().UserId;
                HttpContext.Session.SetInt32("UserId", UserId);
                return RedirectToAction("Display", "Main");
            }
                                // QUESTION: SHOULD I DO REDRECT OR VIEW?
            return View("Index", model);            
            // return RedirectToAction("Index");
        }
        
        
        [HttpGet]
        [RouteAttribute("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}