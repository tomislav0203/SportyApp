using Models.DomainModels;
using Repository.Repos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SportyDesktop.ViewModels;

namespace SportyDesktop.ViewModels
{
    public class HomeViewModel : PropertyChangedBase
    {
        private IEventRepository _eventRepo;
        private ICommand getUserEventsPast;
        private ICommand getUserEventsFuture;
        private ICommand getTodayEventsCommand;
        private ICommand findEventsMenu;
        private ICommand findEventsCommand;
        private bool canExecute = true;

        public HomeViewModel()
        {
            _eventRepo = new EventRepository();
            GetUserEventsPast = new RelayCommand(GetPastEvents, param => this.canExecute);
            GetUserEventsFuture = new RelayCommand(GetFutureEvents, param => this.canExecute);
            GetTodayEventsCommand = new RelayCommand(GetTodayEvents, param => this.canExecute);
            FindEventsMenu = new RelayCommand(FillSports, param => this.canExecute);
            FindEventsCommand = new RelayCommand(FindEvents, param => this.canExecute);
            sportList = new List<Sport>();
            FreePlacesFind = 1;
            GetTodayEvents(null);
        }

        private ObservableCollection<Event> _eventList;
        public ObservableCollection<Event> EventList
        {
            get
            {
                return _eventList;
            }
            set
            {
                _eventList = value;
                NotifyPropertyChanged();
            }
        }

        private List<Sport> sportList;
        public List<Sport> SportList
         {
            get
            {
                return sportList;
            }
            set
            {
                sportList = value;
                NotifyPropertyChanged();
            }
        }

        #region find parameters

        private Sport sportFind;
        public Sport SportFind
        {
            get
            {
                return sportFind;
            }
            set
            {
                sportFind = value;
                NotifyPropertyChanged();
            }
        }

        private int freePlacesFind;
        public int FreePlacesFind
        {
            get
            {
                return freePlacesFind;
            }
            set
            {
                freePlacesFind = value;
                NotifyPropertyChanged();
            }
        }

        private string cityNameFind;
        public string CityNameFind
        {
            get
            {
                return cityNameFind;
            }
            set
            {
                cityNameFind = value;
                NotifyPropertyChanged();
            }
        }

        private string dateFind;
        public string DateFind
        {
            get
            {
                return dateFind;
            }
            set
            {
                dateFind = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        public ICommand GetTodayEventsCommand
        {
            get
            {
                return getTodayEventsCommand;
            }
            set
            {
                getTodayEventsCommand = value;
            }
        }

        public ICommand GetUserEventsPast
        {
            get
            {
                return getUserEventsPast;
            }
            set
            {
                getUserEventsPast = value;
            }
        }

        public ICommand GetUserEventsFuture
        {
            get
            {
                return getUserEventsFuture;
            }
            set
            {
                getUserEventsFuture = value;
            }
        }

        public ICommand FindEventsMenu
        {
            get
            {
                return findEventsMenu;
            }
            set
            {
                findEventsMenu = value;
            }
        }

        public ICommand FindEventsCommand
        {
            get
            {
                return findEventsCommand;
            }
            set
            {
                findEventsCommand = value;
            }
        }

        public async void GetTodayEvents(object obj)
        {
            EventList = new ObservableCollection<Event>(await _eventRepo.GetTodayEvents());
        }

        public async void GetPastEvents(object obj)
        {
            EventList = new ObservableCollection<Event>(await _eventRepo.GetUserEventsPast());
        }

        public async void FillSports(object obj)
        {
            SportList = new List<Sport>(await _eventRepo.GetAllSports());
        }

        public async void GetFutureEvents(object obj)
        {
            EventList = new ObservableCollection<Event>(await _eventRepo.GetUserEventsFuture());
        }

        public async void FindEvents(object obj)
        {
            EventList = new ObservableCollection<Event>(await _eventRepo.FindEvents(SportFind.Id, DateFind, CityNameFind, FreePlacesFind));
        }
    }
}
