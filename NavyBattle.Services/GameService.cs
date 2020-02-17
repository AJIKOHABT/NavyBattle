using System;
using System.Collections.Generic;
using System.Linq;
using NavyBattleModels;
using NavyBattleModels.Enums;
using NavyBattleModels.Interfaces;
using NavyBattleModels.Models;
using NavyBattleModels.Services;
using NavyBattleModels.Validators;
using NavyBattleModels.Validators.Interfaces;

namespace NavyBattle.Services
{
    /// <summary>
    /// Service to work with game
    /// </summary>
    internal class GameService : IGameService
    {
        #region fields and properties

        /// <summary>
        /// Repository class to work with battlefield objectcs in database
        /// </summary>
        IBaseRepository<GameBattleField> _gameBattleFieldRepository;

        /// <summary>
        /// Repository class to work with game objectcs in database
        /// </summary>
        IBaseRepository<Game> _gameRepository;

        /// <summary>
        /// Repository class to work with battleship objectcs from the game in database
        /// </summary>
        IBaseRepository<GameBattleShip> _gameBattleShipRepository;

        /// <summary>
        /// Repository class to work with shot objectcs in database
        /// </summary>
        IBaseRepository<Shot> _shotRepository;

        /// <summary>
        /// Repository class to work with battlefield objectcs in database
        /// </summary>
        IBaseRepository<BaseBattleField> _battleFieldRepository;

        /// <summary>
        /// Repository class to work with battleship objectcs in database
        /// </summary>
        IBaseRepository<BattleShip> _battleShipRepository;

        /// <summary>
        /// Repository class to work with battleship objectcs in database
        /// </summary>
        IBaseRepository<User> _userRepository;

        #endregion

        #region Constructor

        /// <summary>
        /// Service to work with battlefields
        /// </summary>
        /// <param name="battleFieldRepository">Repository class to work with battlefield objectcs in database</param>
        /// <param name="gameRepository">Repository class to work with game objectcs in database</param>
        /// <param name="gameBattleShipRepository">Repository class to work with battleship objectcs from the game in database</param>
        /// <param name="shotRepository">Repository class to work with shot objectcs in database</param>
        public GameService(IBaseRepository<GameBattleField> gameBattleFieldRepository, 
            IBaseRepository<Game> gameRepository,
            IBaseRepository<GameBattleShip> gameBattleShipRepository,
            IBaseRepository<Shot> shotRepository,
            IBaseRepository<User> userRepository)
        {
            this._gameBattleFieldRepository = gameBattleFieldRepository;
            this._gameRepository = gameRepository;
            this._gameBattleShipRepository = gameBattleShipRepository;
            this._shotRepository = shotRepository;
            this._userRepository = userRepository;
        }

        #endregion

        #region IGameService

        /// <summary>
        /// Getting battlefield by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Game GetById(int id)
        {
            return _gameRepository.GetById(id);
        }

        /// <summary>
        /// Getting all battlefields from the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Game> GetAll()
        {
            return _gameRepository.GetAll();
        }

        /// <summary>
        /// Creating gameBattleField for the player
        /// </summary>
        /// <param name="battleFieldId"></param>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public BattleFieldResult CreateGameBattleField(int battleFieldId, int ownerId)
        {
            var owner = _userRepository.GetById(ownerId);
            var result = new BattleFieldResult();

            if (owner == null)
            {
                result.IsError = true;
                result.ErrorMessage = "There is no user with such Id";
                return result;
            }

            var battleField = _battleFieldRepository.GetById(battleFieldId);

            if(battleField == null)
            {
                result.IsError = true;
                result.ErrorMessage = "There is no battlefield with such Id";
                return result;
            }

            var gameBattleField = new GameBattleField(battleField);
            gameBattleField.Owner = (User)owner;

            _gameBattleFieldRepository.Add(gameBattleField);
            _gameBattleFieldRepository.Save();

            _gameBattleShipRepository.AddRange(gameBattleField.GameBattleShips);
            _gameBattleShipRepository.Save();

            result.IsWaiting = true;
            result.GameBattleFieldId = gameBattleField.Id;

            return result;
        }

        /// <summary>
        /// Waiting for other player to start the game
        /// </summary>
        /// <param name="gameBattleFieldId"></param>
        /// <returns></returns>
        public BattleFieldResult WaitingForPlayer(int gameBattleFieldId)
        {
            var result = new BattleFieldResult();
            var userGameBattleField = _gameBattleFieldRepository.GetById(gameBattleFieldId);

            if (userGameBattleField == null)
            {
                result.IsError = true;
                result.ErrorMessage = "There is no gameBattlefield with such Id";
                result.GameBattleFieldId = gameBattleFieldId;
                return result;
            }

            if (!userGameBattleField.IsWaiting)
            {
                result.GameBattleFieldId = userGameBattleField.Id;
                result.GameId = userGameBattleField.GameId;
                return result;
            }

            var gameBattleField = _gameBattleFieldRepository.GetAll().
                FirstOrDefault(gb=> gb.IsWaiting && gb.Id != gameBattleFieldId);

            if (gameBattleField == null)
            {
                result.IsWaiting = true;
                result.GameBattleFieldId = gameBattleFieldId;
                return result;
            }

            var gameBattleFields = new List<GameBattleField>()
                    {
                        userGameBattleField,
                        gameBattleField
                    };

            result.GameId = CreateGame(gameBattleFields);
            return result;
        }

        /// <summary>
        /// Checking for whos turn now
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="gameId"></param>
        /// <returns></returns>
        public GameResult CheckForUsersTurn(int userId, int gameId)
        {
            var result = new GameResult();
            result.GameId = gameId;
            var game = GetById(gameId);

            if (game == null)
            {
                result.IsError = true;
                result.ErrorMessage = "There is no game with such id";
                return result;
            }
                        
            result.GameState = game.State;
            result.WhosTurn = game.TurnOfThePlayer;
            var usersBattleField = game.GameBattleFields.FirstOrDefault(gbf=>gbf.OwnerId == userId);
            result.Shots = usersBattleField.Shots;

            if (game.State == GameState.Finished)
            {
                result.Winner = game.Winner;
            }
                      
            return result;
        }

        /// <summary>
        /// Getting result of shot
        /// </summary>
        /// <param name="shot"></param>
        /// <returns></returns>
        public ShotResult FireShot(Shot shot)
        {
            var game = _gameRepository.GetById(shot.GameId.Value);            
            var shotValidator = new ShotValidator();
            var result = shotValidator.Validate(game, shot);

            if (result.IsSuccess)
            {
                if (game.State == GameState.Finished)
                {
                    game.Winner = (User)_userRepository.GetById(shot.PlayerId.Value);
                    _gameRepository.Update(game);
                    _gameRepository.Save();
                }

                _shotRepository.Add(result.Shot);
                _shotRepository.Save();                

                _gameBattleShipRepository.Update(result.GameBattleShip);
                _gameBattleShipRepository.Save();
            }           

            return result;
        }

        #endregion

        #region private methods  

        /// <summary>
        /// Creating game and adding it to database
        /// </summary>
        /// <param name="gameBattleFields"></param>
        /// <returns></returns>
        private int CreateGame(IEnumerable<GameBattleField> gameBattleFields)
        {
            var game = new Game(gameBattleFields);
            game.State = GameState.WaitingForShot;

            _gameRepository.Add(game);
            _gameRepository.Save();

            foreach (var gameBf in game.GameBattleFields)
            {
                gameBf.IsWaiting = false;
                _gameBattleFieldRepository.Update(gameBf);
                _gameBattleFieldRepository.Save();
            }
            return game.Id;
        }

        #endregion
    }
}
