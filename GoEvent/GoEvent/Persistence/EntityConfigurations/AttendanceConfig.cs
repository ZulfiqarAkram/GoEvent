using GoEvent.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GoEvent.Persistence.EntityConfigurations
{
    public class AttendanceConfig :EntityTypeConfiguration<Attendance>
    {
        public AttendanceConfig()
        {
            HasKey(x => new {x.EventId, x.AttendeeId});
        }
    }
}