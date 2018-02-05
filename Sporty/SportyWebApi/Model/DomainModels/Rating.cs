using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportFinderApi.Models
{
    public class Rating
    {
        public virtual int Id { get; set; }
        public virtual decimal Value { get; set; }

        public virtual Sport Sport { get; set; }
    }
}
 