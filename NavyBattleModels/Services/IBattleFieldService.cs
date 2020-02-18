using NavyBattleModels.Validators;
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
        BattleFieldValidationResult CreateBattleField(int userId, IEnumerable<BattleShip> battleShips);

        /// <summary>
        /// Getting battlefield by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BaseBattleField GetById(int id);

        /// <summary>
        /// Getting all battlefields from the database
        /// </summary>
        /// <returns></returns>
        IEnumerable<BaseBattleField> GetAll();

        /// <summary>
        /// Delete battlefield
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
