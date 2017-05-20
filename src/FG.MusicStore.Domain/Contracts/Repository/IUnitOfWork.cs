using System;

namespace FG.MusicStore.Domain.Contracts.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
