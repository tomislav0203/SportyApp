using FluentNHibernate.Mapping;
using SportFinderApi.Models;

namespace Repository.Mapping
{
    public class EventMap : ClassMap<Event>
    {
        public EventMap()
        {
            Id(x => x.Id);
            Map(x => x.MaxPlayers);
            Map(x => x.FreePlayers);
            Map(x => x.StartTime);
            Map(x => x.Location);

            References(x => x.City).Column("CityId").Not.LazyLoad();
            References(x => x.Sport).Column("SportId").Not.LazyLoad();
            References(x => x.Creator).Column("UserId").Not.LazyLoad();
            HasManyToMany(x => x.Participants).Table("UsersEvents").ParentKeyColumn("EventId").ChildKeyColumn("UserId");
            Table("Events");
        }
    }
}
