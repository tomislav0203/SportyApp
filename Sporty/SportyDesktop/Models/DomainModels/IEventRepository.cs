using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DomainModels
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetTodayEvents();
        Task<IEnumerable<Event>> GetUserEventsPast();
        Task<IEnumerable<Event>> GetUserEventsFuture();
        Task<IEnumerable<Event>> FindEvents(int sportId, string date, string cityName, int freePlayers);
        Task<IEnumerable<Sport>> GetAllSports();
        Task<IEnumerable<User>> GetParticipants(int eventId);
    }
}
