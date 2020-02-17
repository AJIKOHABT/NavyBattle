using System.Collections.Generic;
using NavyBattleModels;
using NavyBattleModels.Errors;
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
    internal class BattleFieldService : IBattleFieldService
    {
        #region fields and properties

        /// <summary>
        /// Repository class to work with battlefield objectcs in database
        /// </summary>
        IBaseRepository<BaseBattleField> _battleFieldRepository;

        /// <summary>
        /// Repository class to work with battleship objectcs in database
        /// </summary>
        IBaseRepository<BattleShip> _battleShipRepository;

        IBaseRepository<User> _userRepository;

        #endregion

        #region Constructor

        /// <summary>
        /// Service to work with battlefields
        /// </summary>
        /// <param name="battleFieldRepository">Repository class to work with battlefield objectcs in database</param>
        /// <param name="battleShipRepository">Repository class to work with battleship objectcs in database</param>
        public BattleFieldService(IBaseRepository<BaseBattleField> battleFieldRepository, 
            IBaseRepository<BattleShip> battleShipRepository, 
            IBaseRepository<User> userRepository)
        {
            this._battleFieldRepository = battleFieldRepository;
            this._battleShipRepository = battleShipRepository;
            this._userRepository = userRepository;
        }

        #endregion

        #region IBattleFieldService

        /// <summary>
        /// Validating and creating battlefield
        /// </summary>
        /// <param name="battleShips"></param>
        /// <returns></returns>
        public BattleFieldValidationResult CreateBattleField(int userId, IEnumerable<BattleShip> battleShips)
        {
            var user = _userRepository.GetById(userId);         

            var battleField = new ClassicBattleField();
            battleField.AddBattleShips(battleShips);

            var validator = new ClassicBattleFieldValidator();
            var result = validator.Validate(battleField);
            if (result.IsSuccess)
            {

                battleField.Owner = (User)user;
                _battleFieldRepository.Add(battleField);
                _battleFieldRepository.Save();

                _battleShipRepository.AddRange(battleField.BattleShips);
                _battleShipRepository.Save();

                result.BattleFieldId = battleField.Id;
            }

            return (BattleFieldValidationResult)result;
        }

        /// <summary>
        /// Getting battlefield by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BaseBattleField GetById(int id)
        {
            return _battleFieldRepository.GetById(id);
        }

        /// <summary>
        /// Getting all battlefields from the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BaseBattleField> GetAll()
        {
            return _battleFieldRepository.GetAll();
        }

        #endregion
    }
}
