using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DomainModels;
using Repository.Repos;
using SportyDesktop.ViewModels;

namespace SportyDesktop.ViewModels
{
    public class EventViewModel : PropertyChangedBase
    {
        private IEventRepository _eventRepo;

        public EventViewModel()
        {
            _eventRepo = new EventRepository();
        }

        private Event currentEvent;
        public Event CurrentEvent
        {
            get
            {
                return currentEvent;
            }
            set
            {
                currentEvent = value;
                NotifyPropertyChanged();
            }
        }

        private List<User> participants;
        public List<User> Participants
        {
            get
            {
                return participants;
            }
            set
            {
                participants = value;
                NotifyPropertyChanged();
            }
        }

        public void setEvent(Event e)
        {
            CurrentEvent = e;
        }

        public async void setParticipants()
        {
            Participants = new List<User>(await _eventRepo.GetParticipants(currentEvent.Id));
        }
    }
}
