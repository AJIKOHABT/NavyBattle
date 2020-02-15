using NavyBattleModels.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavyBattleModels.Interfaces
{
    public interface IGameResult
    {
        /// <summary>
        /// Error flag
        /// </summary>
        bool IsError { get; set; }

        /// <summary>
        /// Game status
        /// </summary>
        GameState GameState { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        string ErrorMessage { get; set; }

        /// <summary>
        /// Information about the winner
        /// </summary>
        IUser Winner { get; set; }

        /// <summary>
        /// Game Id
        /// </summary>
        int GameId { get; set; }

        /// <summary>
        /// Shots to return to the player
        /// </summary>
        IEnumerable<IShot> Shots { get; set; }

        /// <summary>
        /// Id of the player whos turn now
        /// </summary>
        int? WhosTurn { get; set; }
    }
}
