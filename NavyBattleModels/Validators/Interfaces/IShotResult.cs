using NavyBattleModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavyBattleModels.Validators.Interfaces
{
    public interface IShotResult
    {
        /// <summary>
        /// Indicator of successful validation (true if successful)
        /// </summary>
        bool IsSuccess { get; set; }

        /// <summary>
        /// Damaged or destroyed battleship
        /// </summary>
        IGameBattleShip GameBattleShip { get; set; }

        /// <summary>
        /// Shot
        /// </summary>
        IShot Shot { get; set; }
    }
}
