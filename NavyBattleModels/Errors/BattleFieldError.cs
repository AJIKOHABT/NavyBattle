using NavyBattleModels.Enums;
using NavyBattleModels.Resources;

namespace NavyBattleModels.Errors
{
    /// <summary>
    /// Class for error saving
    /// </summary>
    public class BattleFieldError
    {
        #region fields and properties

        /// <summary>
        /// Type of the error
        /// </summary>
        private BattlefieldErrorTypes _type;

        /// <summary>
        /// Point of the battlefield where error occured
        /// </summary>
        private Point _point;

        /// <summary>
        /// Description of the error
        /// </summary>
        private string _description;

        /// <summary>
        /// Type of the error
        /// </summary>
        public BattlefieldErrorTypes Type
        {
            get
            {
                return _type;
            }
        }

        /// <summary>
        /// Point of the battlefield where error occured
        /// </summary>
        public Point ErrorPoint
        {
            get
            {
                return _point;
            }
        }

        /// <summary>
        /// Descriptionof the error
        /// </summary>
        public string Description
        {
            get
            {
                return _description;
            }
        }

        #endregion

        #region constructor

        /// <summary>
        /// Constructor of the error
        /// </summary>
        /// <param name="errorType">Error type</param>
        /// <param name="errorPoint">Point of the battlefield where error occured</param>
        public BattleFieldError(BattlefieldErrorTypes errorType, Point errorPoint = new Point())
        {
            _type = errorType;
            _point = errorPoint;
            _description = Resource.ResourceManager.GetString(errorType.ToString());
        }

        #endregion       

    }
}
