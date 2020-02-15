using NavyBattleModels.Enums;
using System;

namespace NavyBattleModels.Interfaces
{
    /// <summary>
    /// Class for battleship in the game
    /// </summary>
    public interface IGameBattleShip
    {
        /// <summary>
        /// Id of the gamebattleship
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Game battlefield in which battleship stands
        /// </summary>
        IGameBattleField GameBattleField { get; set; }

        // <summary>
        /// Id of the game battlefield
        /// </summary>
        int? GameBattlefieldId { get; set; }

        /// <summary>
        /// Battleship on the battleField
        /// </summary>
        IBattleShip BattleShip { get; set; }

        /// <summary>
        /// Id of the battleship on the battleField
        /// </summary>
        int? BattleShipId { get; set; }

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
