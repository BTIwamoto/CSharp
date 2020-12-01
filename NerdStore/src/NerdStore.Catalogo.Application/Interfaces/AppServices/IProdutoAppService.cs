using NerdStore.Catalogo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Application.Interfaces.AppServices
{
    public interface IProdutoAppService : IAppService<ProdutoViewModel>
    {
        Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(int codigo);

        Task<ProdutoViewModel> ObterPorId(Guid codigo);

        Task<IEnumerable<ProdutoViewModel>> ObterTodos();

        Task<IEnumerable<CategoriaViewModel>> ObterCategorias();

        Task<ProdutoViewModel> DebitarEstoque(Guid id, int quantidade);

        Task<ProdutoViewModel> ReporEstoque(Guid id, int quantidade);
    }
}