using NavyBattleModels.Interfaces;
using NavyBattleModels.Enums;
using System;

namespace NavyBattleModels.Models
{
    /// <summary>
    /// Class for battleship in the game
    /// </summary>
    public class GameBattleShip : IGameBattleShip
    {
        #region properties and fields

        /// <summary>
        /// Id of the battleship
        /// </summary>
        private Guid _guid;

        /// <summary>
        /// Game in which battleship stands
        /// </summary>
        private IGameBattleField _gameBattleField;

        /// <summary>
        /// Id of the game
        /// </summary>
        private Guid _gameBattlefieldId;

        /// <summary>
        /// Battleship on the battleField
        /// </summary>
        private IBattleShip _battleShip;

        /// <summary>
        /// Id of the battleship on the battleField
        /// </summary>
        private Guid _battleShipId;

        /// <summary>
        /// State of the battleship in the game
        /// </summary>
        private BattleShipState _state;

        /// <summary>
        /// Count of damaged points of the battleship
        /// </summary>
        private int _damagedPointsCnt;

        /// <summary>
        /// Id of the battleship
        /// </summary>
        public Guid Guid
        {
            get 
            {
                return _guid;
            }
            set 
            {
                _guid = value;
            }
        }

        /// <summary>
        /// Game in which battleship stands
        /// </summary>
        public IGameBattleField GameBattleField
        {
            get 
            {
                return _gameBattleField;
            }
            set 
            {
                if (value != null)
                {
                    _gameBattleField = value;
                }
            }
        }

        /// <summary>
        /// Id of the game
        /// </summary>
        public Guid GameBattlefieldId
        {
            get
            {
                return _gameBattlefieldId;
            }
            set
            {
                _gameBattlefieldId = value;
            }
        }

        /// <summary>
        /// Battleship on the battleField
        /// </summary>
        public IBattleShip BattleShip
        {
            get 
            {
                return _battleShip;
            }
            set
            {
                if (value != null)
                {
                    _battleShip = value;
                }
            }
        }

        /// <summary>
        /// Id of the battleship on the battleField
        /// </summary>
        public Guid BattleShipId
        {
            get 
            {
                return _battleShipId;
            }
            set
            {
                _battleShipId = value;
            }
        }

        /// <summary>
        /// State of the battleship in the game
        /// </summary>
        public BattleShipState State
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
        /// Count of damaged points of the battleship
        /// </summary>
        public int DamagedPointsCnt 
        {
            get 
            {
                return _damagedPointsCnt;
            }
            set
            {
                _damagedPointsCnt = value;
            }
        }

        #endregion

        #region constructor

        /// <summary>
        /// Constructor of the battleship in the game
        /// </summary>
        /// <param name="game"></param>
        /// <param name="battleShip"></param>
        public GameBattleShip(IGameBattleField gameBattleField, IBattleShip battleShip)
        {
            _gameBattleField = gameBattleField;
            _battleShip = battleShip;
            _state = BattleShipState.Full;
        }

        #endregion
    }
}
