using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    public class ClassesHabilidadeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
