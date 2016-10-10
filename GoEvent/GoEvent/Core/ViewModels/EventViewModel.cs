using System.Collections.Generic;
using System.Linq;
using GoEvent.Core.Models;

namespace GoEvent.Core.ViewModels
{
    public class EventViewModel
    {
        public IEnumerable<Event> upComingEvents { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
        public ILookup<int, Attendance> Attendences { get; set; }
        public ILookup<string, Following> Followings { get; set; }
    }
}