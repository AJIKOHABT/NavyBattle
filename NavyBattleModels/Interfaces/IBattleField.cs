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
        int Width { get; }

        /// <summary>
        /// Height of the battlefield
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Id of the battlefield
        /// </summary>
        int Id { get; }

        /// <summary>
        /// List of battleships on the battlefield
        /// </summary>
        IEnumerable<IBattleShip> Battleships { get; }


        /// <summary>
        /// Recalculation of the startPoint and adding battleship to battlefield
        /// </summary>
        /// <param name="battleships"></param>
        void AddBattleShips(IEnumerable<IBattleShip> battleships);

        /// <summary>
        /// Save the battlefield
        /// </summary>
        /// <returns></returns>
        int Save();
    }
}
