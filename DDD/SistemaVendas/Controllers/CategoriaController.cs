using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Aplicacao.Interfaces;
using SistemaVendas.Aplicacao.Models;

namespace SistemaVendas.Aplicacao.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly IServicoAplicacaoCategoria ServicoAplicacaoCategoria;
        
        public CategoriaController(IServicoAplicacaoCategoria servicoAplicacaoCategoria) 
        {
            ServicoAplicacaoCategoria = servicoAplicacaoCategoria;
        }
        
        public IActionResult Index()
        {
            return View(ServicoAplicacaoCategoria.ListarRegistro());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            CategoriaViewModel viewModel = new();

            if (id != null)
            {
                viewModel = ServicoAplicacaoCategoria.CarregarRegistro((int)id);
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(CategoriaViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                ServicoAplicacaoCategoria.CadastrarRegistro(entidade);
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
            ServicoAplicacaoCategoria.ExcluirRegistro(id);
            return RedirectToAction("Index");
        }
    }
}
