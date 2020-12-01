using System;
using System.Threading.Tasks;
using NerdStore.Catalogo.Application.ViewModels;

namespace NerdStore.Catalogo.Application.Interfaces.AppServices
{
    public interface IAppService<T> : IDisposable where T : ViewModel
    {
        Task Adicionar(T objectViewModel);

        Task Atualizar(T objectViewModel);
    }
}