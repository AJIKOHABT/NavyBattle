using System.Collections.Generic;

namespace NavyBattleController.Resource
{
    public class BattleFieldResource
    {
        /// <summary>
        /// Id of the battlefield
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Width of the battlefield
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height of the battlefield
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// List of battleships on the battlefield
        /// </summary>
        public IEnumerable<BattleShipResource> BattleShips { get; set; }

        /// <summary>
        /// Player owner of this battlefield
        /// </summary>
        public UserResource Owner { get; set; }        
    }
}
