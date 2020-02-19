using NavyBattleModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NavyBattleController.Resource
{
    public class GameBattleShipResource
    {
        /// <summary>
        /// Id of the gamebattleship
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Battleship on the battleField
        /// </summary>
        public BattleShipResource BattleShip { get; set; }

        /// <summary>
        /// State of the battleship in the game
        /// </summary>
        public BattleShipState State { get; set; }

        /// <summary>
        /// Count of damaged points of the battleship
        /// </summary>
        public int DamagedPointsCnt { get; set; }
    }
}
