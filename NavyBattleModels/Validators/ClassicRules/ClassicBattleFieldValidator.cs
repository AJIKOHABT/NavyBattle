using System;
using System.Collections.Generic;
using System.Text;

namespace NavyBattleModels.Validators
{
    /// <summary>
    /// Main validator for navyBattle classic rules
    /// </summary>
    public class ClassicBattleFieldValidator : IBattleFieldValidator
    {

        #region Properties and fields

        /// <summary>
        /// Battleships number and types validator
        /// </summary>
        private IBattleShipsValidator _battleShipsValidator;

        /// <summary>
        /// Crossing borders of battlefields validator
        /// </summary>
        private IBeyondBorderValidator _beyondBorderValidator;

        /// <summary>
        /// Battleships positions validator
        /// </summary>
        private IBattleShipPositionValidator _battleShipPositionValidator;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor of main validator
        /// </summary>
        public ClassicBattleFieldValidator()
        {
            _battleShipsValidator = new ClassicBattleShipsValidator();
            _beyondBorderValidator = new ClassicBeyondBorderValidator();
            _battleShipPositionValidator = new ClassicBattleShipPositionValidator();
        }

        #endregion

        #region IBattleFieldValidator implementation 

        /// <summary>
        /// Validate navy battle game field to match classic rules 
        /// </summary>
        /// <param name="battleShips"></param>
        /// <returns></returns>
        public Dictionary<Point, string> Validate(List<BattleShip> battleShips)
        {
            var validationResult = new Dictionary<Point, string>();

            validationResult.AddRange(_battleShipsValidator.Validate(battleShips));
            validationResult.AddRange(_beyondBorderValidator.Validate(battleShips));
            validationResult.AddRange(_battleShipPositionValidator.Validate(battleShips));
                        
            return validationResult;
        }

        #endregion

    }
}
