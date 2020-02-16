using Microsoft.EntityFrameworkCore;
using NavyBattleModels;
using NavyBattleModels.Models;

namespace NavyBattle.Dal.Contexts
{
    public class NavyBattleContext : DbContext
    {
        public NavyBattleContext(DbContextOptions<NavyBattleContext> options) : base(options)
        {            
        }

        public DbSet<Game> Games
        {
            get;
            set; 
        }

        public DbSet<GameBattleField> GameBattleFields
        {
            get;
            set;
        }

        public DbSet<User> Users
        {
            get;
            set;
        }

        public DbSet<Shot> Shots
        {
            get;
            set;
        }

        public DbSet<GameBattleShip> GameBattleShips
        {
            get;
            set;
        }

        public DbSet<BaseBattleField> BattleFields
        {
            get;
            set;
        }

        public DbSet<BattleShip> BattleShips
        {
            get;
            set;
        }
    }
}
