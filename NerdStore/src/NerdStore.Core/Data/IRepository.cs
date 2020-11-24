using NerdStore.Core.DomainObjects;
using System;
using NerdStore.Core.DomainObjects.Entities;

namespace NerdStore.Core.Data
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        IUnitOfWork UnitOfWkOfWork { get; }

        void Adicionar(T obj);

        void Atualizar(T obj);
    }
}