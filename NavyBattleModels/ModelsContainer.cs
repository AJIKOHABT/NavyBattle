using Microsoft.Extensions.DependencyInjection;
using NavyBattleModels.Interfaces;
using NavyBattleModels.Models;

namespace NavyBattleModels
{
    /// <summary>
    /// Class to save repositories
    /// </summary>
    public class ModelsContainer
    {
        /// <summary>
        /// Method to register services
        /// </summary>
        /// <param name="services">collection of services</param>
        public static void RegisterModels(IServiceCollection services)
        {
            services.AddScoped<IBattleField, ClassicBattleField>();
            services.AddScoped<IBattleShip, BattleShip>();
            services.AddScoped<IGame, Game>();
            services.AddScoped<IGameBattleShip, GameBattleShip>();
            services.AddScoped<IShot, Shot>();
            services.AddScoped<IUser, User>();
            services.AddScoped<IGameBattleField, GameBattleField>();
        }
    }
}
