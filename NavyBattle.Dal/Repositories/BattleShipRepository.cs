using System;
using NavyBattleModels;
using NavyBattleModels.Interfaces;
using NavyBattle.Dal.Contexts;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NavyBattle.Dal.Repositories
{
    /// <summary>
    /// Repository to work with battleship objects in db
    /// </summary>
    public class BattleShipRepository : IBaseRepository<IBattleShip>
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
        public BattleShipRepository(NavyBattleContext context)
        {
            _db = context;
        }

        #endregion

        #region IBaseRepository

        /// <summary>
        /// Getting all objects of required type from the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IBattleShip> GetAll()
        {
            return _db.BattleShips;
        }

        /// <summary>
        /// Getting object of required type from the database by its id
        /// </summary>
        /// <returns></returns>
        public IBattleShip GetById(int id)
        {
            return _db.BattleShips.Find(id);
        }


        /// <summary>
        /// Adding object of required type to the database
        /// </summary>
        /// <param name="item"></param>
        public void Add(IBattleShip battleShip)
        {
            _db.BattleShips.Add(battleShip);
        }
        
        /// <summary>
        /// Updating object of required type in the database
        /// </summary>
        /// <param name="item"></param>
        public void Update(IBattleShip battleShip)
        {
            _db.Entry(battleShip).State = EntityState.Modified;
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
