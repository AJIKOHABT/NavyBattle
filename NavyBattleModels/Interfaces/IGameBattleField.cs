using System;
using System.Collections.Generic;


namespace NavyBattleModels.Interfaces
{
    /// <summary>
    /// Interface for the game battlefield
    /// </summary>
    public interface IGameBattleField
    {
        /// <summary>
        /// Game battlefield id
        /// </summary>
        Guid Guid { get; set; }

        /// <summary>
        /// Battlefield on which the game will take place
        /// </summary>
        IBattleField BattleField { get; set; }

        /// <summary>
        /// Id of the battlefield
        /// </summary>
        Guid BattleFieldId { get; set; }

        /// <summary>
        /// Game which this battlefield is added to
        /// </summary>
        IGame Game { get; set; }

        /// <summary>
        /// Id of the game which this battlefield is added to
        /// </summary>
        Guid GameId { get; set; }

        /// <summary>
        /// Player owner of this battlefield
        /// </summary>
        IUser Owner { get; set; }

        /// <summary>
        /// Id of the player owner of this battlefield
        /// </summary>
        Guid OwnerId { get; set; }

        /// <summary>
        /// BattleShips in the game
        /// </summary>
        IEnumerable<IGameBattleShip> GameBattleShips { get; set; }

        /// <summary>
        /// Shots that were made during the game                                                                                                                                                                                                                                                                                                                     
        /// </summary>
        IEnumerable<IShot> Shots { get; set; }
        
    }
}
