using AutoMapper;
using NerdStore.Catalogo.Application.Interfaces.AppServices;
using NerdStore.Catalogo.Application.ViewModels;
using NerdStore.Catalogo.Domain.AggregationObjects.ProdutoAggregate;
using NerdStore.Catalogo.Domain.Services;
using NerdStore.Core.DomainObjects.ExceptionHelper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Application.Services.AppServices
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEstoqueService _estoqueService;

        public ProdutoAppService(IMapper mapper, IProdutoRepository produtoRepository, IEstoqueService estoqueService)
        {
            _mapper = mapper;
            _produtoRepository = produtoRepository;
            _estoqueService = estoqueService;
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterPorCategoria(int codigo)
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterPorCategoria(codigo));
        }

        public async Task<ProdutoViewModel> ObterPorId(Guid codigo)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(codigo));
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterTodos());
        }

        public async Task<IEnumerable<CategoriaViewModel>> ObterCategorias()
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(await _produtoRepository.ObterCategorias());
        }

        public async Task<ProdutoViewModel> DebitarEstoque(Guid id, int quantidade)
        {
            if (!_estoqueService.DebitarEstoque(id, quantidade).Result)
                throw new DomainException("Falha ao debitar estoque");

            return _mapper.Map<ProdutoViewModel>(_produtoRepository.ObterPorId(id).Result);
        }

        public async Task<ProdutoViewModel> ReporEstoque(Guid id, int quantidade)
        {
            if (!_estoqueService.ReporEstoque(id, quantidade).Result)
                throw new DomainException("Falha ao repor estoque");

            return _mapper.Map<ProdutoViewModel>(_produtoRepository.ObterPorId(id).Result);
        }

        public async Task Adicionar(ProdutoViewModel objectViewModel)
        {
            var obj = _mapper.Map<Produto>(typeof(ProdutoViewModel));

            _produtoRepository.Adicionar(obj);

            await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task Atualizar(ProdutoViewModel objectViewModel)
        {
            var obj = _mapper.Map<Produto>(typeof(ProdutoViewModel));

            _produtoRepository.Atualizar(obj);

            await _produtoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
            _estoqueService?.Dispose();
        }
    }
}