using Microsoft.Extensions.DependencyInjection;
using NavyBattle.Dal.Repositories;
using NavyBattleModels;
using NavyBattleModels.Models;

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
        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<BaseBattleField>, BattleFieldRepository>();
            services.AddScoped<IBaseRepository<BattleShip>, BattleShipRepository>();
            services.AddScoped<IBaseRepository<Game>, GameRepository>();
            services.AddScoped<IBaseRepository<GameBattleShip>, GameBattleShipRepository>();
            services.AddScoped<IBaseRepository<Shot>, ShotRepository>();
            services.AddScoped<IBaseRepository<User>, UserRepository>();
            services.AddScoped<IBaseRepository<GameBattleField>, GameBattleFieldRepository>();

        }
    }
}
