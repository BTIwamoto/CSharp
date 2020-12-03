using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalogo.Application.Interfaces.AppServices;
using NerdStore.Catalogo.Application.ViewModels;

namespace NerdStore.WebApp.MVC.Controllers.Admin
{
    public class AdminProdutosController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;

        public AdminProdutosController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpGet]
        [Route("AdminProdutos")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _produtoAppService.ObterTodos());
        }

        [Route("NovoProduto")]
        public async Task<IActionResult> NovoProduto()
        {
            return Ok(await PopularCategorias(new ProdutoViewModel()));
        }

        [HttpPost]
        [Route("NovoProduto")]
        public async Task<IActionResult> NovoProduto(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return Ok(await PopularCategorias(produtoViewModel));

            await _produtoAppService.Adicionar(produtoViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("ProdutosAtualizarEstoque")]
        public async Task<IActionResult> AtualizarEstoque(Guid id)
        {
            return Ok(await _produtoAppService.ObterPorId(id));
        }

        [HttpPost]
        [Route("ProdutosAtualizarEstoque")]
        public async Task<IActionResult> AtualizarEstoque(Guid id, int quantidade)
        {
            if (quantidade > 0)
                await _produtoAppService.ReporEstoque(id, quantidade);
            else
                await _produtoAppService.DebitarEstoque(id, quantidade);

            return Ok(await _produtoAppService.ObterTodos());
        }

        private async Task<ProdutoViewModel> PopularCategorias(ProdutoViewModel produto)
        {
            produto.Categoria = await _produtoAppService.ObterCategorias();
            return produto;
        }
    }
}