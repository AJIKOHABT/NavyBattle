﻿using NavyBattleModels.Interfaces;
using NavyBattle.Dal.Contexts;

namespace NavyBattle.Dal.Repositories
{
    /// <summary>
    /// Repository to work with game objects in db
    /// </summary>
    internal class ShotRepository : BaseRepository<IShot>
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
