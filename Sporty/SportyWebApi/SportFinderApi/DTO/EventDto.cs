using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportFinderApi.DTO
{
    public class EventDto
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

        public string validateForCreation()
        {
            if (String.IsNullOrEmpty(UserName)) return "Nije unesen username";
            if (String.IsNullOrEmpty(CityName)) return "Nije unesen grad";
            if (SportId == 0) return "Nije unesen sport";
            if (String.IsNullOrEmpty(Location)) return "Nije unesena lokacija";
            if (StartTime == null) return "Nije uneseno vrijeme";
            if (MaxPlayers == 0) return "Nije unesen max broj igraca";
            return String.Empty;


        }
    }
}