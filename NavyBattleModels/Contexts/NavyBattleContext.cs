using Microsoft.EntityFrameworkCore;
using NavyBattleModels.Interfaces;

namespace NavyBattleModels.Contexts
{
    public class NavyBattleContext : DbContext
    {

        public NavyBattleContext() : base("DbConnection")
        { 
        }

        public DbSet<IGame> Games
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
