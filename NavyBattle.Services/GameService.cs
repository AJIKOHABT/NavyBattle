using System.Collections.Generic;
using NavyBattleModels;
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
        IBaseRepository<IBattleField> _battleFieldRepository;

        /// <summary>
        /// Repository class to work with game objectcs in database
        /// </summary>
        IBaseRepository<IGame> _gameRepository;

        /// <summary>
        /// Repository class to work with battleship objectcs from the game in database
        /// </summary>
        IBaseRepository<IGameBattleShip> _gameBattleShipRepository;

        /// <summary>
        /// Repository class to work with shot objectcs in database
        /// </summary>
        IBaseRepository<IShot> _shotRepository;

        #endregion

        #region Constructor

        /// <summary>
        /// Service to work with battlefields
        /// </summary>
        /// <param name="battleFieldRepository">Repository class to work with battlefield objectcs in database</param>
        /// <param name="gameRepository">Repository class to work with game objectcs in database</param>
        /// <param name="gameBattleShipRepository">Repository class to work with battleship objectcs from the game in database</param>
        /// <param name="shotRepository">Repository class to work with shot objectcs in database</param>
        public GameService(IBaseRepository<IBattleField> battleFieldRepository, IBaseRepository<IGame> gameRepository, IBaseRepository<IGameBattleShip> gameBattleShipRepository, IBaseRepository<IShot> shotRepository)
        {
            this._battleFieldRepository = battleFieldRepository;
            this._gameRepository = gameRepository;
            this._gameBattleShipRepository = gameBattleShipRepository;
            this._shotRepository = shotRepository;
        }

        #endregion

        #region IGameService

        /// <summary>
        /// Validating and creating battlefield
        /// </summary>
        /// <param name="id">id of the chosen battlefield</param>
        /// <returns></returns>
        public IGame CreateGame(int id)
        {
            var battleField = _battleFieldRepository.GetById(id);

            var game = new Game(battleField);
            _gameRepository.Add(game);
            _gameRepository.Save();

            _gameBattleShipRepository.AddRange(game.GameBattleShips);
            _gameBattleShipRepository.Save();

            return game;
        }

        /// <summary>
        /// Getting battlefield by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IGame GetById(int id)
        {
            return _gameRepository.GetById(id);
        }

        /// <summary>
        /// Getting all battlefields from the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGame> GetAll()
        {
            return _gameRepository.GetAll();
        }

        /// <summary>
        /// Getting result of shot
        /// </summary>
        /// <param name="shot"></param>
        /// <returns></returns>
        public IShotResult FireShot(IShot shot)
        {
            var game = GetById(shot.GameId);
            var shotValidator = new ShotValidator();
            var result = shotValidator.Validate(game, shot);

            if (result.IsSuccess)
            {
                if (game.State == GameState.Finished)
                {
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
    }
}
