using NavyBattleModels.Interfaces;
using NavyBattleModels.Models;
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
        GameBattleShip GameBattleShip { get; set; }

        /// <summary>
        /// Shot
        /// </summary>
        Shot Shot { get; set; }

    }
}
