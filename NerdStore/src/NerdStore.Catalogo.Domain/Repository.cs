using NerdStore.Core.Data;
using NerdStore.Core.DomainObjects;
using System;

namespace NerdStore.Catalogo.Domain
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        public IUnitOfWork UnitOfWkOfWork => throw new NotImplementedException();

        public void Adicionar(T obj)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(T obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
