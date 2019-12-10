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
    public class GameRepository : IBaseRepository<IGame>        
    {
        #region properties and fields

        /// <summary>
        /// Db context
        /// </summary>
        private NavyBattleContext _db;

        /// <summary>
        /// Flag of disposed class
        /// </summary>
        private bool _disposed = false;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">db context</param>
        public GameRepository(NavyBattleContext context)
        {
            _db = context;
        }

        #endregion

        #region IBaseRepository

        /// <summary>
        /// Getting all objects of required type from the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGame> GetAll()
        {
            return _db.Games;
        }

        /// <summary>
        /// Getting object of required type from the database by its id
        /// </summary>
        /// <returns></returns>
        public IGame GetById(int id)
        {
            return _db.Games.Find(id);
        }

        /// <summary>
        /// Adding object of required type to the database
        /// </summary>
        /// <param name="item"></param>
        public void Add(IGame game)
        {
            _db.Games.Add(game);
        }

        /// <summary>
        /// Updating object of required type in the database
        /// </summary>
        /// <param name="item"></param>
        public void Update(IGame game)
        {
            _db.Entry(game).State = EntityState.Modified;
        }

        /// <summary>
        /// Saving changes in the database
        /// </summary>
        public void Save()
        {
            _db.SaveChanges();
        }

        #endregion

        #region IDisposable

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
