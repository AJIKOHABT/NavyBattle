using NavyBattleModels.Enums;
using System;
using System.Collections.Generic;


namespace NavyBattleModels.Interfaces
{
    /// <summary>
    /// Interface for the user
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// User id
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Battlefields which are attcached to the games
        /// </summary>
        IEnumerable<IGameBattleField> GameBattleFields { get; set; }

        /// <summary>
        /// Battlefields that was created by this user
        /// </summary>
        IEnumerable<IBattleField> BattleFields { get; set; }

        /// <summary>
        /// Battlefields that was created by this user
        /// </summary>
        IEnumerable<IGame> Games { get; set; }
    }
}
