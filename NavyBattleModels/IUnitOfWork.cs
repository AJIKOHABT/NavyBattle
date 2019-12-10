using NavyBattleModels.Interfaces;
using System;

namespace NavyBattleModels
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<IBattleField> BattleFieldRepository { get; }

        IBaseRepository<IBattleShip> BattleShipRepository { get; }

        IBaseRepository<IGame> GameRepository { get; }

        IBaseRepository<IGameBattleShip> GameBattleShipRepository { get; }

        IBaseRepository<IShot> ShotRepository { get; }

    }
}
