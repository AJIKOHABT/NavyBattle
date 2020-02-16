using NavyBattleModels.Enums;
using NavyBattleModels.Models;
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
        int Id { get; set; }

        /// <summary>
        /// Battlefield on which the game will take place
        /// </summary>
        IEnumerable<GameBattleField> GameBattleFields { get; set; }

        /// <summary>
        /// Id of the player who's shooting now
        /// </summary>
        int? TurnOfThePlayer { get; set; }

        /// <summary>
        /// Winner
        /// </summary>
        User Winner { get; set; }

        /// <summary>
        /// Id of the winner
        /// </summary>
        int? WinnerId { get; set; }

        /// <summary>
        /// Current state of the game
        /// </summary>
        GameState State { get; set; }
    }
}
