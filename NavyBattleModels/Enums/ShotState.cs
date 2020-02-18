
namespace NavyBattleModels.Enums
{
    /// <summary>
    /// Enum with different shot(point) states
    /// </summary>
    public enum ShotState
    {
        /// <summary>
        /// Non valid shot, for example shot is outside of the battlefield
        /// </summary>
        Nonvalid,

        /// <summary>
        /// Shot fired past the battleship
        /// </summary>
        Miss,

        /// <summary>
        /// Shot has damaged the battleship
        /// </summary>
        Damaged,

        /// <summary>
        /// Shot has destroyed the battleship
        /// </summary>
        Destroyed,

        /// <summary>
        /// Shot was made at the same point
        /// </summary>
        SamePoint,

        /// <summary>
        /// Shot was made not in turn of the user
        /// </summary>
        NotUsersTurn,
    }
}
