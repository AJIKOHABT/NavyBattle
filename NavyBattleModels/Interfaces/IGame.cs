using System.Collections.Generic;


namespace NavyBattleModels.Interfaces
{
    public interface IGame
    {
        /// <summary>
        /// Game id
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Battlefield on which the game will take place
        /// </summary>
        IBattleField BattleField { get; }

        /// <summary>
        /// BattleShips in the game
        /// </summary>
        IEnumerable<IGameBattleShip> GameBattleShips { get; }

        /// <summary>
        /// Shots that were made during the game
        /// </summary>
        IEnumerable<IShot> Shots { get; }
    }
}
