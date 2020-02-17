using NavyBattleModels.Interfaces;
using NavyBattleModels.Models;
using NavyBattleModels.Validators.Interfaces;

namespace NavyBattleModels.Validators
{
    public class ShotResult : IShotResult
    {
        #region Properties and fields

        /// <summary>
        /// Indicator of successful validation (true if successful)
        /// </summary>
        private bool _isSuccess = false;

        /// <summary>
        /// Damaged or destroyed battleship
        /// </summary>
        private GameBattleShip _gameBattleShip;

        /// <summary>
        /// Shot
        /// </summary>
        private Shot _shot;

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
        /// Damaged or destroyed battleship
        /// </summary>
        public GameBattleShip GameBattleShip
        {
            get 
            {
                return _gameBattleShip;
            }
            set
            {
                _gameBattleShip = value;
            }
        }

        /// <summary>
        /// Shot
        /// </summary>
        public Shot Shot
        {
            get 
            {
                return _shot;
            }
            set
            {
                _shot = value;
            }
        }

        #endregion
    }
}
