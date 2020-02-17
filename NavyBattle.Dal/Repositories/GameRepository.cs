using NavyBattleModels.Interfaces;
using NavyBattle.Dal.Contexts;
using NavyBattleModels.Models;

namespace NavyBattle.Dal.Repositories
{
    /// <summary>
    /// Repository to work with game objects in db
    /// </summary>
    internal class GameRepository : BaseRepository<Game>        
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">db context</param>
        public GameRepository(NavyBattleContext context) : base(context)
        {
        }

        #endregion
    }
}
