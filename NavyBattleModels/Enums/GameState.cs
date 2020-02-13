
namespace NavyBattleModels.Enums
{
    /// <summary>
    /// Enum with different shot(point) states
    /// </summary>
    public enum GameState
    {
        /// <summary>
        /// Game is started
        /// </summary>
        Started,

        /// <summary>
        /// Waiting for players to connect
        /// </summary>
        WaitingForPlayers,

        /// <summary>
        /// Waiting for shot from the player
        /// </summary>
        WaitingForShot,
            
        /// <summary>
        /// Game is over
        /// </summary>
        Finished

    }
}
