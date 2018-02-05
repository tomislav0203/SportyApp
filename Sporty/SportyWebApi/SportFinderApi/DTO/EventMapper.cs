using SportFinderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportFinderApi.DTO
{
    public class EventMapper
    {
        public static List<EventDto> MapEventsToEventDto(IEnumerable<Event> events)
        {
            return events.Select(a => new EventDto() {
                Id = a.Id,
                MaxPlayers = a.MaxPlayers,
                FreePlayers = a.FreePlayers,
                StartTime = a.StartTime,
                Location = a.Location,
                SportId = a.Sport.Id,
                SportName = a.Sport.Name,
                CityName = a.City.Name
            }).ToList();

        }

        public static EventParticipantsDto MapEventsToEventParticipantsDto(Event a, List<UserDto> participants)
        {
            EventParticipantsDto result = new EventParticipantsDto()
            {
                Id = a.Id,
                MaxPlayers = a.MaxPlayers,
                FreePlayers = a.FreePlayers,
                StartTime = a.StartTime,
                Location = a.Location,
                SportId = a.Sport.Id,
                SportName = a.Sport.Name,
                CityName = a.City.Name,
                Participants = participants
                
            };
            return result;

        }

        public static Event MapEventDtoToEvent(EventDto e)
        {
            return new Event()
            {
                MaxPlayers = e.MaxPlayers,
                FreePlayers = e.FreePlayers,
                StartTime = e.StartTime,
                Location = e.Location
            };

        }
    }
}