using System;

namespace NavyBattleModels
{
    /// <summary>
    /// Class describing battleship
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
        private IPoint _startPoint;

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
        public IPoint StartPoint
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
        public BattleShip(int length, IPoint startPoint, bool isVertical = true)
        {
            _length = length;
            _isVertical = isVertical;
            _startPoint = startPoint;
        }

        #endregion
    }
}
