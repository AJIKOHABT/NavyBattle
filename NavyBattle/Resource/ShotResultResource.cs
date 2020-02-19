using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NavyBattleController.Resource
{
    public class ShotResultResource
    {
        /// <summary>
        /// Indicator of successful validation (true if successful)
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Damaged or destroyed battleship
        /// </summary>
        public GameBattleShipResource GameBattleShip { get; set; }

        /// <summary>
        /// Shot
        /// </summary>
        public ShotResource Shot { get; set; }
    }
}
