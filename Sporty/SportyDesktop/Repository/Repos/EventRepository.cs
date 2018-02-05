using Models.DomainModels;
using Newtonsoft.Json.Linq;
using Repository.Data;
using Repository.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repos
{
    public class EventRepository : IEventRepository
    {
        private HttpHelper _context;

        public EventRepository()
        {
            _context = new HttpHelper();
            _context.setBaseUrl("http://sportfinderapi.azurewebsites.net");
        }

        public async Task<IEnumerable<Event>> GetTodayEvents()
        {
            string dateString = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            IEnumerable<Event> result = await _context.GetEvents("api/Events/GetByCity?username=" + CurrentUser.username + "&date=" + dateString);
            return result;
        }

        public async Task<IEnumerable<Event>> GetUserEventsPast()
        {
            UserEvents result = await _context.GetUserEvents("api/Events/GetUserEvents?username=" + CurrentUser.username);
            return result.PastEvents;
        }

        public async Task<IEnumerable<Event>> GetUserEventsFuture()
        {
            UserEvents result = await _context.GetUserEvents("api/Events/GetUserEvents?username=" + CurrentUser.username);
            return result.FutureEvents;
        }

        public async Task<IEnumerable<Event>> FindEvents(int sportId, string date, string cityName, int freePlayers)
        {
            string req = "api/Events/FindEvents?sportId=" + sportId + "&date=" + date.Split(' ')[0] + "&cityName=" + cityName + "&freePlayers=" + freePlayers;
            IEnumerable<Event> result = await _context.GetEvents("api/Events/FindEvents?sportId=" + sportId + "&date=" + date.Split(' ')[0] + "&cityName=" + cityName + "&freePlayers=" + freePlayers);
            return result;
        }

        public async Task<IEnumerable<Sport>> GetAllSports()
        {
            IEnumerable<Sport> result = await _context.GetAllSports("api/Events/GetAllSports");
            return result;
        }

        public async Task<IEnumerable<User>> GetParticipants(int eventId)
        {
            IEnumerable<User> result = await _context.GetEventParticipants("api/Events/GetEvent/" + eventId);
            return result;
        }
    }
}
