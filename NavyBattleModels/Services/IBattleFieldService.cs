using NavyBattleModels.Interfaces;
using NavyBattleModels.Validators.Interfaces;
using System.Collections.Generic;

namespace NavyBattleModels.Services
{
    public interface IBattleFieldService
    {
        /// <summary>
        /// Validating and creating battlefield
        /// </summary>
        /// <param name="battleShips"></param>
        /// <returns></returns>
        IBattleFieldValidationResult CreateBattleField(IEnumerable<IBattleShip> battleShips);

        /// <summary>
        /// Getting battlefield by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IBattleField GetById(int id);

        /// <summary>
        /// Getting all battlefields from the database
        /// </summary>
        /// <returns></returns>
        IEnumerable<IBattleField> GetAll();
    }
}
