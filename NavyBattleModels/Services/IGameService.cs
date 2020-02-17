using NavyBattleModels.Interfaces;
using NavyBattleModels.Models;
using NavyBattleModels.Validators;
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
        Game GetById(int id);

        /// <summary>
        /// Getting all battlefields from the database
        /// </summary>
        /// <returns></returns>
        IEnumerable<Game> GetAll();

        /// <summary>
        /// Getting result of shot
        /// </summary>
        /// <param name="shot"></param>
        /// <returns></returns>
        ShotResult FireShot(Shot shot);

        /// <summary>
        /// Creating gameBattleField for the player
        /// </summary>
        /// <param name="battleFieldId"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        BattleFieldResult CreateGameBattleField(int battleFieldId, int ownerId);

        /// <summary>
        /// Waiting for other player to start the game
        /// </summary>
        /// <param name="gameBattleFieldId"></param>
        /// <returns></returns>
        BattleFieldResult WaitingForPlayer(int gameBattleFieldId);

        /// <summary>
        /// Checking for whos turn now
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="gameId"></param>
        /// <returns></returns>
        GameResult CheckForUsersTurn(int userId, int gameId);
    }
}