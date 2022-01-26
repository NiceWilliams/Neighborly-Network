using Neighborly.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Neighborly.ViewModels
{
    public class AddEventViewModel
    {

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 chracters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description for your event")]
        [StringLength(500, ErrorMessage = "Description is too long!")]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        public EventType Type { get; set; }

        public List<SelectListItem> EventTypes { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(EventType.Social.ToString(), ((int)EventType.Social).ToString()),
            new SelectListItem(EventType.Entertainment.ToString(), ((int)EventType.Entertainment).ToString()),
            new SelectListItem(EventType.Charity.ToString(), ((int)EventType.Charity).ToString()),
            new SelectListItem(EventType.Holiday.ToString(), ((int)EventType.Holiday).ToString())
        };
    }
}
