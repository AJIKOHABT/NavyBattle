using NavyBattle.Dal.Contexts;
using NavyBattleModels.Interfaces;

namespace NavyBattle.Dal.Repositories
{
    /// <summary>
    /// Repository to work with battlefield objects in db
    /// </summary>
    internal class BattleFieldRepository : BaseRepository<IBattleField>
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">db context</param>
        public BattleFieldRepository(NavyBattleContext context) : base (context)
        {
        }
        
        #endregion
    }
}
