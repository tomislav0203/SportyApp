using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportFinderApi.Models
{
    public class Subscription
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual User User { get; set; }
        public virtual Sport Sport { get; set; }
        public virtual City City { get; set; }
    }
}
