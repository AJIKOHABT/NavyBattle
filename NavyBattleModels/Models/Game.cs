using System;
using System.Collections.Generic;
using System.Text;
using NavyBattleModels.Interfaces;
using NavyBattleModels.Contexts;
using NavyBattleModels.Enums;

namespace NavyBattleModels.Models
{
    /// <summary>
    /// Class for the game
    /// </summary>
    public class Game: IGame
    {
        #region properties and fields

        /// <summary>
        /// Game id
        /// </summary>
        private int _id;

        /// <summary>
        /// Battlefield on which the game will take place
        /// </summary>
        private IBattleField _battleField;

        /// <summary>
        /// Id of the battlefield
        /// </summary>
        private int _battleFieldId;

        /// <summary>
        /// BattleShips in the game
        /// </summary>
        private List<IGameBattleShip> _gameBattleShips = new List<IGameBattleShip>();

        /// <summary>
        /// Shots that were made during the game
        /// </summary>
        private List<IShot> _shots = new List<IShot>();

        /// <summary>
        /// Current state of the game
        /// </summary>
        private GameState _state;

        /// <summary>
        /// Game id
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
        /// Battlefield on which the game will take place
        /// </summary>
        public IBattleField BattleField
        {
            get
            {
                return _battleField;
            }
            set 
            {
                if (value != null)
                {
                    _battleField = value;
                }
            }
        }

        /// <summary>
        /// Id of the battlefield
        /// </summary>
        public int BattleFieldId
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

        /// <summary>
        /// BattleShips in the game
        /// </summary>
        public IEnumerable<IGameBattleShip> GameBattleShips
        {
            get 
            {
                return _gameBattleShips;
            }
            set
            {
                if (value != null)
                {
                    _gameBattleShips = value;
                }
            }
        }

        /// <summary>
        /// Shots that were made during the game
        /// </summary>
        public IEnumerable<IShot> Shots
        {
            get
            {
                return _shots;
            }
            set
            {
                if (value != null)
                {
                    _shots = value;
                }
            }
        }

        /// <summary>
        /// Current state of the game
        /// </summary>
        public GameState State
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

        #endregion

        #region constructor

        /// <summary>
        /// Parameterless constructor of the game
        /// </summary>
        public Game()
        { 
        }

        /// <summary>
        /// Constructor of the game
        /// </summary>
        /// <param name="battleField">Battlefield on which the game will take place</param>
        public Game(IBattleField battleField)
        {
            _battleField = battleField;
            _gameState = Game.State.Started;
            GenerateGameBattleShips(battleField);
        }

        #endregion

        #region public methods
        
        public static IGame GetById(int id)
        {
            using (NavyBattleContext dv = new NavyBattleContext)
            {
                
            }

                return game;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Generating battleships for the game
        /// </summary>
        /// <param name="battleField">Battlefield which battleships will be used in the game</param>
        private void GenerateGameBattleShips(IBattleField battleField)
        {            
            foreach (var battleShip in battleField.Battleships)
            {
                _gameBattleShips.Add(new GameBattleShip(this, battleShip));
            }
        }

        #endregion
    }
}
