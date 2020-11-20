using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Data.Context;
using NerdStore.Core.Data;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected CatalogoContext Context;

        public Repository(CatalogoContext context)
        {
            Context = context;
        }

        public IUnitOfWork UnitOfWkOfWork => Context;
        
        public void Adicionar(T obj)
        {
            Context.Set<T>().Add(obj);
        }

        public void Atualizar(T obj)
        {
            Context.Set<T>().Add(obj);
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}