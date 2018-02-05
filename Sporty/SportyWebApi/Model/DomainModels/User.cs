using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportFinderApi.Models
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }

        public virtual City City { get; set; }
        public virtual IList<Event> Events { get; set; }
        public virtual IList<Subscription> Subscriptions { get; set; }
        public virtual IList<Rating> Ratings { get; set;  }

        public virtual void AddRating(decimal ratingValue, int sportId)
        {
            Rating rating = this.Ratings.FirstOrDefault();
            rating.Value = (rating.Value + ratingValue) / 2;
        }
    }
}
