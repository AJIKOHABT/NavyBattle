using NavyBattleModels;

namespace NavyBattleController.Resource
{
    public class SaveShotResource
    {

        /// <summary>
        /// Point where shot was made
        /// </summary>
        public Point ShotPoint { get; set; }

        /// <summary>
        /// Id of the player who has made the shot
        /// </summary>
        public int? PlayerId { get; set; }

        /// <summary>
        /// Id of the BattleField where shot was made
        /// </summary>
        public int? GameBattleFieldId { get; set; }

        /// <summary>
        /// Id of the game where shot was made
        /// </summary>
        public int? GameId { get; set; }
    }
}
