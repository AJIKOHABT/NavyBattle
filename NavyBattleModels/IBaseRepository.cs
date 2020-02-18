using System;
using System.Collections.Generic;

namespace NavyBattleModels
{
    public interface IBaseRepository<TEntity> : IDisposable
        where TEntity : class
    {
        /// <summary>
        /// Getting all objects of required type from the database
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Getting object of required type from the database by its id
        /// </summary>
        /// <returns></returns>
        TEntity GetById(int id);

        /// <summary>
        /// Adding object of required type to the database
        /// </summary>
        /// <param name="item"></param>
        void Add(TEntity item);

        /// <summary>
        /// Adding range of objects of required type
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Updating object of required type in the database
        /// </summary>
        /// <param name="item"></param>
        void Update(TEntity item);

        /// <summary>
        /// Save changes in the database
        /// </summary>
        /// <returns></returns>
        int Save();

        /// <summary>
        /// Remove entity from the database
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);
    }
}
