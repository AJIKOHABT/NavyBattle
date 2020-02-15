using NavyBattleModels.Interfaces;

namespace NavyBattleModels.Models
{
    public class BattleFieldResult : IBattleFieldResult
    {
        /// <summary>
        /// Error flag
        /// </summary>
        public bool IsError { get; set; }

        /// <summary>
        /// Flag that battlefield is ready for game and waiting for other player
        /// </summary>
        public bool IsWaiting { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Id of the created gamebattlefield
        /// </summary>
        public int? GameBattleFieldId { get; set; }

        /// <summary>
        /// Game Id to return to UI when game starts
        /// </summary>
        public int? GameId { get; set; }
    }
}
