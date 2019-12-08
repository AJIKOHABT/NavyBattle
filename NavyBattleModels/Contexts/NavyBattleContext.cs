using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using NavyBattleModels.Interfaces;
using System.IO;

namespace NavyBattleModels.Contexts
{
    public class NavyBattleContext : DbContext
    {
        public NavyBattleContext(DbContextOptions<NavyBattleContext> options) : base(options)
        {            
        }

        public DbSet<IGame> Games
        {
            get;
            set; 
        }

        public DbSet<IShot> Shots
        {
            get;
            set;
        }

        public DbSet<IGameBattleShip> GameBattleShips
        {
            get;
            set;
        }

        public DbSet<IBattleField> BattleFields
        {
            get;
            set;
        }

        public DbSet<IBattleShip> BattleShips
        {
            get;
            set;
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<NavyBattleContext>
    {
        public NavyBattleContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../NavyBattleController/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<NavyBattleContext>();
            var connectionString = configuration.GetConnectionString("sqlConnection");
            builder.UseSqlServer(connectionString);
            return new NavyBattleContext(builder.Options);
        }
    }
}
