using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportFinderApi.DTO
{
    public class UserEventsDto
    {
        public List<EventDto> PastEvents { get; set; }
        public List<EventDto> FutureEvents { get; set; }
    }
}