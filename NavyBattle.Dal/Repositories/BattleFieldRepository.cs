using System;
using NavyBattleModels;
using NavyBattleModels.Interfaces;
using NavyBattle.Dal.Contexts;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NavyBattle.Dal.Repositories
{
    public class BattleFieldRepository : IBaseRepository<IBattleField>
    {
        private NavyBattleContext _db;

        private bool _disposed = false;

        public BattleFieldRepository(NavyBattleContext context)
        {
            _db = context;
        }

        public IEnumerable<IBattleField> GetAll()
        {
            return _db.BattleFields;
        }

        public IBattleField GetById(int id)
        {
            return _db.BattleFields.Find(id);
        }

        public void Create(IBattleField battleField)
        {
            _db.BattleFields.Add(battleField);
        }

        public void Update(IBattleField battleField)
        {
            _db.Entry(battleField).State = EntityState.Modified;
        }

        public void Save()
        {
            _db.SaveChanges();
        }        

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
