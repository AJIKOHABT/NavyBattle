using NavyBattleModels.Enums;
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
        IGameBattleField GameBattleField { get; set; }

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
