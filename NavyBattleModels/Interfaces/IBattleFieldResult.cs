namespace NavyBattleModels.Interfaces
{
    public interface IBattleFieldResult
    {
        /// <summary>
        /// Error flag
        /// </summary>
        bool IsError { get; set; }

        /// <summary>
        /// Flag that battlefield is ready for game and waiting for other player
        /// </summary>
        bool IsWaiting { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        string ErrorMessage { get; set; }

        /// <summary>
        /// Id of the created gamebattlefield
        /// </summary>
        int? GameBattleFieldId { get; set; }

        /// <summary>
        /// Game Id to return to UI when game starts
        /// </summary>
        int? GameId { get; set; }
    }
}
