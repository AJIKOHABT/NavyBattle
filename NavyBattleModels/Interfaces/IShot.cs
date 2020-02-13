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
        Guid Guid { get; set; }

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
        Guid PlayerId { get; set; }

        /// <summary>
        /// Id of the game battlefield where shot was made
        /// </summary>
        Guid GameBattleFieldId { get; set; }

        /// <summary>
        /// Id of the game
        /// </summary>
        Guid GameId { get; set; }
    }
}
