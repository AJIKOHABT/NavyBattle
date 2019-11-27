using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavyBattleModels.Validators
{
    public class ClassicBattleShipPositionValidator: IBattleShipPositionValidator
    {
        private HashSet<Point> _addedPoints;

        public Dictionary<Point, ErrorType> Validate(List<BattleShip> battleShips)
        {
            var errors = new Dictionary<Point, ErrorType>;
            var zonePoints = new HashSet<Point>();
            var battleShipsPoints = new HashSet<Point>();
            foreach (var battleShip in battleShips)
            {
                var battleShipSetOfPoints = battleShip.CreateBattleshipSetOfPoints();
                foreach (var errorPoints in battleShipSetOfPoints.IntersectWith(battleShipsPoints))
                {
                    errors.Add(Point, ErrorType.IntersectWithShipError);
                }
                foreach (var errorPoints in battleShipSetOfPoints.IntersectWith(zonePoints))
                {
                    errors.Add(Point, ErrorType.TouchWithShipError);
                }
                //addedPoints.Union(battleShipSetOfPoints); try it at home
                foreach (var battleShipPoint in battleShipSetOfPoints)
                {
                    addedPoints.Add(battleShipPoint);
                }
            }

            return errors;
        }       


    }
}
