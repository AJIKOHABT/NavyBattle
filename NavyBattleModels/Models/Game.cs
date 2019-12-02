using System;
using System.Collections.Generic;
using System.Text;
using NavyBattleModels.Interfaces;

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
        /// BattleShips in the game
        /// </summary>
        private IEnumerable<IGameBattleShip> _gameBattleShips = new List<IGameBattleShip>();

        /// <summary>
        /// Shots that were made during the game
        /// </summary>
        private IEnumerable<IShot> _shots = new List<IShot>();

        /// <summary>
        /// Game id
        /// </summary>
        public int Id
        {
            get 
            {
                return _id;
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
        }
        #endregion

        #region constructor

        /// <summary>
        /// Constructor of the game
        /// </summary>
        /// <param name="battleField">Battlefield on which the game will take place</param>
        public Game(IBattleField battleField)
        {
            _battleField = battleField;
            GenerateGameBattleShips(battleField);
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
