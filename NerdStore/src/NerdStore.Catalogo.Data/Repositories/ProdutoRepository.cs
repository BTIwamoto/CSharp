using Microsoft.EntityFrameworkCore;
using NerdStore.Catalogo.Data.Context;
using NerdStore.Catalogo.Domain.AggregationObjects;
using NerdStore.Catalogo.Domain.Entities;
using NerdStore.Catalogo.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Data.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(CatalogoContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await Context.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            return await Context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterPorCategoria(int codigo)
        {
            return await Context.Produtos.AsNoTracking().Include(p => p.Categoria).Where(c => c.Categoria.Codigo == codigo).ToListAsync();
        }

        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
            return await Context.Categorias.AsNoTracking().ToListAsync();
        }
    }
}