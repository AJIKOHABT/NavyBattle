using System;
using System.Collections.Generic;
using System.Text;

namespace NavyBattleModels
{
    public interface IBaseRepository<T> : IDisposable
        where T : class
    {
        /// <summary>
        /// Getting all objects of required type from the database
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Getting object of required type from the database by its id
        /// </summary>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// Creating object of required type in the database
        /// </summary>
        /// <param name="item"></param>
        void Create(T item);

        /// <summary>
        /// Updating object of required type in the database
        /// </summary>
        /// <param name="item"></param>
        void Update(T item);
        
        /// <summary>
        /// Saving changes in the database
        /// </summary>
        void Save();
    }
}
