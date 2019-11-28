using System;
using System.Collections.Generic;
using System.Text;

namespace NavyBattleModels.Validators
{
    /// <summary>
    /// Class to validate the number and types of the battleships
    /// </summary>
    public class ClassicBattleShipsValidator: IBattleShipsValidator
    {
        public Dictionary<Point, string> Validate(List<BattleShip> battleShips)
        {
            var resultErrors = new Dictionary<Point, string>();
            resultErrors.AddRange(GetNonValidTypeErrors(battleShips));

            return resultErrors;
        }

        #region private methods

        /// <summary>
        /// Getting non valid type battleships
        /// </summary>
        /// <param name="battleShips"></param>
        /// <returns></returns>
        private Dictionary<Point, string> GetNonValidTypeErrors(List<BattleShip> battleShips)
        {
            var resultErrors = new Dictionary<Point, string>();
            foreach (var battleShip in battleShips)
            {
                if (!(battleShip.Length > 4) && !(battleShip.Length<1))
                {
                    continue;
                }
                var errorText = string.Format(Resource.BattleShipsValidator_LengthError, battleShip.Length);
                resultErrors.Add(battleShip.StartPont, errorText);
            }
            return resultErrors;
        }

        private Dictionary<Point, string> GetNonValidBattleshipsCount(List<BattleShip> battleShips)
        {
            ///TODO: завести отдельный enum для хранения типа кораблей и их количества к примеру ClassicBattleShipsTypesCount
            var resultErrors = new Dictionary<Point, string>();
            var defaultPoint = new Point(0, 0);
            var battleshipActualCount = battleShips.Count(battleShip => battleShip.Length == ClassicBattleShipTypesLength.BattleShip);
            var cruiserActualCount = battleShips.Count(battleShip => battleShip.Length == ClassicBattleShipTypesLength.Cruiser);
            var destroyerActualCount = battleShips.Count(battleShip => battleShip.Length == ClassicBattleShipTypesLength.Destroyer);
            var mosquitoActualCount = battleShips.Count(battleShip => battleShip.Length == ClassicBattleShipTypesLength.Mosquito);
            string errorText;
            if (battleshipActualCount > 1)
            {
                errorText = string.Format(Resource.BattleShipsValidator_BattleShipCountError, _battleShipValidCount, Resource.BattleShipsValidator_Battleship, battleshipActualCount);
                resultErrors.Add(defaultPoint, )
            }
            if (battleshipActualCount > 1)
            {
                errorText = string.Format(Resource.BattleShipsValidator_BattleShipCountError, _battleShipValidCount, Resource.BattleShipsValidator_Battleship, battleshipActualCount);
                resultErrors.Add(defaultPoint, )
            }
            if (battleshipActualCount > 1)
            {
                errorText = string.Format(Resource.BattleShipsValidator_BattleShipCountError, _battleShipValidCount, Resource.BattleShipsValidator_Battleship, battleshipActualCount);
                resultErrors.Add(defaultPoint, )
            }
            if (battleshipActualCount > 1)
            {
                errorText = string.Format(Resource.BattleShipsValidator_BattleShipCountError, _battleShipValidCount, Resource.BattleShipsValidator_Battleship, battleshipActualCount);
                resultErrors.Add(defaultPoint, )
            }
            return resultErrors;
        }

        #endregion

    }
}
