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
    public class MainController : Controller
    {
        private HomeContext _context;
        public MainController(HomeContext context)
        {
        	_context = context;
        }

        [HttpGet]
        [Route("Main")]
        public IActionResult Display()
        {
            // ViewBag.hasUserMessage = TempData["hasUserMessage"];
            return View("Main");
        }
    }
}