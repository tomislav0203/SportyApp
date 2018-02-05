using Infrastructure.Domain;
using Model.DomainModels;
using SportFinderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repos
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }

        public void AddSubscription(Subscription subscription)
        {
            Session.Save(subscription);
        }

        public IEnumerable<Sport> GetAllSports()
        {
            return Session.Query<Sport>();
        }

        public Subscription GetSubscriptionById(int id)
        {
            return Session.Query<Subscription>().Where(x => x.Id == id).SingleOrDefault();
        }

        public List<Subscription> GetSubscriptionsByUserName(string username)
        {
            return Session.Query<Subscription>().Where(x => x.User.UserName.Equals(username)).ToList();
        }
    }
}
