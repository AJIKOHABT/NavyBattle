using System;
using System.Collections.Generic;
using System.Text;

namespace NavyBattleModels.Enums
{
    /// <summary>
    /// Enum of the classic (russian) lengths of different types of battleships
    /// </summary>
    public enum ClassicBattleShipTypesLength
    {
        /// <summary>
        /// Battleship or dreadnought (Линкор in russian)
        /// </summary>
        Battleship = 4,

        /// <summary>
        /// Cruiser (Крейсер in russian)
        /// </summary>
        Cruiser = 3,

        /// <summary>
        /// Destroyer (Эсминец in russian)
        /// </summary>
        Destroyer = 2,

        /// <summary>
        /// Torpedo boat (Торпедный катер in russian)
        /// </summary>
        Mosquito = 1
    }
}
