using Microsoft.AspNetCore.Mvc;
using Neighborly.Data;
using Neighborly.Models;
using System.Collections.Generic;

namespace Neighborly.Controllers
{
    public class EventsController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(string name, string desc)
        {
            EventData.Add(new Event(name, desc));

            return Redirect("/Events");
        }

        [HttpGet]
        [Route("/Events/Detail")]
        public IActionResult Detail()
        {
            return View();
        }

        [HttpGet]
        [Route("/Events/Edit")]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
