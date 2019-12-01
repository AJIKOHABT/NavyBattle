using System.Collections.Generic;
using NavyBattleModels.Validators.Interfaces;
using NavyBattleModels.Errors;
using NavyBattleModels.Enums;
using NavyBattleModels.Interfaces;

namespace NavyBattleModels.Validators
{
    /// <summary>
    /// Class to validate that position of the battleship is not beyond the border
    /// </summary>
    public class ClassicBeyondBorderValidator: IBattleShipValidator
    {

        #region IBattleValidator

        /// <summary>
        /// Validate battleships to match rules
        /// </summary>
        /// <param name="battleField">Battlefield to validate</param>
        /// <returns>IEnumerable of errors</returns>
        public IEnumerable<BattleFieldError> Validate(IBattleField battleField)
        {
            var resultErrors = new List<BattleFieldError>();

            foreach (var battleShip in battleField.Battleships)
            {
                var endPoint = battleShip.GetEndPoint();
                var startPoint = battleShip.StartPoint;
                if(startPoint.X >= 1 && startPoint.X <= battleField.Width && startPoint.Y >= 1 && startPoint.Y <= battleField.Width)
                {
                    continue;
                }
                resultErrors.Add(new BattleFieldError(BattlefieldErrorTypes.BattleShipOutOfBorder, startPoint));                    
            }

            return resultErrors;
        }

        #endregion

    }
}
