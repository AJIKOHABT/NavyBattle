using System;
using System.Collections.Generic;
using System.Text;
using NavyBattleModels.Errors;
using NavyBattleModels.Validators.Interfaces;

namespace NavyBattleModels.Validators
{
    /// <summary>
    /// Main validator for navyBattle classic rules
    /// </summary>
    public class ClassicBattleFieldValidator : IBattleShipValidator
    {

        #region Properties and fields

        /// <summary>
        /// Battleships number and types validator
        /// </summary>
        private IBattleShipValidator _battleShipsValidator;

        /// <summary>
        /// Crossing borders of battlefields validator
        /// </summary>
        private IBattleShipValidator _beyondBorderValidator;

        /// <summary>
        /// Battleships positions validator
        /// </summary>
        private IBattleShipValidator _battleShipPositionValidator;

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
        public IEnumerable<BattleFieldError> Validate(IEnumerable<BattleShip> battleShips)
        {
            var validationResult = new List<BattleFieldError>();

            validationResult.AddRange(_battleShipsValidator.Validate(battleShips));
            validationResult.AddRange(_beyondBorderValidator.Validate(battleShips));
            validationResult.AddRange(_battleShipPositionValidator.Validate(battleShips));
                        
            return validationResult;
        }

        #endregion

    }
}
