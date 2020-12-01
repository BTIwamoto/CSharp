using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using NerdStore.Catalogo.Application.ViewModels;

namespace NerdStore.Catalogo.Application.Interfaces.AppServices
{
    public interface ICategoriaAppService : IAppService<CategoriaViewModel>
    {
        Task<IEnumerable<CategoriaViewModel>> ObterCategorias();
    }
}