using NavyBattleModels.Enums;
using NavyBattleModels.Interfaces;

namespace NavyBattleModels.Models
{
    /// <summary>
    /// Class for shot in navy battle game
    /// </summary>
    public class Shot : IShot
    {
        #region properties and fields

        /// <summary>
        /// Point where shot was made
        /// </summary>
        private Point _shotPoint;

        /// <summary>
        /// Result state of the shot
        /// </summary>
        private ShotState _state;

        /// <summary>
        /// Id of the game where shot was made
        /// </summary>
        private int _gameId;

        /// <summary>
        /// Point where shot was made
        /// </summary>
        public Point ShotPoint
        {
            get
            {
                return _shotPoint;
            }
        }

        /// <summary>
        /// Result state of the shot
        /// </summary>
        public ShotState State
        {
            get
            {
                return _state;
            }
            set 
            {
                _state = value;
            }
        }

        /// <summary>
        /// Point where shot was made
        /// </summary>
        public int GameId
        {
            get
            {
                return _gameId;
            }
        }

        #endregion
    }
}
