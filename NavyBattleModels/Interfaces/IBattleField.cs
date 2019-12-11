using System;
using System.Collections.Generic;
using System.Text;

namespace NavyBattleModels.Interfaces
{
    public interface IBattleField
    {
        /// <summary>
        /// Width of the battlefield
        /// </summary>
        int Width { get; set; }

        /// <summary>
        /// Height of the battlefield
        /// </summary>
        int Height { get; set; }

        /// <summary>
        /// Id of the battlefield
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// List of battleships on the battlefield
        /// </summary>
        ICollection<IBattleShip> BattleShips { get; set; }


        /// <summary>
        /// Recalculation of the startPoint and adding battleship to battlefield
        /// </summary>
        /// <param name="battleships"></param>
        void AddBattleShips(IEnumerable<IBattleShip> battleships);

    }
}
