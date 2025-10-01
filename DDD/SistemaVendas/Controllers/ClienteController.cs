using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Aplicacao.Interfaces;
using SistemaVendas.Aplicacao.Models;

namespace SistemaVendas.Aplicacao.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IServicoAplicacaoCliente ServicoAplicacaoCliente;

        public ClienteController(IServicoAplicacaoCliente servicoAplicacaoCliente)
        {
            ServicoAplicacaoCliente = servicoAplicacaoCliente;
        }

        public IActionResult Index()
        {
            return View(ServicoAplicacaoCliente.ListarRegistro());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ClienteViewModel viewModel = new();

            if (id != null)
            {
                viewModel = ServicoAplicacaoCliente.CarregarRegistro((int)id);
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(ClienteViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                ServicoAplicacaoCliente.CadastrarRegistro(entidade);
            }
            else
            {
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            ServicoAplicacaoCliente.ExcluirRegistro(id);
            return RedirectToAction("Index");
        }
    }
}
