using System;
using System.Collections.Generic;
using NavyBattleModels.Errors;
using NavyBattleModels.Validators.Interfaces;

namespace NavyBattleModels.Validators
{
    public class BattleFieldValidationResult : IBattleFieldValidationResult
    {
        #region Properties and fields

        /// <summary>
        /// Indicator of successful validation (true if successful)
        /// </summary>
        private bool _isSuccess = false;

        /// <summary>
        /// Id of the battlefield which was validates
        /// </summary>
        private int? _battleFieldId;

        /// <summary>
        /// List of validation errors
        /// </summary>
        private List<IBattleFieldError> _errorsList = new List<IBattleFieldError>();

        /// <summary>
        /// Indicator of successful validation (true if successful)
        /// </summary>
        public bool IsSuccess
        {
            get
            {
                return _isSuccess;
            }
            set
            {
                _isSuccess = value;
            }
        }

        /// <summary>
        /// Id of the battlefield which was validates
        /// </summary>
        public int? BattleFieldId
        {
            get 
            {
                return _battleFieldId;
            }
            set 
            {
                _battleFieldId = value;
            }
        }

        /// <summary>
        /// List of validation errors
        /// </summary>
        public List<IBattleFieldError> ErrorList
        {
            get
            {
                return _errorsList;
            }
        }

        #endregion
    }
}
