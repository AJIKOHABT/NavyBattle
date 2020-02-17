using Microsoft.Extensions.DependencyInjection;
using NavyBattleModels.Services;

namespace NavyBattle.Services
{
    /// <summary>
    /// Class to save repositories
    /// </summary>
    public class ServicesContainer
    {
        /// <summary>
        /// Method to register services
        /// </summary>
        /// <param name="services">collection of services</param>
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IBattleFieldService, BattleFieldService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
