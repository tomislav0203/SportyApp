using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportFinderApi.DTO
{
    public class EventParticipantsDto
    {
        public virtual int Id { get; set; }
        public virtual int MaxPlayers { get; set; }
        public virtual int FreePlayers { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual string Location { get; set; }
        public virtual int SportId { get; set; }
        public virtual string SportName { get; set; }
        public virtual string CityName { get; set; }
        public virtual string UserName { get; set; }

        public virtual List<UserDto> Participants { get; set; }
    }
}