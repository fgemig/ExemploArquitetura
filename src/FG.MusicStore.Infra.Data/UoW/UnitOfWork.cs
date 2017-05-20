using FG.MusicStore.Domain.Contracts.Repository;
using FG.MusicStore.Infra.Data.Context;

namespace FG.MusicStore.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MusicStoreContext _context;

        public UnitOfWork(MusicStoreContext context)
        {
            _context = context;
        }

        public void Commit()
        {
              _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}