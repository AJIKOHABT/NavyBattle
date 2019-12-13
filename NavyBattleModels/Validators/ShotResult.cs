using NavyBattleModels.Interfaces;
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
        private IGameBattleShip _gameBattleShip;

        /// <summary>
        /// Shot
        /// </summary>
        private IShot _shot;

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
        public IGameBattleShip GameBattleShip
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
        public IShot Shot
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
