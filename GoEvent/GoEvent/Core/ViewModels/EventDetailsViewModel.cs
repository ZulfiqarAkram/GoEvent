using GoEvent.Core.Models;

namespace GoEvent.Core.ViewModels
{
    public class EventDetailsViewModel
    {
        public Event Event { get; set; }
        public bool IsFollowing { get; set; }
        public bool IsAttending { get; set; }
    }
}