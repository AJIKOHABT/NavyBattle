using System;
using System.Collections.Generic;
using System.Text;

namespace NavyBattleModels.Validators
{
    /// <summary>
    /// Main validator for navyBattle
    /// </summary>
    public class BattleFieldValidator
    {

        public static string Validate(List<BattleShip> battleShips)
        {
            BattleShipsValidator.Validate(battleShips);
            BeyondBorderValidator.Validate(battleShips);
            BattleShipPositionValidator.Validate(battleShips);
            return "no valid data";
        }
    }
}
