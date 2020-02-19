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

        #endregion

        #region override

        /// <summary>
        /// Getting all objects of required type from the database
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<BaseBattleField> GetAll()
        {
            return Context.Set<BaseBattleField>().
                Include(b => b.BattleShips).
                Include(b=>b.Owner).ToList();
        }

        /// <summary>
        /// Getting object of required type from the database by its id
        /// </summary>
        /// <returns></returns>
        public override BaseBattleField GetById(int id)
        {
            var battleField = Context.Set<BaseBattleField>().Find(id);
            Context.Entry(battleField)
                .Collection(b => b.BattleShips)
                .Load();
            Context.Entry(battleField)
                .Reference(b => b.Owner)
                .Load();
            return battleField;      
        }

        #endregion
    }
}
