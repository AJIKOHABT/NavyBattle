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
        /// Save the battlefield
        /// </summary>
        /// <returns></returns>
        int Save();
    }
}
