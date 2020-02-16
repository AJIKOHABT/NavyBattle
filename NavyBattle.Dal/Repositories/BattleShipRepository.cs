using NavyBattleModels.Interfaces;
using NavyBattle.Dal.Contexts;

namespace NavyBattle.Dal.Repositories
{
    /// <summary>
    /// Repository to work with battleship objects in db
    /// </summary>
    internal class BattleShipRepository : BaseRepository<IBattleShip>
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">db context</param>
        public BattleShipRepository(NavyBattleContext context) : base(context)
        {
        }

        #endregion

    }
}
