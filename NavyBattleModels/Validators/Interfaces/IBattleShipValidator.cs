using System.Collections.Generic;
using NavyBattleModels.Errors;
using NavyBattleModels.Interfaces;

namespace NavyBattleModels.Validators.Interfaces
{
    interface IBattleShipValidator
    {
        /// <summary>
        /// Validate battleships to match rules
        /// </summary>
        /// <param name="battleShips">List of battleships on the battlefield</param>
        /// <returns>IEnumerable of errors</returns>
        IEnumerable<BattleFieldError> Validate(IEnumerable<IBattleShip> battleShips);
    }
}
