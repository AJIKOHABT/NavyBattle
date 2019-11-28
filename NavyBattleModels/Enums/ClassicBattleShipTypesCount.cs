using System;
using System.Collections.Generic;
using System.Text;

namespace NavyBattleModels.Enums
{
    /// <summary>
    /// Enum of the classic (russian) counts of different types of battleships
    /// </summary>
    public enum ClassicBattleShipTypesCount
    {
        /// <summary>
        /// Battleship or dreadnought (Линкор in russian)
        /// </summary>
        Battleship = 1,

        /// <summary>
        /// Cruiser (Крейсер in russian)
        /// </summary>
        Cruiser = 2,

        /// <summary>
        /// Destroyer (Эсминец in russian)
        /// </summary>
        Destroyer = 3,

        /// <summary>
        /// Torpedo boat (Торпедный катер in russian)
        /// </summary>
        Mosquito = 4
    }
}
