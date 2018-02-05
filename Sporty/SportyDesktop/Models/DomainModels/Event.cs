using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DomainModels
{
    public class Event
    {
        public Event()
        {

        }

        public int Id { get; set; }
        public int MaxPlayers { get; set; }
        public int FreePlayers { get; set; }
        public DateTime StartTime { get; set; }
        public string Location { get; set; }
        public string SportName { get; set; }
    }
}
