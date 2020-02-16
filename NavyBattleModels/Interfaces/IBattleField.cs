using NavyBattleModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavyBattleModels.Interfaces
{
    public interface IBattleField
    {
        /// <summary>
        /// Id of the battlefield
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Width of the battlefield
        /// </summary>
        int Width { get; set; }

        /// <summary>
        /// Height of the battlefield
        /// </summary>
        int Height { get; set; }

        /// <summary>
        /// List of battleships on the battlefield
        /// </summary>
        ICollection<BattleShip> BattleShips { get; set; }

        /// <summary>
        /// Recalculation of the startPoint and adding battleship to battlefield
        /// </summary>
        /// <param name="battleships"></param>
        void AddBattleShips(IEnumerable<IBattleShip> battleships);

        /// <summary>
        /// Player owner of this battlefield
        /// </summary>
        User Owner { get; set; }

        /// <summary>
        /// Id of the player owner of this battlefield
        /// </summary>
        int? OwnerId { get; set; }

    }
}
