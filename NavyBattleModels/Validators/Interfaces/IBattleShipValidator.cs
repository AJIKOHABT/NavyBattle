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
        /// <param name="battleField">Battlefield to validate</param>
        /// <returns>IEnumerable of errors</returns>
        IEnumerable<IBattleFieldError> Validate(IBattleField battleField);
    }
}
