using System;
using System.Collections.Generic;
using System.Linq;
using NavyBattleModels.Enums;
using NavyBattleModels.Resources;
using NavyBattleModels.Validators.Interfaces;
using NavyBattleModels.Errors;
using NavyBattleModels.Interfaces;

namespace NavyBattleModels.Validators
{
    /// <summary>
    /// Class to validate the number and types of the battleships
    /// </summary>
    public class ClassicBattleShipsValidator: IBattleShipValidator
    {

        #region fields and properties

        /// <summary>
        /// List of errors
        /// </summary>
        private IEnumerable<IBattleFieldError> _resultErrors;

        #endregion

        #region IBattleValidator

        /// <summary>
        /// Validate battleships to match rules
        /// </summary>
        /// <param name="battleField">Battlefield to validate</param>
        /// <returns>IEnumerable of errors</returns>
        public IEnumerable<IBattleFieldError> Validate(IBattleField battleField)
        {
            _resultErrors = new List<IBattleFieldError>();

            GetNonValidTypeErrors(battleField.BattleShips);
            GetNonValidBattleshipsCount(battleField.BattleShips);                             

            return _resultErrors;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Getting non valid type battleships
        /// </summary>
        /// <param name="battleShips"></param>
        /// <returns></returns>
        private void GetNonValidTypeErrors(IEnumerable<IBattleShip> battleShips)
        {
            if (_resultErrors == null)
            {
                _resultErrors = new List<BattleFieldError>();
            }
            foreach (var battleShip in battleShips)
            {
                if (!(battleShip.Length > 4) && !(battleShip.Length<1))
                {
                    continue;
                }
                var errorText = string.Format(Resource.BattleShipsValidator_LengthError, battleShip.Length);
                _resultErrors.Append(new BattleFieldError(BattlefieldErrorTypes.BattleShipNonValidLength, battleShip.StartPoint));                
            }
        }

        /// <summary>
        /// Getting non valid battleships count for different types
        /// </summary>
        /// <param name="battleShips"></param>
        /// <returns></returns>
        private void GetNonValidBattleshipsCount(IEnumerable<IBattleShip> battleShips)
        {
            if (_resultErrors == null)
            {
                _resultErrors = new List<BattleFieldError>();
            }

            var classicBattleShipLength = new Dictionary<ClassicBattleShipType, int>
            {
                {ClassicBattleShipType.Mosquito, 1},
                {ClassicBattleShipType.Destroyer, 2},
                {ClassicBattleShipType.Cruiser, 3},
                {ClassicBattleShipType.Battleship, 4}
            };
            var classicBattleShipCnt = new Dictionary<ClassicBattleShipType, int>
            {
                {ClassicBattleShipType.Mosquito, 4},
                {ClassicBattleShipType.Destroyer, 3},
                {ClassicBattleShipType.Cruiser, 2},
                {ClassicBattleShipType.Battleship, 1}
            };

            foreach (var classicLength in classicBattleShipLength)
            {
                var actualCnt = battleShips.Count(battleShip => battleShip.Length == classicLength.Value);
                if (actualCnt != classicBattleShipCnt[classicLength.Key])
                {
                    _resultErrors.Append(new BattleFieldError(BattlefieldErrorTypes.BattleShipNonValidCount));
                }
            }            
        }

        #endregion

    }
}
