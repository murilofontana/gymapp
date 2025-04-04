using GymApp.Api.Persistence.Converters;
using GymApp.Domain.Common.Entities;
using GymApp.Domain.Common.ValueObjects;
using GymApp.Domain.TrainerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymApp.Api.Persistence.Configurations;

public class TrainerConfigurations : IEntityTypeConfiguration<Trainer>
{
    public void Configure(EntityTypeBuilder<Trainer> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .ValueGeneratedNever();

        builder.Property<List<Guid>>("_sessionIds")
            .HasListOfIdsConverter()
            .HasColumnName("SessionIds");

        builder.Property(t => t.UserId);

        builder.OwnsOne<Schedule>("_schedule", sb =>
        {
            sb.Property<Dictionary<DateOnly, List<TimeRange>>>("_calendar")
                .HasColumnName("ScheduleCalendar")
                .HasValueJsonConverter();

            sb.Property(s => s.Id)
                .HasColumnName("ScheduleId");
        });
    }
}
