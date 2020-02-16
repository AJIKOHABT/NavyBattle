using System;
using System.Collections.Generic;
using NavyBattleModels.Interfaces;
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
        /// Current state of the game
        /// </summary>
        private GameState _state;

        /// <summary>
        /// List of the battlefields using in the game
        /// </summary>
        private List<GameBattleField> _gameBattleFields = new List<GameBattleField>();

        /// <summary>
        /// Winner of the game
        /// </summary>
        private User _winner;

        /// <summary>
        /// Winner id
        /// </summary>
        private int? _winnerId;

        /// <summary>
        /// Whos turn now
        /// </summary>
        private int? _turnOfThePlayer;

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

        /// <summary>
        /// List of the battlefields using in the game
        /// </summary>
        public IEnumerable<GameBattleField> GameBattleFields
        {
            get
            {
                return _gameBattleFields;
            }
            set
            {
                if (value != null)
                {
                    _gameBattleFields = (List<GameBattleField>)value;
                }
            }
        }

        /// <summary>
        /// Winner of the game
        /// </summary>
        public User Winner
        {
            get
            {
                return _winner;
            }
            set
            {
                _winner = value;
            }
        }

        /// <summary>
        /// Winner id
        /// </summary>
        public int? WinnerId
        {
            get
            {
                return _winnerId;
            }
            set
            {
                _winnerId = value;
            }
        }

        /// <summary>
        /// Whos turn now
        /// </summary>
        public int? TurnOfThePlayer
        {
            get
            {
                return _turnOfThePlayer;
            }
            set
            {
                _turnOfThePlayer = value;
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
        public Game(IEnumerable<IGameBattleField> gameBattleFields)
        {
            foreach (var gameBattleField in gameBattleFields)
            {
                gameBattleField.Game = this;
                _gameBattleFields.Add((GameBattleField)gameBattleField);
            }
            _state = GameState.Started;
            Random random = new Random();
            _turnOfThePlayer = random.Next(0, 1000000) < 500000 ? _gameBattleFields[0].OwnerId : _gameBattleFields[1].OwnerId;          

        }

        #endregion

    }
}
