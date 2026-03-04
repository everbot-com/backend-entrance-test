using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Everbot.OnlineInterview.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class OnlineInterviewDbContextFactory : IDesignTimeDbContextFactory<OnlineInterviewDbContext>
{
    public OnlineInterviewDbContext CreateDbContext(string[] args)
    {
        // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        var env = args.FirstOrDefault();

        OnlineInterviewEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration(env);
        var connectionString = configuration.GetConnectionString("Default");

        if (!args.Any(x => x.Contains("skip")))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"即將執行作業，連線字串: {connectionString}");
            Console.Write("是否正確? (Y/N): ");
            var input = Console.ReadKey();
            Console.WriteLine();

            if (input.Key == ConsoleKey.Y)
            {
                Console.WriteLine("作業開始");
            }
            else
            {
                Console.WriteLine("操作已被中斷。");
                Environment.Exit(0); // 結束當前執行緒
            }
        }

        var builder = new DbContextOptionsBuilder<OnlineInterviewDbContext>()
            .UseNpgsql(configuration.GetConnectionString("Default"));

        return new OnlineInterviewDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration(string? env)
    {
        var path = string.IsNullOrWhiteSpace(env) ? "appsettings.json" : ("appsettings." + env + ".json");

        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Everbot.OnlineInterview.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
