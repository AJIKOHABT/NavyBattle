using NavyBattleModels.Enums;
using NavyBattleModels.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NavyBattleModels.Models
{
    /// <summary>
    /// Class for shot in navy battle game
    /// </summary>
    public class Shot : IShot
    {
        #region properties and fields

        /// <summary>
        /// Id of the shot
        /// </summary>
        private int _id;

        /// <summary>
        /// X coordinate of the shot point
        /// </summary>
        private int _shotX;

        /// <summary>
        /// Y coordinate of the shot point
        /// </summary>
        private int _shotY;

        /// <summary>
        /// Point where shot was made
        /// </summary>
        private Point _shotPoint;

        /// <summary>
        /// Result state of the shot
        /// </summary>
        private ShotState _state;

        /// <summary>
        /// Id of the player who has made shot
        /// </summary>
        private int? _playerId;

        /// <summary>
        /// Id of the battlefield where shot was made
        /// </summary>
        private int? _gameBattleFieldId;

        /// <summary>
        /// Id of the shot
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
        /// X coordinate of the shot point
        /// </summary>
        public int ShotX
        {
            get
            {
                if (_shotX == 0 && _shotPoint.X != 0)
                {
                    _shotX = _shotPoint.X;
                }
                return _shotX;
            }
            set
            {
                _shotX = value;
            }
        }

        /// <summary>
        /// Y coordinate of the shot point
        /// </summary>
        public int ShotY
        {
            get
            {
                if (_shotY == 0 && _shotPoint.Y != 0)
                {
                    _shotY = _shotPoint.Y;
                }
                return _shotY;
            }
            set
            {
                _shotY = value;
            }
        }

        /// <summary>
        /// Point where shot was made
        /// </summary>
        [NotMapped]
        public Point ShotPoint
        {
            get
            {
                return _shotPoint;
            }
            set
            {
                _shotPoint = value;
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
        /// Id of the player who has made shot
        /// </summary>
        public int? PlayerId
        {
            get
            {
                return _playerId;
            }
            set
            {
                _playerId = value;
            }
        }

        /// <summary>
        /// Id of the battlefield where shot was made
        /// </summary>
        public int? GameBattleFieldId
        {
            get 
            {
                return _gameBattleFieldId;
            }
            set 
            {
                _gameBattleFieldId = value;
            }
        }

        /// <summary>
        /// BattleField where shot was made
        /// </summary>
        public GameBattleField GameBattleField { get; set; }

        /// <summary>
        /// Id of the game where shot was made
        /// </summary>
        public int? GameId { get; set; }

        #endregion
    }
}
