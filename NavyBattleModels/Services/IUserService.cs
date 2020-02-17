using NavyBattleModels.Models;
using System.Collections.Generic;

namespace NavyBattleModels.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Adding user to db
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int AddUser(User user);

        /// <summary>
        /// Getting user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        User GetById(int userId);

        /// <summary>
        /// Get all users in system
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetAll();
    }
}