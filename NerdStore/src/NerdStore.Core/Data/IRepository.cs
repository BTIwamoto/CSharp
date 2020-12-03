using NerdStore.Core.DomainObjects.Entities;
using System;

namespace NerdStore.Core.Data
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        void Adicionar(T obj);

        void Atualizar(T obj);
    }
}