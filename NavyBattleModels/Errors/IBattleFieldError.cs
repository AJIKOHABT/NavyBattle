using NavyBattleModels.Enums;

namespace NavyBattleModels.Errors
{
    /// <summary>
    /// Interface for error saving
    /// </summary>
    public interface IBattleFieldError
    {
        /// <summary>
        /// Type of the error
        /// </summary>
        BattlefieldErrorTypes Type { get; set; }

        /// <summary>
        /// Point of the battlefield where error occured
        /// </summary>
        Point ErrorPoint { get; set; }

        /// <summary>
        /// Descriptionof the error
        /// </summary>
        string Description { get; set; }
    }
}
