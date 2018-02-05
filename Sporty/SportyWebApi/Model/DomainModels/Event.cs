using System;
using System.Collections.Generic;

namespace SportFinderApi.Models
{
    public class Event
    {
        public virtual int Id { get; set; }
        public virtual int MaxPlayers { get; set; }
        public virtual int FreePlayers { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual string Location { get; set; }

        public virtual City City { get; set; }
        public virtual Sport Sport { get; set; }
        public virtual User Creator { get; set; }
        public virtual IList<User> Participants { get; set; }
    }
}
