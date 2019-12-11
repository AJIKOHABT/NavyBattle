using NavyBattleModels;
using NavyBattle.Dal.Contexts;
using NavyBattle.Dal.Repositories;
using NavyBattleModels.Interfaces;

namespace NavyBattle.Dal.Work
{
    /// <summary>
    /// Class to provide repository classes of different types
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties and fields

        /// <summary>
        /// Context class to work with database
        /// </summary>
        private readonly NavyBattleContext _dbContext;

        /// <summary>
        /// Repository class to work with battlefield objects in database
        /// </summary>
        private BattleFieldRepository _battleFieldRepository;

        /// <summary>
        /// Repository class to work with battleship objects in database
        /// </summary>
        private BattleShipRepository _battleShipRepository;

        /// <summary>
        /// Repository class to work with game objects in database
        /// </summary>
        private GameRepository _gameRepository;

        /// <summary>
        /// Repository class to work with battleship in the game objects in database
        /// </summary>
        private GameBattleShipRepository _gameBattleShipRepository;

        /// <summary>
        /// Repository class to work with shot objects in database
        /// </summary>
        private ShotRepository _shotRepository;

        /// <summary>
        /// Repository class to work with battlefield objects in database
        /// </summary>
        public IBaseRepository<IBattleField> BattleFieldRepository 
        {
            get 
            {
                return _battleFieldRepository ?? new BattleFieldRepository(_dbContext);
            } 
        }

        /// <summary>
        /// Repository class to work with battleship objects in database
        /// </summary>
        public IBaseRepository<IBattleShip> BattleShipRepository
        {
            get
            {
                return _battleShipRepository ?? new BattleShipRepository(_dbContext);
            }
        }

        /// <summary>
        /// Repository class to work with game objects in database
        /// </summary>
        public IBaseRepository<IGame> GameRepository
        {
            get
            {
                return _gameRepository ?? new GameRepository(_dbContext);
            }
        }

        /// <summary>
        /// Repository class to work with battleship in the game objects in database
        /// </summary>
        public IBaseRepository<IGameBattleShip> GameBattleShipRepository 
        {
            get
            {
                return _gameBattleShipRepository ?? new GameBattleShipRepository(_dbContext);
            }
        }

        /// <summary>
        /// Repository class to work with shot objects in database
        /// </summary>
        public IBaseRepository<IShot> ShotRepository
        {
            get
            {
                return _shotRepository ?? new ShotRepository(_dbContext);
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">Context to work with db</param>
        public UnitOfWork(NavyBattleContext dbContext)
        {
            this._dbContext = dbContext;
        }

        #endregion

        #region IUnitOfWork

        /// <summary>
        /// Commit all changes to database
        /// </summary>
        /// <returns></returns>
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        #endregion        
    }
}
