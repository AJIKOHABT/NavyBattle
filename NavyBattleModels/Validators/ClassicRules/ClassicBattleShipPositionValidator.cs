using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavyBattleModels.Validators
{
    public class ClassicBattleShipPositionValidator: IBattleShipPositionValidator
    {


        public static bool Validate(List<BattleShip> battleShips)
        {
            var addedPoints = new HashSet<Point>();

            foreach (var battleShip in battleShips)
            {
                var battleShipSetOfPoints = CreateBattleshipSetOfPoints(battleShip);
                if(battleShipSetOfPoints.Intersect(addedPoints).Any())
                {
                    return false;
                }
                foreach (var battleShipPoint in battleShipSetOfPoints)
                {
                    addedPoints.Add(battleShipPoint);
                }
            }

            return true;
        }


        #region private

        /// <summary>
        /// Creating set of points of battleship
        /// </summary>
        /// <param name="battleShip">Battleship object</param>
        /// <returns>HashSet of points of battleship</returns>
        private static HashSet<Point> CreateBattleshipSetOfPoints(BattleShip battleShip)
        {
            var points = new HashSet<Point>();

            var startX = battleShip.StartPoint.X;
            var startY = battleShip.StartPoint.Y;

            if (battleShip.IsVertical)
            {
                for (var dY = 0; dY < battleShip.Length; dY++)
                {
                    points.Add(new Point(startX, startY + dY));
                }
            }
            else
            {
                for (var dX = 0; dX < battleShip.Length; dX++)
                {
                    points.Add(new Point(startX + dX, startY));
                }
            }           

            return points;
        }

        /// <summary>
        /// Creating set of points around battleship
        /// </summary>
        /// <param name="battleShip">Battleship object</param>
        /// <returns>HashSet of points around battleship</returns>
        private HashSet<Point> CreateSetOfPointsAroundBattleShip(BattleShip battleShip)
        {
            var points = new HashSet<Point>();
            
            return points;
        }

        #endregion
    }
}
