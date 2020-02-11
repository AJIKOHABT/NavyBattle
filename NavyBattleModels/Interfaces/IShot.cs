using NavyBattleModels.Enums;

namespace NavyBattleModels.Interfaces
{
    /// <summary>
    /// Interface for shot in navy battle game
    /// </summary>
    public interface IShot
    {
        /// <summary>
        /// Point where shot was made
        /// </summary>
        Point ShotPoint { get; set; }

        /// <summary>
        /// Result state of the shot
        /// </summary>
        ShotState State { get; set; }

        /// <summary>
        /// Point where shot was made
        /// </summary>
        int GameId { get; set; }
    }
}
