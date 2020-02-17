using NavyBattleModels.Interfaces;
using NavyBattle.Dal.Contexts;
using NavyBattleModels.Models;

namespace NavyBattle.Dal.Repositories
{
    /// <summary>
    /// Repository to work with battleship in the game objects in db
    /// </summary>
    internal class GameBattleShipRepository : BaseRepository<GameBattleShip>
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">db context</param>
        public GameBattleShipRepository(NavyBattleContext context) : base(context)
        {
        }

        #endregion

    }
}
