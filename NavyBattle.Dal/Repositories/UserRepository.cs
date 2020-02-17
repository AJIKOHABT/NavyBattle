using NavyBattle.Dal.Contexts;
using NavyBattleModels.Interfaces;
using NavyBattleModels.Models;

namespace NavyBattle.Dal.Repositories
{
    /// <summary>
    /// Repository to work with game objects in db
    /// </summary>
    internal class UserRepository : BaseRepository<User>        
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">db context</param>
        public UserRepository(NavyBattleContext context) : base(context)
        {
        }

        #endregion
    }
}
