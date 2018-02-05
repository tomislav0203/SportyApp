using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportFinderApi.DTO
{
    public class SubscriptionDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string CityName { get; set; }
        public int SportId { get; set; }
        public string Name { get; set; }
    }
}