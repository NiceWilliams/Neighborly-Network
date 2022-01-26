using Microsoft.AspNetCore.Mvc;
using Neighborly.Data;
using Neighborly.Models;
using Neighborly.ViewModels;
using System.Collections.Generic;

namespace Neighborly.Controllers
{
    public class EventsController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            List<Event> events = new List<Event>(EventData.GetAll());

            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();

            return View(addEventViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid)
            {
                Event newEvent = new Event
                {
                    Name = addEventViewModel.Name,
                    Description = addEventViewModel.Description
                };

                EventData.Add(newEvent);

                return Redirect("/Events");
            }

            return View(addEventViewModel);
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

        [HttpPost]
        [Route("/Events/Edit")]
        public IActionResult EditEvent(int eventId, string name)
        {
            ViewBag.eventId = EventData.GetById(eventId);

            return View();
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }
            return Redirect("/Events");
        }
    }
}