using NavyBattleModels.Interfaces;
using System;
using System.Collections.Generic;

namespace NavyBattleModels.Models
{
    public class GameBattleField : IGameBattleField
    {

        /// <summary>
        /// Battlefield
        /// </summary>
        private IBattleField _battleField;

        /// <summary>
        /// BattleShips in the game
        /// </summary>
        private List<IGameBattleShip> _gameBattleShips = new List<IGameBattleShip>();

        /// <summary>
        /// Game battlefield id
        /// </summary>
        public Guid Guid { get; set; }

        /// <summary>
        /// Battlefield on which the game will take place
        /// </summary>
        public IBattleField BattleField { get; set; }

        /// <summary>
        /// Id of the battlefield
        /// </summary>
        public Guid BattleFieldId { get; set; }

        /// <summary>
        /// Game which this battlefield is added to
        /// </summary>
        public IGame Game { get; set; }

        /// <summary>
        /// Id of the game which this battlefield is added to
        /// </summary>
        public Guid GameId { get; set; }

        /// <summary>
        /// Player owner of this battlefield
        /// </summary>
        public IUser Owner { get; set; }

        /// <summary>
        /// Id of the player owner of this battlefield
        /// </summary>
        public Guid OwnerId { get; set; }

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
                    _gameBattleShips = (List<IGameBattleShip>)value;
                }
            }
        }

        /// <summary>
        /// Shots that were made during the game                                                                                                                                                                                                                                                                                                                     
        /// </summary>
        public IEnumerable<IShot> Shots { get; set; }

        public GameBattleField()
        { 

        }

        public GameBattleField(IBattleField battleField)
        {
            _battleField = battleField;
            GenerateGameBattleShips(battleField);            
        }

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
