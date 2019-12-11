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
    public class BattleFieldService : IBattleFieldService
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
                _unitOfWork.BattleFieldRepository.Add(battleField);
                _unitOfWork.Commit();

                _unitOfWork.BattleShipRepository.AddRange(battleField.BattleShips);
                _unitOfWork.Commit();

                result.BattleFieldId = battleField.Id;
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
            return _unitOfWork.BattleFieldRepository.GetById(id);
        }

        /// <summary>
        /// Getting all battlefields from the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IBattleField> GetAll()
        {
            return _unitOfWork.BattleFieldRepository.GetAll();
        }

        #endregion
    }
}
