using FluentNHibernate.Mapping;
using SportFinderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Mapping
{
    public class CityMap : ClassMap<City>
    {
        public CityMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Table("Cities");
        }
    }
}
