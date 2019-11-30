using System;
using System.Collections.Generic;
using System.Text;

namespace NavyBattleModels.Enums
{
    /// <summary>
    /// Enum containing types of errors which can occur during navy battlefiled validation
    /// </summary>
    public enum BattlefieldErrorTypes
    {
        /// <summary>
        /// Occurs when one battleship crossing other
        /// </summary>
        BattleShipCrossingOther,

        /// <summary>
        /// Occurs when battleship stands too close to the other
        /// </summary>
        BattleShipNearOther,

        /// <summary>
        /// Occurs when one or more points of the battleship is out of border
        /// </summary>
        BattleShipOutOfBorder,

        /// <summary>
        /// Occurs when battleship is too long for rules
        /// </summary>
        BattleShipNonValidLength,

        /// <summary>
        /// Occurs when count of one type of battleship is greater than need
        /// </summary>
        BattleShipNonValidCount,
        
    }
}
