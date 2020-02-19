using System;
using System.Collections.Generic;
using System.Text;
using NavyBattleModels.Interfaces;

namespace NavyBattleModels
{
    /// <summary>
    /// Struct describing point
    /// </summary>
    public struct Point : IEquatable<Point>
    {

        #region fields & properties

        /// <summary>
        /// X coordinate of the point
        /// </summary>
        private int _x;

        /// <summary>
        /// Y coordinate of the point
        /// </summary>
        private int _y;

        /// <summary>
        /// X coordinate of the point
        /// </summary>
        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        /// <summary>
        /// Y coordinate of the point
        /// </summary>
        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        #endregion

        #region constructor

        /// <summary>
        /// Constructor of Point object
        /// </summary>
        /// <param name="x">x coordinate of the point</param>
        /// <param name="y">y coordinate of the point</param>
        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        #endregion

        #region override of System.Object

        /// <summary>
        /// Check equality of two point objects
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            var otherPoint = (Point)obj;

            return this.X == otherPoint.X && this.Y == otherPoint.Y;
        }

        /// <summary>
        /// Get hash code of the current object
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _x*20000 + _y;
        }

        #endregion

        #region IEquatable<T>

        /// <summary>
        /// Check equality of two point objects
        /// </summary>
        /// <param name="otherPoint"></param>
        /// <returns></returns>
        bool IEquatable<Point>.Equals(Point otherPoint)
        {
            return this.X == otherPoint.X && this.Y == otherPoint.Y;
        }
        
        #endregion
    }
}
