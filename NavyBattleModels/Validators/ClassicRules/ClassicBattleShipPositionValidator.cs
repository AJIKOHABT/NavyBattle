using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NavyBattleModels.Validators.Interfaces;
using NavyBattleModels.Errors;
using NavyBattleModels.Enums;

namespace NavyBattleModels.Validators
{
    public class ClassicBattleShipPositionValidator: IBattleValidator
    {
        private HashSet<Point> _addedPoints;

        public IEnumerable<BattleFieldError> Validate(IEnumerable<BattleShip> battleShips)
        {
            var errors = new List<BattleFieldError>();
            var zonePoints = new HashSet<Point>();
            var battleShipsPoints = new HashSet<Point>();

            foreach (var battleShip in battleShips)
            {
                var battleShipSetOfPoints = battleShip.CreateBattleshipSetOfPoints();
                var battleShipTmpSetOfPoints =  new HashSet<Point>(battleShipSetOfPoints);

                battleShipSetOfPoints.IntersectWith(battleShipsPoints);
                foreach (var errorPoint in battleShipSetOfPoints)
                {
                    errors.Add(new BattleFieldError(BattlefieldErrorTypes.BattleShipCrossingOther, errorPoint));
                }

                battleShipTmpSetOfPoints.IntersectWith(zonePoints);
                foreach (var errorPoint in battleShipTmpSetOfPoints)
                {
                    errors.Add(new BattleFieldError(BattlefieldErrorTypes.BattleShipNearOther, errorPoint));
                }
                
                foreach (var battleShipPoint in battleShipSetOfPoints)
                {
                    battleShipsPoints.Add(battleShipPoint);
                }
            }

            return errors;
        }       


    }
}
