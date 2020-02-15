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
        /// Id of the battleShip
        /// </summary>
        private int _id;

        /// <summary>
        /// Zone around the battleship
        /// </summary>
        private HashSet<Point> _zoneAroundBattleShip;

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
        /// ID of the battlefield
        /// </summary>
        private int? _battleFieldId;

        /// <summary>
        /// Id of the battleShip
        /// </summary>
        public int Id
        {
            get 
            {
                return _id;
            }
            set 
            {
                _id = value;
            }
        }

        /// <summary>
        /// Length of the battleship
        /// </summary>
        public int Length 
        {
            get 
            { 
                return _length; 
            }
            set 
            {
                _length = value;
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
            set 
            {
                _isVertical = value;
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
            set 
            {
                _startPoint = value;
            }
        }

        /// <summary>
        /// ID of the battlefield
        /// </summary>
        public int? BattleFieldId
        {
            get 
            {
                return _battleFieldId;
            }
            set 
            {
                _battleFieldId = value;
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
        /// Recalculation of battleship parameters
        /// </summary>
        public void RecalculateBattleShip()
        {
            _startPoint = _isVertical ?
                new Point(_startPoint.X, _startPoint.Y + _length + 1) :
                new Point(_startPoint.X + _length + 1, _startPoint.Y);
            _length = Math.Abs(_length);
        }

        /// <summary>
        /// Creating set of points of battleship
        /// </summary>
        /// <param name="battleShip">Battleship object</param>
        /// <returns>HashSet of points of battleship</returns>
        public HashSet<Point> CreateBattleshipSetOfPoints()
        {
            var points = new HashSet<Point>();

            if (_isVertical)
            {
                for (var dY = 0; dY < _length; dY++)
                {
                    points.Add(new Point(_startPoint.X, _startPoint.Y + dY));
                }
            }
            else
            {
                for (var dX = 0; dX < _length; dX++)
                {
                    points.Add(new Point(_startPoint.X + dX, _startPoint.Y));
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
            _zoneAroundBattleShip = new HashSet<Point>();

            if (_startPoint.X > 1)
            {
                CreateLeftZoneSetOfPoints();
            }

            if (_startPoint.X < 10)
            {
                CreateRightZoneSetOfPoints();
            }

            if (_startPoint.Y > 1)
            {
                CreateTopZoneSetOfPoints();
            }

            if(_startPoint.Y < 10)
            {
                CreateBottomZoneSetOfPoints();
            }

            return _zoneAroundBattleShip;
        }

        /// <summary>
        /// Getting end point of the battleship
        /// </summary>
        /// <returns></returns>
        public Point GetEndPoint()
        {
            return _isVertical ? new Point(_startPoint.X, _startPoint.Y + _length - 1) :
                                new Point(_startPoint.X + _length - 1, _startPoint.Y);
        }

        #endregion

        #region private

        /// <summary>
        /// Creating set of points to the left of the battleship
        /// </summary>
        /// <param name="battleShip"></param>
        /// <returns></returns>
        private void CreateLeftZoneSetOfPoints()
        {
            var endPoint = GetEndPoint();
            if (_isVertical)
            {
                var startY = _startPoint.Y > 1 ? -1 : 0;
                var endY = endPoint.Y < 10 ? endPoint.Y + 1 : endPoint.Y;
                for (int dY = startY; dY <= endY; dY++)
                {
                    _zoneAroundBattleShip.Add(new Point(_startPoint.X - 1, _startPoint.Y+dY));
                }
            }
            else
            {
                if (_startPoint.X > 1)
                {
                    _zoneAroundBattleShip.Add(new Point(_startPoint.X - 1, _startPoint.Y));
                }
            }
        }

        /// <summary>
        /// Creating set of points to the right of the battleship
        /// </summary>
        /// <param name="battleShip"></param>
        /// <returns></returns>
        private void CreateRightZoneSetOfPoints()
        {
            var endPoint = GetEndPoint();
            if (_isVertical)
            {
                var startY = _startPoint.Y > 1 ? -1 : 0;
                var endY = endPoint.Y < 10 ? endPoint.Y + 1 : endPoint.Y;
                for (int dY = startY; dY <= endY; dY++)
                {
                    _zoneAroundBattleShip.Add(new Point(_startPoint.X + 1, _startPoint.Y + dY));
                }
            }
            else
            {
                if (endPoint.X < 10)
                {
                    _zoneAroundBattleShip.Add(new Point(endPoint.X + 1, _startPoint.Y));
                }
            }
        }

        /// <summary>
        /// Creating set of points on the top of the battleship
        /// </summary>
        /// <returns></returns>
        private void CreateTopZoneSetOfPoints()
        {
            var endPoint = GetEndPoint();
            if (!_isVertical)
            {
                var startX = _startPoint.X > 1 ? -1 : 0;
                var endX = endPoint.X < 10 ? endPoint.X + 1 : endPoint.X;
                for (int dX = startX; dX <= endX; dX++)
                {
                    _zoneAroundBattleShip.Add(new Point(_startPoint.X + dX, _startPoint.Y - 1));
                }
            }
            else
            {
                if (_startPoint.Y > 1)
                {
                    _zoneAroundBattleShip.Add(new Point(_startPoint.X, _startPoint.Y - 1));
                }
            }
        }

        /// <summary>
        /// Creating set of points on the bottom of the battleship
        /// </summary>
        /// <returns></returns>
        private void CreateBottomZoneSetOfPoints()
        {
            var endPoint = GetEndPoint();
            if (!_isVertical)
            {
                var startX = _startPoint.X > 1 ? -1 : 0;
                var endX = endPoint.X < 10 ? endPoint.X + 1 : endPoint.X;
                for (int dX = startX; dX <= endX; dX++)
                {
                    _zoneAroundBattleShip.Add(new Point(_startPoint.X + dX, _startPoint.Y + 1));
                }
            }
            else
            {
                if (endPoint.Y < 10)
                {
                    _zoneAroundBattleShip.Add(new Point(endPoint.X, _startPoint.Y + 1));
                }
            }
        }



        #endregion
    }
}
