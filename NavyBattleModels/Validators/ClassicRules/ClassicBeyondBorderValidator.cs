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
        /// <param name="battleShips">List of battleships on the battlefield</param>
        /// <returns>IEnumerable of errors</returns>
        public IEnumerable<BattleFieldError> Validate(IEnumerable<IBattleShip> battleShips)
        {
            var resultErrors = new List<BattleFieldError>();

            foreach (var battleShip in battleShips)
            {
                var endPoint = battleShip.GetEndPoint();
                var startPoint = battleShip.StartPoint;
                if(startPoint.X >= 1 && startPoint.X <= 10 && startPoint.Y >= 1 && startPoint.Y <= 10)
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
