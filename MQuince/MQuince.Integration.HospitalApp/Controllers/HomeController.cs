using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MQuince.Integration.HospitalApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string Welcome()
        {
            return "This is Welcome action method";
        }

        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Reports()
        {
            return View();
        }
    }
}
