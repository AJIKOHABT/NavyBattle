using NavyBattleModels.Interfaces;
using NavyBattleModels.Validators.Interfaces;
using System;
using System.Collections.Generic;

namespace NavyBattleModels.Services
{
    public interface IGameService
    {
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

        /// <summary>
        /// Creating gameBattleField for the player
        /// </summary>
        /// <param name="battleFieldId"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        IBattleFieldResult CreateGameBattleField(int battleFieldId, int ownerId);

        /// <summary>
        /// Waiting for other player to start the game
        /// </summary>
        /// <param name="gameBattleFieldId"></param>
        /// <returns></returns>
        IBattleFieldResult WaitingForPlayer(int gameBattleFieldId);

        /// <summary>
        /// Checking for whos turn now
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="gameId"></param>
        /// <returns></returns>
        IGameResult CheckForUsersTurn(int userId, int gameId);
    }
}