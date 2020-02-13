﻿using NavyBattleModels.Interfaces;
using System;
using System.Collections.Generic;
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
        private Guid _guid;

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
            set
            {
                _width = value;
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
            set
            {
                _height = value;
            }
        }

        /// <summary>
        /// Id of the battlefield
        /// </summary>
        public Guid Guid
        {
            get
            {
                return _guid;
            }
            set
            {
                _guid = value;
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
            set
            {
                _battleShips = value;
            }
        }

        #endregion

        #region constructor

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public BaseBattleField()
        {
            _battleShips = new List<IBattleShip>();
        }

        /// <summary>
        /// Battlefield constructor
        /// </summary>
        /// <param name="width">width of the battlefield</param>
        /// <param name="height">height of the battlefield</param>
        public BaseBattleField(int width, int height)
        {
            _guid = new Guid();
            _width = width;
            _height = height;
        }

        #endregion

        #region public methods

        public virtual void AutoGenerate()
        { 
        }

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

        #endregion
    }
}
