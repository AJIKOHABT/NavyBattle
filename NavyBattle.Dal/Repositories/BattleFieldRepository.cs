using NavyBattle.Dal.Contexts;
using NavyBattleModels;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace NavyBattle.Dal.Repositories
{
    /// <summary>
    /// Repository to work with battlefield objects in db
    /// </summary>
    internal class BattleFieldRepository : BaseRepository<BaseBattleField>
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">db context</param>
        public BattleFieldRepository(NavyBattleContext context) : base (context)
        {
        }

        /// <summary>
        /// Getting all objects of required type from the database
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<BaseBattleField> GetAll()
        {
            return Context.Set<BaseBattleField>().Include(b => b.BattleShips).ToList();
        }

        #endregion
    }
}
