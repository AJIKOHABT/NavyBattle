using NavyBattleModels.Enums;
using System.Collections.Generic;

namespace NavyBattleController.Resource
{
    public class GameResultResource
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
        public UserResource Winner { get; set; }

        /// <summary>
        /// Game Id
        /// </summary>
        public int GameId { get; set; }

        /// <summary>
        /// Shots to return to the player
        /// </summary>
        public IEnumerable<ShotResource> Shots { get; set; }

        /// <summary>
        /// Id of the player whos turn now
        /// </summary>
        public int? WhosTurn { get; set; }
    }
}
