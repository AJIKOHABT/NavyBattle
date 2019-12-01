using System.Collections.Generic;
using NavyBattleModels.Validators.Interfaces;
using NavyBattleModels.Errors;
using NavyBattleModels.Enums;
using NavyBattleModels.Interfaces;

namespace NavyBattleModels.Validators
{
    public class ClassicBattleShipPositionValidator: IBattleShipValidator
    {
        #region IBattleValidator

        /// <summary>
        /// Validate battleships to match rules
        /// </summary>
        /// <param name="battleField">Battlefield to validate</param>
        /// <returns>IEnumerable of errors</returns>
        public IEnumerable<BattleFieldError> Validate(IBattleField battleField)
        {
            var errors = new List<BattleFieldError>();
            var zonePoints = new HashSet<Point>();
            var battleShipsPoints = new HashSet<Point>();

            foreach (var battleShip in battleField.Battleships)
            {
                var battleShipSetOfPoints = battleShip.CreateBattleshipSetOfPoints();

                foreach (var battleShipPoint in battleShipSetOfPoints)
                {
                    if (battleShipsPoints.Contains(battleShipPoint))
                    {
                        errors.Add(new BattleFieldError(BattlefieldErrorTypes.BattleShipCrossingOther, battleShipPoint));
                    }
                    else 
                    {
                        if (zonePoints.Contains(battleShipPoint))
                        {
                            errors.Add(new BattleFieldError(BattlefieldErrorTypes.BattleShipNearOther, battleShipPoint));
                        }
                        battleShipsPoints.Add(battleShipPoint);
                    }                    
                }
                var zoneAroundBattleShip = battleShip.CreateSetOfPointsAroundBattleShip();
                foreach (var zonePoint in zoneAroundBattleShip)
                {
                    zonePoints.Add(zonePoint);
                }
            }

            return errors;
        }

        #endregion

    }
}
