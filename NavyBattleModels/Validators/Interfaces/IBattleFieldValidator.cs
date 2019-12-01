using NavyBattleModels.Errors;
using NavyBattleModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavyBattleModels.Validators.Interfaces
{
    interface IBattleFieldValidator
    {
        /// <summary>
        /// Validate navy battle game field to match classic rules 
        /// </summary>
        /// <param name="battleShips"></param>
        /// <returns></returns>
        IEnumerable<BattleFieldError> Validate(IEnumerable<IBattleShip> battleShips);
    }
}
