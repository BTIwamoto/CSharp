using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Data.Context;
using NerdStore.Core.Data;
using NerdStore.Core.DomainObjects.Entities;

namespace NerdStore.Catalogo.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected CatalogoContext Context;
        protected DbSet<T> DbSet;

        public Repository(CatalogoContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public IUnitOfWork UnitOfWkOfWork => Context;

        public void Adicionar(T obj)
        {
            DbSet.Add(obj);
        }

        public void Atualizar(T obj)
        {
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}