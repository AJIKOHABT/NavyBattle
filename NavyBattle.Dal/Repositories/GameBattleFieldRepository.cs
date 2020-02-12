using System;
using NavyBattleModels;
using NavyBattleModels.Interfaces;
using NavyBattle.Dal.Contexts;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NavyBattle.Dal.Repositories
{
    /// <summary>
    /// Repository to work with game objects in db
    /// </summary>
    internal class GameBattleFieldRepository : BaseRepository<IGameBattleField>        
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">db context</param>
        public GameBattleFieldRepository(NavyBattleContext context) : base(context)
        {
        }

        #endregion
    }
}
