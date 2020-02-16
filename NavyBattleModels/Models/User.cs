using NavyBattleModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavyBattleModels.Models
{
    public class User : IUser
    {
        /// <summary>
        /// User id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Battlefields which are attcached to the games
        /// </summary>
        public IEnumerable<GameBattleField> GameBattleFields { get; set; }

        /// <summary>
        /// Battlefields that was created by this user
        /// </summary>
        public IEnumerable<BaseBattleField> BattleFields { get; set; }

        /// <summary>
        /// Battlefields that was created by this user
        /// </summary>
        public IEnumerable<Game> Games { get; set; }
    }
}
