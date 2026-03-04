using Everbot.OnlineInterview.Samples;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Everbot.OnlineInterview.EntityFrameworkCore.ModelCreatingExtensions;

public static class SampleModelCreatingExtensions
{
    public static void ConfigureSample(this ModelBuilder builder, DatabaseFacade db)
    {
        builder.Entity<Sample>(entity =>
        {
            entity.Property(p => p.Name).HasMaxLength(SampleConsts.NameMaxLength);
            entity.Property(p => p.SampleType).HasMaxLength(32).HasConversion<string>();
        });
    }
}
