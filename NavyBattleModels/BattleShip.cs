using System;
using System.Collections.Generic;
using NavyBattleModels.Interfaces;

namespace NavyBattleModels
{
    /// <summary>
    /// Class describing battleship on battlefield
    /// </summary>
    public class BattleShip : IBattleShip
    {
        #region fields & properties

        /// <summary>
        /// Length of the battleship
        /// </summary>
        private int _length;

        /// <summary>
        /// Is battleship vertically or horizontally orinted (true - vertically)
        /// </summary>
        private bool _isVertical;

        /// <summary>
        /// Starting point of the battleship
        /// </summary>
        private Point _startPoint;

        /// <summary>
        /// Length of the battleship
        /// </summary>
        public int Length 
        {
            get 
            { 
                return _length; 
            }
        }

        /// <summary>
        /// Is battleship vertically or horizontally orinted (true - vertically)
        /// </summary>
        public bool IsVertical
        {
            get 
            { 
                return _isVertical; 
            }
        }

        /// <summary>
        /// Starting point of the battleship
        /// </summary>
        public Point StartPoint
        {
            get
            {
                return _startPoint;
            }
        }

        #endregion

        #region constructors

        /// <summary>
        /// BattleShip constructor
        /// </summary>
        /// <param name="length">Length of the battleship</param>
        /// <param name="startPoint">Starting point of the battleship</param>
        /// <param name="isVertical">Is battleship vertically or horizontally orinted (true - vertically)</param>
        public BattleShip(int length, Point startPoint, bool isVertical = true)
        {
            _length = length;
            _isVertical = isVertical;
            _startPoint = startPoint;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Creating set of points of battleship
        /// </summary>
        /// <param name="battleShip">Battleship object</param>
        /// <returns>HashSet of points of battleship</returns>
        public HashSet<Point> CreateBattleshipSetOfPoints()
        {
            var points = new HashSet<Point>();

            if (IsVertical)
            {
                for (var dY = 0; dY < Length; dY++)
                {
                    points.Add(new Point(StartPoint.X, StartPoint.Y + dY));
                }
            }
            else
            {
                for (var dX = 0; dX < Length; dX++)
                {
                    points.Add(new Point(StartPoint.X + dX, StartPoint.Y));
                }
            }

            return points;
        }

        /// <summary>
        /// Creating set of points around battleship
        /// </summary>
        /// <param name="battleShip">Battleship object</param>
        /// <returns>HashSet of points around battleship</returns>
        public HashSet<Point> CreateSetOfPointsAroundBattleShip()
        {
            var points = new HashSet<Point>();

            if (StartPoint.X - 1 >= 1)
            {
                CreateLeftZoneSetOfPoints();
            }

            return points;
        }

        /// <summary>
        /// Getting end point of the battleship
        /// </summary>
        /// <returns></returns>
        public Point GetEndPoint()
        {
            return IsVertical ? new Point(StartPoint.X, StartPoint.Y + Length - 1) :
                                new Point(StartPoint.X + Length - 1, StartPoint.Y);
        }

        #endregion

        #region private

        /// <summary>
        /// Creating set of points to the left of the battleship
        /// </summary>
        /// <param name="battleShip"></param>
        /// <returns></returns>
        private HashSet<Point> CreateLeftZoneSetOfPoints()
        {
            var points = new HashSet<Point>();
            var endPoint = GetEndPoint();
            if (IsVertical)
            {
                var startY = StartPoint.Y - 1 >= 1 ? -1 : 0;
                var endY = endPoint.Y < 10 ? endPoint.Y + 1 : endPoint.Y;
                for (int dY = startY; dY <= endY; dY++)
                {
                    points.Add(new Point(StartPoint.X - 1, StartPoint.Y+dY));
                }
            }
            else
            {
                if (StartPoint.X - 1 >= 1)
                {
                    points.Add(new Point(StartPoint.X - 1, StartPoint.Y));
                }
            }
            return points;
        }

        /// <summary>
        /// Creating set of points to the right of the battleship
        /// </summary>
        /// <param name="battleShip"></param>
        /// <returns></returns>
        private HashSet<Point> CreateRightZoneSetOfPoints(HashSet<Point> battleShipPoints)
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
