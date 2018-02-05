using Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class UserEvents
    {
        public List<Event> PastEvents { get; set; }
        public List<Event> FutureEvents { get; set; }
    }
}
