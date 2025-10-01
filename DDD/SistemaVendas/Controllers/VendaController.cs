using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Aplicacao.Interfaces;
using SistemaVendas.Aplicacao.Models;

namespace SistemaVendas.Aplicacao.Controllers
{
    public class VendaController : Controller
    {
        private readonly IServicoAplicacaoVenda ServicoAplicacaoVenda;
        private readonly IServicoAplicacaoCliente ServicoAplicacaoCliente;
        private readonly IServicoAplicacaoProduto ServicoAplicacaoProduto;

        public VendaController(IServicoAplicacaoVenda servicoAplicacaoVenda, 
                               IServicoAplicacaoCliente servicoAplicacaoCliente, 
                               IServicoAplicacaoProduto servicoAplicacaoProduto)
        {
            ServicoAplicacaoVenda = servicoAplicacaoVenda;
            ServicoAplicacaoCliente = servicoAplicacaoCliente;
            ServicoAplicacaoProduto = servicoAplicacaoProduto;
        }

        public IActionResult Index()
        {
            return View(ServicoAplicacaoVenda.ListarRegistro());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            VendaViewModel viewModel = new();

            if (id != null)
            {
                viewModel = ServicoAplicacaoVenda.CarregarRegistro((int)id);
            }

            viewModel.ListaClientes = ServicoAplicacaoCliente.ClienteDropDownList();
            viewModel.ListaProdutos = ServicoAplicacaoProduto.ProdutoDropDownList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(VendaViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                ServicoAplicacaoVenda.CadastrarRegistro(entidade);
            }
            else
            {
                entidade.ListaClientes = ServicoAplicacaoCliente.ClienteDropDownList();
                entidade.ListaProdutos = ServicoAplicacaoProduto.ProdutoDropDownList();
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            ServicoAplicacaoVenda.ExcluirRegistro(id);
            return RedirectToAction("Index");
        }

        [HttpGet("LerValorProduto/{CodigoProduto}")]
        public decimal LerValorProduto(int codigoProduto)
        {
            decimal? valorProduto = ServicoAplicacaoProduto.CarregarRegistro(codigoProduto).ValorUnitario;
            return (decimal)valorProduto;
        }
    }
}
