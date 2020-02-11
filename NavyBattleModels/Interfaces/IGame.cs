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
        IBattleField BattleField { get; set; }

        /// <summary>
        /// Id of the battlefield
        /// </summary>
        int BattleFieldId { get; set; }

        /// <summary>
        /// BattleShips in the game
        /// </summary>
        IEnumerable<IGameBattleShip> GameBattleShips { get; set; }

        /// <summary>
        /// Shots that were made during the game
        /// </summary>
        IEnumerable<IShot> Shots { get; set; }

        /// <summary>
        /// Current state of the game
        /// </summary>
        GameState State { get; set; }
    }
}
