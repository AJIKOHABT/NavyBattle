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
        private IEnumerable<BattleFieldError> _resultErrors;

        #endregion

        #region IBattleValidator

        /// <summary>
        /// Validate battleships to match rules
        /// </summary>
        /// <param name="battleShips">List of battleships on the battlefield</param>
        /// <returns>IEnumerable of errors</returns>
        public IEnumerable<BattleFieldError> Validate(IEnumerable<IBattleShip> battleShips)
        {
            _resultErrors = new List<BattleFieldError>();

            GetNonValidTypeErrors(battleShips);
            GetNonValidBattleshipsCount(battleShips);                             

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
            foreach (var battleShipLength in (int[]) Enum.GetValues(typeof(ClassicBattleShipTypesLength)))
            {
                var name = Enum.GetName(typeof(ClassicBattleShipTypesLength), battleShipLength);
                var actualCnt = battleShips.Count(battleShip => battleShip.Length == battleShipLength);
                var validCnt = (int)Enum.Parse(typeof(ClassicBattleShipTypesCount), name);
                if (actualCnt != validCnt)
                {
                    _resultErrors.Append(new BattleFieldError(BattlefieldErrorTypes.BattleShipNonValidCount));
                }
            }
        }

        #endregion

    }
}
