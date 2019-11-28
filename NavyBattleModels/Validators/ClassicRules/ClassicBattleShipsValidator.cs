using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NavyBattleModels.Enums;
using NavyBattleModels.Resources;

namespace NavyBattleModels.Validators
{
    /// <summary>
    /// Class to validate the number and types of the battleships
    /// </summary>
    public class ClassicBattleShipsValidator: IBattleValidator
    {

        #region IBattleValidator

        /// <summary>
        /// Validate battleships to match rules
        /// </summary>
        /// <param name="battleShips"></param>
        /// <returns></returns>
        public Dictionary<Point, string> Validate(List<BattleShip> battleShips)
        {
            var resultErrors = new Dictionary<Point, string>();
            resultErrors.Concat(GetNonValidTypeErrors(battleShips));
            resultErrors.Concat(GetNonValidBattleshipsCount(battleShips));                             

            return resultErrors;
        }

        #endregion

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
                resultErrors.Add(battleShip.StartPoint, errorText);
            }
            return resultErrors;
        }

        /// <summary>
        /// Getting non valid 
        /// </summary>
        /// <param name="battleShips"></param>
        /// <returns></returns>
        private Dictionary<Point, string> GetNonValidBattleshipsCount(List<BattleShip> battleShips)
        {
            ///TODO: здесь надо обдумать как быстро и оптимально проверять
            var resultErrors = new Dictionary<Point, string>();
            var defaultPoint = new Point(0, 0);
            var battleshipActualCount = battleShips.Count(battleShip => battleShip.Length == (int)ClassicBattleShipTypesLength.Battleship);
            var cruiserActualCount = battleShips.Count(battleShip => battleShip.Length == (int)ClassicBattleShipTypesLength.Cruiser);
            var destroyerActualCount = battleShips.Count(battleShip => battleShip.Length == (int)ClassicBattleShipTypesLength.Destroyer);
            var mosquitoActualCount = battleShips.Count(battleShip => battleShip.Length == (int)ClassicBattleShipTypesLength.Mosquito);
            string errorText;
            if (battleshipActualCount != (int)ClassicBattleShipTypesCount.Battleship)
            {
                errorText = string.Format(Resource.BattleShipsValidator_BattleShipCountError,
                    (int)ClassicBattleShipTypesCount.Battleship,
                    Resource.BattleShipsValidator_Battleship,
                    battleshipActualCount);
                resultErrors.Add(defaultPoint, errorText);
            }
            if (cruiserActualCount != (int)ClassicBattleShipTypesCount.Cruiser)
            {
                errorText = string.Format(Resource.BattleShipsValidator_BattleShipCountError,
                    (int)ClassicBattleShipTypesCount.Cruiser, 
                    Resource.BattleShipsValidator_Cruiser, 
                    cruiserActualCount);
                resultErrors.Add(defaultPoint, errorText);
            }
            if (destroyerActualCount != (int)ClassicBattleShipTypesCount.Destroyer)
            {
                errorText = string.Format(Resource.BattleShipsValidator_BattleShipCountError,
                    (int)ClassicBattleShipTypesCount.Destroyer, 
                    Resource.BattleShipsValidator_Destroyer, 
                    destroyerActualCount);
                resultErrors.Add(defaultPoint, errorText);
            }
            if (mosquitoActualCount != (int)ClassicBattleShipTypesCount.Mosquito)
            {
                errorText = string.Format(Resource.BattleShipsValidator_BattleShipCountError,
                    (int)ClassicBattleShipTypesCount.Mosquito, 
                    Resource.BattleShipsValidator_Mosquito, 
                    mosquitoActualCount);
                resultErrors.Add(defaultPoint, errorText);
            }
            return resultErrors;
        }

        #endregion

    }
}
