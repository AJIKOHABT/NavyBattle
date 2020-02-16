using NavyBattleModels.Enums;
using NavyBattleModels.Models;
using System;

namespace NavyBattleModels.Interfaces
{
    /// <summary>
    /// Interface for shot in navy battle game
    /// </summary>
    public interface IShot
    {
        /// <summary>
        /// Id of the shot
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// X coordinate of the shot point
        /// </summary>
        int ShotX { get; set; }

        /// <summary>
        /// X coordinate of the shot point
        /// </summary>
        int ShotY { get; set; }

        /// <summary>
        /// Point where shot was made
        /// </summary>
        Point ShotPoint { get; set; }

        /// <summary>
        /// Result state of the shot
        /// </summary>
        ShotState State { get; set; }

        /// <summary>
        /// Id of the player who has made the shot
        /// </summary>
        int? PlayerId { get; set; }

        /// <summary>
        /// BattleField where shot was made
        /// </summary>
        GameBattleField GameBattleField { get; set; }

        /// <summary>
        /// Id of the BattleField where shot was made
        /// </summary>
        int? GameBattleFieldId { get; set; }

        /// <summary>
        /// Id of the game where shot was made
        /// </summary>
        int? GameId { get; set; }
    }
}
