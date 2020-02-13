using System.Collections.Generic;
using NavyBattleModels;
using NavyBattleModels.Interfaces;
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
        IBaseRepository<IBattleField> _battleFieldRepository;

        /// <summary>
        /// Repository class to work with battleship objectcs in database
        /// </summary>
        IBaseRepository<IBattleShip> _battleShipRepository;

        #endregion

        #region Constructor

        /// <summary>
        /// Service to work with battlefields
        /// </summary>
        /// <param name="battleFieldRepository">Repository class to work with battlefield objectcs in database</param>
        /// <param name="battleShipRepository">Repository class to work with battleship objectcs in database</param>
        public BattleFieldService(IBaseRepository<IBattleField> battleFieldRepository, IBaseRepository<IBattleShip> battleShipRepository)
        {
            this._battleFieldRepository = battleFieldRepository;
            this._battleShipRepository = battleShipRepository;
        }

        #endregion

        #region IBattleFieldService

        /// <summary>
        /// Validating and creating battlefield
        /// </summary>
        /// <param name="battleShips"></param>
        /// <returns></returns>
        public IBattleFieldValidationResult CreateBattleField(IEnumerable<IBattleShip> battleShips)
        {
            var battleField = new ClassicBattleField();
            battleField.AddBattleShips(battleShips);

            var validator = new ClassicBattleFieldValidator();
            var result = validator.Validate(battleField);
            if (result.IsSuccess)
            {
                _battleFieldRepository.Add(battleField);
                _battleFieldRepository.Save();

                _battleShipRepository.AddRange(battleField.BattleShips);
                _battleShipRepository.Save();

                result.BattleFieldId = battleField.Guid;
            }

            return result;
        }

        /// <summary>
        /// Getting battlefield by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IBattleField GetById(int id)
        {
            return _battleFieldRepository.GetById(id);
        }

        /// <summary>
        /// Getting all battlefields from the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IBattleField> GetAll()
        {
            return _battleFieldRepository.GetAll();
        }

        #endregion
    }
}
