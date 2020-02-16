using NavyBattleModels.Interfaces;
using System;
using System.Collections.Generic;

namespace NavyBattleModels.Models
{
    public class GameBattleField : IGameBattleField
    {
        #region properties and fields

        /// <summary>
        /// Battlefield
        /// </summary>
        private BaseBattleField _battleField;

        /// <summary>
        /// BattleShips in the game
        /// </summary>
        private List<GameBattleShip> _gameBattleShips = new List<GameBattleShip>();

        /// <summary>
        /// Flag to indicate that battlefield is ready to play
        /// </summary>
        private bool _isWaiting;

        /// <summary>
        /// Game battlefield id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Battlefield on which the game will take place
        /// </summary>
        public BaseBattleField BattleField { get; set; }

        /// <summary>
        /// Id of the battlefield
        /// </summary>
        public int? BattleFieldId { get; set; }

        /// <summary>
        /// Game which this battlefield is added to
        /// </summary>
        public Game Game { get; set; }

        /// <summary>
        /// Id of the game which this battlefield is added to
        /// </summary>
        public int? GameId { get; set; }

        /// <summary>
        /// Player owner of this battlefield
        /// </summary>
        public User Owner { get; set; }

        /// <summary>
        /// Id of the player owner of this battlefield
        /// </summary>
        public int? OwnerId { get; set; }

        /// <summary>
        /// Flag to indicate that battlefield is ready to play
        /// </summary>
        public bool IsWaiting 
        {
            get 
            {
                return _isWaiting;
            }
            set 
            {
                _isWaiting = value;
            }
        }

        /// <summary>
        /// BattleShips in the game
        /// </summary>
        public IEnumerable<GameBattleShip> GameBattleShips
        {
            get
            {
                return _gameBattleShips;
            }
            set
            {
                if (value != null)
                {
                    _gameBattleShips = (List<GameBattleShip>)value;
                }
            }
        }

        /// <summary>
        /// Shots that were made during the game                                                                                                                                                                                                                                                                                                                     
        /// </summary>
        public IEnumerable<Shot> Shots { get; set; }

        #endregion

        #region constructor

        /// <summary>
        /// GameBattleField constructor
        /// </summary>
        public GameBattleField()
        { 

        }

        /// <summary>
        /// GameBattleField constructor
        /// </summary>
        /// <param name="battleField">battlefield which is used for game</param>
        /// <param name="isWaiting">flag to indicate that battlefield is ready to play</param>
        public GameBattleField(IBattleField battleField, bool isWaiting = true)
        {
            _battleField = (BaseBattleField)battleField;
            GenerateGameBattleShips(battleField);
            _isWaiting = isWaiting;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Generating battleships for the game
        /// </summary>
        /// <param name="battleField">Battlefield which battleships will be used in the game</param>
        private void GenerateGameBattleShips(IBattleField battleField)
        {
            foreach (var battleShip in battleField.BattleShips)
            {
                _gameBattleShips.Add(new GameBattleShip(this, battleShip));
            }
        }

        #endregion
    }
}
