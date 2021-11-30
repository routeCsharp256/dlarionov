using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace OzonEdu.MerchandiseService.Migrator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetSection("DatabaseConnectionOptions:ConnectionString").Get<string>();
            if (string.IsNullOrWhiteSpace(connectionString))
                connectionString = "Host=localhost;Port=5425;Database=merchandise-service;Username=postgres;Password=strongPass";

            var services = new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(
                    rb => rb
                        .AddPostgres()
                        .WithGlobalConnectionString(connectionString)
                        .ScanIn(typeof(Program).Assembly)
                        .For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole());

            var serviceProvider = services.BuildServiceProvider(false);

            using (serviceProvider.CreateScope())
            {
                var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
                if (args.Contains("--dryrun"))
                {
                    runner.ListMigrations();
                }
                else
                {
                    runner.MigrateUp();
                }

                using var connection = new NpgsqlConnection(connectionString);
                connection.Open();
                connection.ReloadTypes();
            }
        }
    }
}
