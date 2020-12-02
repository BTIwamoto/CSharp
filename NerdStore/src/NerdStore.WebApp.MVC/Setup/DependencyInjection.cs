using Microsoft.Extensions.DependencyInjection;
using NerdStore.Catalogo.Application.Interfaces.AppServices;
using NerdStore.Catalogo.Application.Services.AppServices;
using NerdStore.Catalogo.Application.ViewModels;
using NerdStore.Catalogo.Data.Context;
using NerdStore.Catalogo.Data.Repositories;
using NerdStore.Catalogo.Data.Services;
using NerdStore.Catalogo.Domain.Repositories;
using NerdStore.Catalogo.Domain.Services;
using NerdStore.Core.Bus;
using NerdStore.Core.Data;
using NerdStore.Core.DomainObjects.Entities;

namespace NerdStore.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatrHandler, MediatrHandler>();

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IRepository<Entity>, Repository<Entity>>();
            services.AddScoped<IUnitOfWork, CatalogoContext>();
            services.AddScoped<IEstoqueService, EstoqueService>();

            services.AddScoped<CatalogoContext>();
        }
    }
}