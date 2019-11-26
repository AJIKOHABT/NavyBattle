using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavyBattleModels.Validators
{
    public class ClassicBattleShipPositionValidator: IBattleShipPositionValidator
    {
        private HashSet<Point> _addedPoints;

        public static bool Validate(List<BattleShip> battleShips)
        {
            _addedPoints = new HashSet<Point>();

            foreach (var battleShip in battleShips)
            {
                var battleShipSetOfPoints = CreateBattleshipSetOfPoints(battleShip);
                if(battleShipSetOfPoints.Intersect(addedPoints).Any())
                {
                    return false;
                }
                //addedPoints.Union(battleShipSetOfPoints); try it at home
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

        /// <summary>
        /// Creating set of points to the left of the battleship
        /// </summary>
        /// <param name="battleShip"></param>
        /// <returns></returns>
        private HashSet<Point> CreateLeftZoneSetOfPoints(HashSet<Point> battleShipPoints)
        {
            var points = new HashSet<Point>();
            foreach (var battleShipPoint in battleShipPoints)
            {
                points.Add(new Point(battleShipPoint.X - 1, battleShipPoint.Y));
            }
            return points;
        }

        /// <summary>
        /// Creating set of points to the right of the battleship
        /// </summary>
        /// <param name="battleShip"></param>
        /// <returns></returns>
        private HashSet<Point> CreateLeftZoneSetOfPoints(HashSet<Point> battleShipPoints)
        {
            var points = new HashSet<Point>();
            foreach (var battleShipPoint in battleShipPoints)
            {
                points.Add(new Point(battleShipPoint.X + 1, battleShipPoint.Y));
            }
            return points;
        }

        private Point CreateTopPoint(Point startPoint)
        {
            return new Point(startPoint.X, startPoint.Y - 1);
        }

        private Point CreateBottomPoint(Point lastPoint)
        {
            return new Point(lastPoint.X, lastPoint.Y + 1);
        }

        #endregion
    }
}
