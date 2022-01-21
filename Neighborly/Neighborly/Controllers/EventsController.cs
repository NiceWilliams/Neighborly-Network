using Microsoft.AspNetCore.Mvc;
using Neighborly.Models;
using System.Collections.Generic;

namespace Neighborly.Controllers
{
    public class EventsController : Controller
    {
        static private List<Event> Events = new List<Event>();
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.events = Events;

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
            Events.Add(new Event(name,desc));

            return Redirect("/Events");
        }

        [HttpGet]
        [Route("/Events/Detail")]
        public IActionResult Detail()
        {
            return View();
        } 
    }
}
