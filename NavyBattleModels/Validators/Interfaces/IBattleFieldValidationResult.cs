using System;
using System.Collections.Generic;
using System.Text;
using NavyBattleModels.Errors;

namespace NavyBattleModels.Validators.Interfaces
{
    public interface IBattleFieldValidationResult
    {
        /// <summary>
        /// Indicator of successful validation (true if successful)
        /// </summary>
        bool IsSuccess { get; set; }

        /// <summary>
        /// Id of the battlefield which was validates
        /// </summary>
       int BattleFieldId { get; set; }   
        

        /// <summary>
        /// List of validation errors
        /// </summary>
        List<IBattleFieldError> ErrorList { get; }
    }
}
