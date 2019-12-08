using NavyBattleModels.Interfaces;
using System.Collections.Generic;
using NavyBattleModels.Contexts;
using System.Linq;

namespace NavyBattleModels
{
    /// <summary>
    /// Base class for battlefield
    /// </summary>
    public class BaseBattleField : IBattleField
    {
        #region fields and properties

        /// <summary>
        /// Width of the battlefield
        /// </summary>
        private int _width;

        /// <summary>
        /// Height of the battlefield
        /// </summary>
        private int _height;

        /// <summary>
        /// Id of the battlefield
        /// </summary>
        private int _id;

        /// <summary>
        /// List of battleships on the battlefield
        /// </summary>
        private ICollection<IBattleShip> _battleShips = new List<IBattleShip>();

        /// <summary>
        /// Width of the battlefield
        /// </summary>
        public int Width
        {
            get
            {
                return _width;
            }
        }

        /// <summary>
        /// Height of the battlefield
        /// </summary>
        public int Height
        {
            get
            {
                return _height;
            }
        }

        /// <summary>
        /// Id of the battlefield
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// List of battleships on the battlefield
        /// </summary>
        public ICollection<IBattleShip> BattleShips
        {
            get
            {
                return _battleShips;
            }
        }

        #endregion

        #region constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public BaseBattleField(int width, int height)
        {
            _width = width;
            _height = height;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Recalculation of the startPoint and adding battleship to battlefield
        /// </summary>
        /// <param name="battleships"></param>
        public void AddBattleShips(IEnumerable<IBattleShip> battleships)
        {
            foreach (var battleship in battleships)
            {
                if (battleship.Length < 0)
                {
                    battleship.RecalculateBattleShip();
                }
                _battleShips.Add(battleship);
            }
        }

        /// <summary>
        /// Save the battlefield
        /// </summary>
        /// <returns>id of saved database</returns>
        public int Save()
        {
            using (NavyBattleContext db = new NavyBattleContext())
            {
                db.BattleFields.Add(this);
                db.SaveChanges();

                db.BattleShips.AddRange(this.BattleShips);
                db.SaveChanges();
            }
                return _id;
        }

        /// <summary>
        /// Getting battlefield from database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IBattleField GetById(int id)
        {
            using (NavyBattleContext db = new NavyBattleContext())
            {
                var battleField = db.BattleFields.FirstOrDefault(bF => bF.Id == id);
                return battleField;
            }
        }

        /// <summary>
        /// Getting all battlefields from database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IBattleField> GetAll(NavyBattleContext db)
        {
            return db.BattleFields;
        }

        #endregion
    }
}
