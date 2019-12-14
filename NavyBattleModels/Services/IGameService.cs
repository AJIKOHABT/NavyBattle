using NavyBattleModels.Interfaces;
using NavyBattleModels.Validators.Interfaces;
using System.Collections.Generic;

namespace NavyBattleModels.Services
{
    public interface IGameService
    {
        /// <summary>
        /// Validating and creating battlefield
        /// </summary>
        /// <param name="id">id of the chosen battlefield</param>
        /// <returns></returns>
        IGame CreateGame(int id);

        /// <summary>
        /// Getting battlefield by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IGame GetById(int id);

        /// <summary>
        /// Getting all battlefields from the database
        /// </summary>
        /// <returns></returns>
        IEnumerable<IGame> GetAll();

        /// <summary>
        /// Getting result of shot
        /// </summary>
        /// <param name="shot"></param>
        /// <returns></returns>
        IShotResult FireShot(IShot shot);
    }
}