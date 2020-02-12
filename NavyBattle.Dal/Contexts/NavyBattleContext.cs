using Microsoft.EntityFrameworkCore;
using NavyBattleModels.Interfaces;


namespace NavyBattle.Dal.Contexts
{
    public class NavyBattleContext : DbContext
    {
        public NavyBattleContext(DbContextOptions<NavyBattleContext> options) : base(options)
        {            
        }

        public DbSet<IGame> Games
        {
            get;
            set; 
        }

        public DbSet<IGameBattleField> GameBattleFields
        {
            get;
            set;
        }

        public DbSet<IUser> Users
        {
            get;
            set;
        }

        public DbSet<IShot> Shots
        {
            get;
            set;
        }

        public DbSet<IGameBattleShip> GameBattleShips
        {
            get;
            set;
        }

        public DbSet<IBattleField> BattleFields
        {
            get;
            set;
        }

        public DbSet<IBattleShip> BattleShips
        {
            get;
            set;
        }
    }
}
