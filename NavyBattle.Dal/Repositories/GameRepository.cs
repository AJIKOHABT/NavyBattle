using NavyBattleModels.Interfaces;
using NavyBattle.Dal.Contexts;
using NavyBattleModels.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NavyBattle.Dal.Repositories
{
    /// <summary>
    /// Repository to work with game objects in db
    /// </summary>
    internal class GameRepository : BaseRepository<Game>        
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">db context</param>
        public GameRepository(NavyBattleContext context) : base(context)
        {
        }

        #endregion

        #region override

        /// <summary>
        /// Getting all objects of required type from the database
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Game> GetAll()
        {
            return Context.Set<Game>().
                Include(g => g.GameBattleFields).
                    ThenInclude(gb => gb.BattleField).                    
                Include(g => g.GameBattleFields).
                    ThenInclude(gb=>gb.GameBattleShips).
                    ThenInclude(gbs=>gbs.BattleShip).
                Include(g => g.GameBattleFields).
                    ThenInclude(gb => gb.Shots).
                Include(g => g.GameBattleFields).
                    ThenInclude(gb=>gb.Owner).
                Include(g=>g.Winner).ToList();
        }

        /// <summary>
        /// Getting object of required type from the database by its id
        /// </summary>
        /// <returns></returns>
        public override Game GetById(int id)
        {
            var game = Context.Set<Game>().Find(id); 
            Context.Entry(game)
                .Collection(g => g.GameBattleFields)
                .Load();
            foreach (var gameBattleField in game.GameBattleFields)
            {
                Context.Entry(gameBattleField).Reference(gb => gb.BattleField).Load();
                Context.Entry(gameBattleField).Reference(gb => gb.Owner).Load();
                Context.Entry(gameBattleField).Collection(gb => gb.Shots).Load();
                Context.Entry(gameBattleField).Collection(gb => gb.GameBattleShips).Load();
                foreach (var gameBattleShip in gameBattleField.GameBattleShips)
                {
                    Context.Entry(gameBattleShip).Reference(gbs => gbs.BattleShip).Load();
                }                
            }            
            Context.Entry(game)
                .Reference(g => g.Winner)
                .Load();
            return game;
        }

        #endregion
    }
}
