using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FG.MusicStore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FG.MusicStore.Domain.Shared.Entities;
using FG.MusicStore.Domain.Contracts.Repository;
using System.Threading.Tasks;

namespace FG.MusicStore.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {

        protected MusicStoreContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repository(MusicStoreContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
