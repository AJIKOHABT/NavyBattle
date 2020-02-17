using NavyBattleModels;
using NavyBattleModels.Interfaces;
using NavyBattleModels.Models;
using NavyBattleModels.Services;
using System.Collections.Generic;

namespace NavyBattle.Services
{
    /// <summary>
    /// Service to work with game
    /// </summary>
    internal class UserService : IUserService
    {
        #region fields and properties

        /// <summary>
        /// Repository class to work with battleship objectcs in database
        /// </summary>
        IBaseRepository<User> _userRepository;

        #endregion

        #region Constructor

        /// <summary>
        /// Service to work with users
        /// </summary>
        /// <param name="shotRepository">Repository class to work with user objectcs in database</param>
        public UserService(IBaseRepository<User> userRepository)
        {
            this._userRepository = userRepository;
        }

        #endregion

        #region IUserService
        
        /// <summary>
        /// Adding a new user to database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddUser(User user)
        {
            _userRepository.Add(user);
            _userRepository.Save();
            return user.Id;
        }

        public User GetById(int userId)
        {
            return _userRepository.GetById(userId);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        #endregion
    }
}
