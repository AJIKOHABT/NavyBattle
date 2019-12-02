using NavyBattleModels.Interfaces;
using System.Collections.Generic;

namespace NavyBattleModels
{
    /// <summary>
    /// Base class for battlefield
    /// </summary>
    public class BaseBattleField : IBattleField
    {
        #region fields and properties

        /// <summary>
        /// Width of the battlefield
        /// </summary>
        private int _width;

        /// <summary>
        /// Height of the battlefield
        /// </summary>
        private int _height;

        /// <summary>
        /// Id of the battlefield
        /// </summary>
        private int _id;

        /// <summary>
        /// List of battleships on the battlefield
        /// </summary>
        private IEnumerable<BattleShip> _battleships;

        /// <summary>
        /// Width of the battlefield
        /// </summary>
        public int Width
        {
            get
            {
                return _width;
            }
        }

        /// <summary>
        /// Height of the battlefield
        /// </summary>
        public int Height
        {
            get
            {
                return _height;
            }
        }

        /// <summary>
        /// Id of the battlefield
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// List of battleships on the battlefield
        /// </summary>
        public IEnumerable<IBattleShip> Battleships
        {
            get
            {
                return _battleships;
            }
        }

        #endregion

        #region constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public BaseBattleField(int width, int height)
        {
            _width = width;
            _height = height;
            _battleships = new List<BattleShip>();
        }

        #endregion

        #region public methods

        /// <summary>
        /// Recalculation of the startPoint and adding battleship to battlefield
        /// </summary>
        /// <param name="battleships"></param>
        public void AddBattleShips(IEnumerable<IBattleShip> battleships)
        {
            foreach (var battleship in battleships)
            {
                if (battleship.Length < 0)
                {
                    battleship.RecalculateBattleShip();
                }
                _battleships.Add(battleship);
            }
        }

        /// <summary>
        /// Save the battlefield
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            return _id;
        }

        #endregion
    }
}
