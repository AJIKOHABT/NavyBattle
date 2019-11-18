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
        public int Length { get; }

        /// <summary>
        /// Is battleship vertically or horizontally orinted (true - vertically)
        /// </summary>
        public bool IsVertical { get; }

        /// <summary>
        /// Starting point of the battleship
        /// </summary>
        public Point StartPoint { get; }
        
    }
}
