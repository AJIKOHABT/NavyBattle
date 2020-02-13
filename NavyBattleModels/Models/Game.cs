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
        private Guid _guid;

        /// <summary>
        /// Current state of the game
        /// </summary>
        private GameState _state;

        /// <summary>
        /// List of the battlefields using in the game
        /// </summary>
        private List<IGameBattleField> _gameBattleFields = new List<IGameBattleField>();

        /// <summary>
        /// Winner of the game
        /// </summary>
        private IUser _winner;

        /// <summary>
        /// Winner id
        /// </summary>
        private Guid _winnerId;

        /// <summary>
        /// Whos turn now
        /// </summary>
        private Guid _turnOfThePlayer;

        /// <summary>
        /// Game id
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
        public IEnumerable<IGameBattleField> GameBattleFields
        {
            get
            {
                return _gameBattleFields;
            }
            set
            {
                if (value != null)
                {
                    _gameBattleFields = (List<IGameBattleField>)value;
                }
            }
        }

        /// <summary>
        /// Winner of the game
        /// </summary>
        public IUser Winner
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
        public Guid WinnerId
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
        public Guid TurnOfThePlayer
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
        public Game(IBattleField battleField)
        {          
            _state = GameState.Started;            
        }

        #endregion

    }
}
