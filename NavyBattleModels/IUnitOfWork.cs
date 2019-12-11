using NavyBattleModels.Interfaces;
using System;

namespace NavyBattleModels
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Repository class to work with battlefield objects in database
        /// </summary>
        IBaseRepository<IBattleField> BattleFieldRepository { get; }

        /// <summary>
        /// Repository class to work with battleship objects in database
        /// </summary>
        IBaseRepository<IBattleShip> BattleShipRepository { get; }

        /// <summary>
        /// Repository class to work with game objects in database
        /// </summary>
        IBaseRepository<IGame> GameRepository { get; }

        /// <summary>
        /// Repository class to work with battleship in the game objects in database
        /// </summary>
        IBaseRepository<IGameBattleShip> GameBattleShipRepository { get; }

        /// <summary>
        /// Repository class to work with shot objects in database
        /// </summary>
        IBaseRepository<IShot> ShotRepository { get; }

        /// <summary>
        /// Commit all changes to database
        /// </summary>
        /// <returns></returns>
        int Commit();

    }
}
