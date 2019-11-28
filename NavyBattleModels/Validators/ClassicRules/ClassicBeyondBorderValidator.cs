using System;
using System.Collections.Generic;
using System.Text;
using NavyBattleModels.Resources;

namespace NavyBattleModels.Validators
{
    /// <summary>
    /// Class to validate that position of the battleship is not beyond the border
    /// </summary>
    public class ClassicBeyondBorderValidator: IBattleValidator
    {
        /// <summary>
        /// Validate battleships to match rules
        /// </summary>
        /// <param name="battleShips"></param>
        /// <returns></returns>
        public Dictionary<Point,string> Validate(List<BattleShip> battleShips)
        {
            var resultErrors = new Dictionary<Point, string>();

            foreach (var battleShip in battleShips)
            {
                var endPoint = battleShip.GetEndPoint();
                var startPoint = battleShip.StartPoint;
                if(startPoint.X >= 1 && startPoint.X <= 10 && startPoint.Y >= 1 && startPoint.Y <= 10)
                {
                    continue;
                }
                resultErrors.Add(startPoint, Resource.BeyondBorderValidator_Error);
            }

            return resultErrors;
        }
    }
}
