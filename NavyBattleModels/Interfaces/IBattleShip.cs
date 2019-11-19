using System;
using System.Collections.Generic;
using System.Text;

namespace NavyBattleModels.Interfaces
{
    /// <summary>
    /// Interface describing battleship
    /// </summary>
    interface IBattleShip
    {
        int Length { get; }

        /// <summary>
        /// Is battleship vertically or horizontally orinted (true - vertically)
        /// </summary>
        bool IsVertical { get; }

        /// <summary>
        /// Starting point of the battleship
        /// </summary>
        Point StartPoint { get; }
        
    }
}
