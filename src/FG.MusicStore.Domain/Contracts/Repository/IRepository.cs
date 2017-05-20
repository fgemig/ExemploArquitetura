using System;
using FG.MusicStore.Domain.Shared.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FG.MusicStore.Domain.Contracts.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(Guid id);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
