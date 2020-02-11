using NavyBattle.Dal.Contexts;
using NavyBattleModels.Validators.Interfaces;

namespace NavyBattle.Dal.Repositories
{
    /// <summary>
    /// Repository to work with shot objects in db
    /// </summary>
    internal class ShotRepository : BaseRepository<IShotResult>
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">db context</param>
        public ShotRepository(NavyBattleContext context) : base(context)
        {
        }

        #endregion
    }
}
