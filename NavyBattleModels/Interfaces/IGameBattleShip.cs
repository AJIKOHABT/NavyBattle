using NavyBattleModels.Enums;

namespace NavyBattleModels.Interfaces
{
    /// <summary>
    /// Class for battleship in the game
    /// </summary>
    public interface IGameBattleShip
    {
        /// <summary>
        /// Game in which battleship stands
        /// </summary>
        IGame Game { get; }

        /// <summary>
        /// Battleship on the battleField
        /// </summary>
        IBattleShip BattleShip { get; }

        /// <summary>
        /// State of the battleship in the game
        /// </summary>
        BattleShipState State { get; set; }

    }
}
