using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NavyBattleController.Resource
{
    public class GameBattleFieldResource
    {
        /// <summary>
        /// Game battlefield id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Battlefield on which the game will take place
        /// </summary>
        public BattleFieldResource BattleField { get; set; }

        /// <summary>
        /// Player owner of this battlefield
        /// </summary>
        public UserResource Owner { get; set; }

        /// <summary>
        /// BattleShips in the game
        /// </summary>
        public IEnumerable<GameBattleShipResource> GameBattleShips { get; set; }

        /// <summary>
        /// Shots that were made during the game                                                                                                                                                                                                                                                                                                                     
        /// </summary>
        public IEnumerable<ShotResource> Shots { get; set; }

        /// <summary>
        /// Flag to indicate that battlefield is ready to play
        /// </summary>
        public bool IsWaiting { get; set; }
    }
}
