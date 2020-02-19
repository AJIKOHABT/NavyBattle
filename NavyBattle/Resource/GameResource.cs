using NavyBattleModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NavyBattleController.Resource
{
    public class GameResource
    {
        /// <summary>
        /// Game id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Battlefield on which the game will take place
        /// </summary>
        public IEnumerable<GameBattleFieldResource> GameBattleFields { get; set; }

        /// <summary>
        /// Id of the player who's shooting now
        /// </summary>
        public int? TurnOfThePlayer { get; set; }

        /// <summary>
        /// Winner
        /// </summary>
        public UserResource Winner { get; set; }

        /// <summary>
        /// Current state of the game
        /// </summary>
        public GameState State { get; set; }
    }
}
