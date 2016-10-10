using System;

namespace GoEvent.Core.Dto
{
    public class EventDto
    {
        public int Id { get; set; }
        public bool IsCancel { get;  set; }
        public UserDto Artist { get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public GenreDto Genre { get; set; }
    }
}