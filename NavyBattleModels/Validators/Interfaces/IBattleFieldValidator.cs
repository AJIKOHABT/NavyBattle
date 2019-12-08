using NavyBattleModels.Errors;
using NavyBattleModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavyBattleModels.Validators.Interfaces
{
    public interface IBattleFieldValidator
    {
        /// <summary>
        /// Validate navy battle game field to match classic rules 
        /// </summary>
        /// <param name="battleShips"></param>
        /// <returns></returns>
        IBattleFieldValidationResult Validate(IEnumerable<IBattleShip> battleShips);
    }
}
