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
        IGame Game { get; set; }

        // <summary>
        /// Id of the game
        /// </summary>
        int GameId { get; set; }

        /// <summary>
        /// Battleship on the battleField
        /// </summary>
        IBattleShip BattleShip { get; set; }

        /// <summary>
        /// Id of the battleship on the battleField
        /// </summary>
        int BattleShipId { get; set; }

        /// <summary>
        /// State of the battleship in the game
        /// </summary>
        BattleShipState State { get; set; }

        /// <summary>
        /// Count of damaged points of the battleship
        /// </summary>
        int DamagedPointsCnt { get; set; }

    }
}
