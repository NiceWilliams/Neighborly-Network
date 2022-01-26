using Microsoft.AspNetCore.Mvc;
using Neighborly.Data;
using Neighborly.Models;
using Neighborly.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Neighborly.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext context;

        public EventsController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Event> events = context.Events.ToList();

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

                context.Events.Add(newEvent);
                context.SaveChanges();

                return Redirect("/Events");
            }

            return View("/Events", addEventViewModel);
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
            ViewBag.eventId = context.Events.Find(eventId, name);

            return View();
        }

        public IActionResult Delete()
        {
            ViewBag.events = context.Events.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
               Event evt = context.Events.Find(eventId);
                context.Events.Remove(evt);
            }
            context.SaveChanges();

            return Redirect("/Events");
        }
    }
}