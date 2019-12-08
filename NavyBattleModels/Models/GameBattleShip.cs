using NavyBattleModels.Interfaces;
using NavyBattleModels.Enums;

namespace NavyBattleModels.Models
{
    /// <summary>
    /// Class for battleship in the game
    /// </summary>
    public class GameBattleShip : IGameBattleShip
    {
        #region properties and fields

        /// <summary>
        /// Game in which battleship stands
        /// </summary>
        private IGame _game;

        /// <summary>
        /// Battleship on the battleField
        /// </summary>
        private IBattleShip _battleShip;

        /// <summary>
        /// State of the battleship in the game
        /// </summary>
        private BattleShipState _state;

        /// <summary>
        /// Count of damaged points of the battleship
        /// </summary>
        private int _damagedPointsCnt;

        /// <summary>
        /// Game in which battleship stands
        /// </summary>
        public IGame Game
        {
            get 
            {
                return _game;
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
        public GameBattleShip(IGame game, IBattleShip battleShip)
        {
            _game = game;
            _battleShip = battleShip;
            _state = BattleShipState.Full;
        }

        #endregion
    }
}
