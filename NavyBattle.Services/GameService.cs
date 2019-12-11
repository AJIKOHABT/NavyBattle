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
    /// Service to work with battlefields
    /// </summary>
    public class GameService : IGameService
    {
        #region fields and properties

        /// <summary>
        /// Class to work with database
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        /// <summary>
        /// Service to work with battlefields
        /// </summary>
        /// <param name="unitOfWork">Class to work with database</param>
        public BattleFieldService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
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
            var battleField = _unitOfWork.BattleFieldRepository.GetById(id);

            var game = new Game(battleField);
            _unitOfWork.GameRepository.Add(game);
            _unitOfWork.Commit();

            _unitOfWork.GameBattleShipRepository.AddRange(game.GameBattleShips);
            _unitOfWork.Commit();

            return game;
        }

        /// <summary>
        /// Getting battlefield by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IGame GetById(int id)
        {
            return _unitOfWork.GameRepository.GetById(id);
        }

        /// <summary>
        /// Getting all battlefields from the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGame> GetAll()
        {
            return _unitOfWork.GameRepository.GetAll();
        }

        /// <summary>
        /// Getting result of shot
        /// </summary>
        /// <param name="shot"></param>
        /// <returns></returns>
        public IShot FireShot(IShot shot)
        {
            var game = GetById(shot.GameId);
            var battleShips = game.GameBattleShips;
           
                        
            _unitOfWork.ShotRepository.Add(shot);
            _unitOfWork.Commit();
            return shot;
        }

        #endregion
    }
}
