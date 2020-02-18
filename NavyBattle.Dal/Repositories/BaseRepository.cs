using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NavyBattleModels;

namespace NavyBattle.Dal.Repositories
{
    internal class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity: class
    {
        #region properties and fields

        /// <summary>
        /// Db context
        /// </summary>
        protected readonly DbContext Context;

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
        public BaseRepository(DbContext context)
        {
            this.Context = context;
        }

        #endregion

        #region IBaseRepository

        /// <summary>
        /// Getting all objects of required type from the database
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Getting object of required type from the database by its id
        /// </summary>
        /// <returns></returns>
        public TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Adding object of required type to the database
        /// </summary>
        /// <param name="item"></param>
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Adding range of objects of required type
        /// </summary>
        /// <param name="entities"></param>
        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);            
        }

        /// <summary>
        /// Updating object of required type in the database
        /// </summary>
        /// <param name="item"></param>
        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Save changes in the database
        /// </summary>
        /// <returns></returns>
        public int Save()
        {            
            return Context.SaveChanges();
        }

        /// <summary>
        /// Remove entity from the database
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        #endregion

        #region IDisposable

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
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
