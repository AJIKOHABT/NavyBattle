using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NavyBattle.Dal.Contexts;
using NavyBattle.Dal.Repositories;
using NavyBattleModels;
using NavyBattleModels.Interfaces;

namespace NavyBattle.Dal
{
    /// <summary>
    /// Class to save repositories
    /// </summary>
    public class DalContainer
    {
        /// <summary>
        /// Method to register repositories and database context
        /// </summary>
        /// <param name="services">collection of services</param>
        /// <param name="connectionString">database connection string</param>
        public static void RegisterRepositories(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<NavyBattleContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("NavyBattle.Dal")));
            services.AddScoped<IBaseRepository<IBattleField>, BattleFieldRepository>();
            services.AddScoped<IBaseRepository<IBattleShip>, BattleShipRepository>();
            services.AddScoped<IBaseRepository<IGame>, GameRepository>();
            services.AddScoped<IBaseRepository<IGameBattleShip>, GameBattleShipRepository>();
            services.AddScoped<IBaseRepository<IShot>, ShotRepository>();
            services.AddScoped<IBaseRepository<IUser>, UserRepository>();
            services.AddScoped<IBaseRepository<IGameBattleField>, GameBattleFieldRepository>();

        }
    }
}
