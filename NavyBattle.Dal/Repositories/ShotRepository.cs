﻿using System;
using NavyBattleModels;
using NavyBattleModels.Interfaces;
using NavyBattle.Dal.Contexts;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
