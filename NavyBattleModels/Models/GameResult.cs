using NavyBattleModels.Enums;
using NavyBattleModels.Interfaces;
using System.Collections.Generic;

namespace NavyBattleModels.Models
{
    public class GameResult : IGameResult
    {
        /// <summary>
        /// Error flag
        /// </summary>
        public bool IsError { get; set; }

        /// <summary>
        /// Game status
        /// </summary>
        public GameState GameState { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Information about the winner
        /// </summary>
        public IUser Winner { get; set; }

        /// <summary>
        /// Game Id
        /// </summary>
        public int GameId { get; set; }

        /// <summary>
        /// Shots to return to the player
        /// </summary>
        public IEnumerable<IShot> Shots { get; set; }

        /// <summary>
        /// Id of the player whos turn now
        /// </summary>
        public int? WhosTurn { get; set; }
    }
}
