using NavyBattleModels.Enums;
using System;
using System.Collections.Generic;


namespace NavyBattleModels.Interfaces
{
    /// <summary>
    /// Interface for the game
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// Game id
        /// </summary>
        Guid Guid { get; set; }

        /// <summary>
        /// Battlefield on which the game will take place
        /// </summary>
        IEnumerable<IGameBattleField> GameBattleFields { get; set; }

        /// <summary>
        /// Id of the player who's shooting now
        /// </summary>
        Guid TurnOfThePlayer { get; set; }

        /// <summary>
        /// Winner
        /// </summary>
        IUser Winner { get; set; }

        /// <summary>
        /// Id of the winner
        /// </summary>
        Guid WinnerId { get; set; }

        /// <summary>
        /// Current state of the game
        /// </summary>
        GameState State { get; set; }
    }
}
