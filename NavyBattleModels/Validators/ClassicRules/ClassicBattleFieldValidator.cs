using System;
using System.Collections.Generic;
using System.Text;
using NavyBattleModels.Errors;
using NavyBattleModels.Interfaces;
using NavyBattleModels.Validators.Interfaces;
using System.Linq;

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
        public IBattleFieldValidationResult Validate(IEnumerable<IBattleShip> battleShips)
        {
            var validationResult = new BattleFieldValidationResult();

            var battleField = new ClassicBattleField();
            battleField.AddBattleShips(battleShips);

            validationResult.ErrorList.AddRange(_battleShipsValidator.Validate(battleField));
            validationResult.ErrorList.AddRange(_beyondBorderValidator.Validate(battleField));
            validationResult.ErrorList.AddRange(_battleShipPositionValidator.Validate(battleField));

            if (!validationResult.ErrorList.Any())
            {
                validationResult.IsSuccess = true;
                validationResult.BattleFieldId = battleField.Save();
            }
                        
            return validationResult;
        }

        #endregion

    }
}
