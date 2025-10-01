using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Aplicacao.Interfaces;
using SistemaVendas.Aplicacao.Models;

namespace SistemaVendas.Aplicacao.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IServicoAplicacaoProduto ServicoAplicacaoProduto;
        private readonly IServicoAplicacaoCategoria ServicoAplicacaoCategoria;

        public ProdutoController(IServicoAplicacaoProduto servicoAplicacaoProduto, IServicoAplicacaoCategoria servicoAplicacaoCategoria)
        {
            ServicoAplicacaoProduto = servicoAplicacaoProduto;
            ServicoAplicacaoCategoria = servicoAplicacaoCategoria;
        }

        public IActionResult Index()
        {
            return View(ServicoAplicacaoProduto.ListarRegistro());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ProdutoViewModel viewModel = new();
            
            if (id != null)
            {
                viewModel = ServicoAplicacaoProduto.CarregarRegistro((int)id);
            }

            viewModel.ListaCategorias = ServicoAplicacaoCategoria.CategoriaDropDownList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(ProdutoViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                ServicoAplicacaoProduto.CadastrarRegistro(entidade);
            }
            else
            {
                entidade.ListaCategorias = ServicoAplicacaoCategoria.CategoriaDropDownList();
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            ServicoAplicacaoProduto.ExcluirRegistro(id);
            return RedirectToAction("Index");
        }
    }
}
