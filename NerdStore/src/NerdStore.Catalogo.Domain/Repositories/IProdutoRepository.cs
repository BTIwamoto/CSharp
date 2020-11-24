using NerdStore.Catalogo.Domain.AggregationObjects;
using NerdStore.Catalogo.Domain.Entities;
using NerdStore.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterTodos();

        Task<Produto> ObterPorId(Guid id);

        Task<IEnumerable<Produto>> ObterPorCategoria(int codigo);

        Task<IEnumerable<Categoria>> ObterCategorias();
    }
}
