using GymApp.Api.Persistence.Converters;
using GymApp.Domain.Common.Entities;
using GymApp.Domain.Common.ValueObjects;
using GymApp.Domain.RoomAggregate;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymApp.Api.Persistence.Configurations;

public class RoomConfigurations : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .ValueGeneratedNever();

        builder.Property("_maxDailySessions")
            .HasColumnName("MaxDailySessions");

        builder.Property<Dictionary<DateOnly, List<Guid>>>("_sessionIdsByDate")
            .HasColumnName("SessionIdsByDate")
            .HasValueJsonConverter();

        builder.OwnsOne<Schedule>("_schedule", sb =>
        {
            sb.Property<Dictionary<DateOnly, List<TimeRange>>>("_calendar")
                .HasColumnName("ScheduleCalendar")
                .HasValueJsonConverter();

            sb.Property(s => s.Id)
                .HasColumnName("ScheduleId");
        });

        builder.Property(r => r.Name);
        builder.Property(r => r.GymId);
    }
}