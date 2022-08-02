using CCSA_Web.Domain.Models;
using FluentNHibernate.Mapping;

namespace CCSA_Web.Db.Mappings
{
    public class NoteMap :ClassMap<Note>
    {
        public NoteMap()
        {
            Id(x => x.Id);
            Map(x => x.Title);
            Map(x => x.Content);
            Map(x => x.CreatedDate);
            Map(x => x.UpdatedDate);
            Map(x => x.GroupName).CustomType<Group>();
            References(x => x.User).Column("UserId");

        }
    }
}
