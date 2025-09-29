using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.DAL;
using SistemaVendas.Entities;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class ClienteController : Controller
    {
        protected ApplicationDbContext dbContext;
        public ClienteController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Cliente> listaClientes = dbContext.Cliente.ToList();
            dbContext.Dispose();
            return View(listaClientes);
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ClienteViewModel viewModel = new();

            if (id != null)
            {
                var entidade = dbContext.Cliente.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Nome = entidade.Nome;
                viewModel.Email = entidade.Email;
                viewModel.CpfCnpj = entidade.CpfCnpj;
                viewModel.NumeroTelefone = entidade.NumeroTelefone;
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(ClienteViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                Cliente objCliente = new()
                {
                    Codigo = entidade.Codigo,
                    Nome = entidade.Nome,
                    Email = entidade.Email,
                    CpfCnpj = entidade.CpfCnpj,
                    NumeroTelefone = entidade.NumeroTelefone
                };

                if (entidade.Codigo == 0)
                {
                    dbContext.Cliente.Add(objCliente);
                }
                else
                {
                    //dbContext.Entry(objCliente).State = EntityState.Modified;
                    dbContext.Cliente.Update(objCliente);
                }

                dbContext.SaveChanges();
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
            // var entidade = new Cliente() { Codigo = id };
            var entidade = dbContext.Cliente.Where(x => x.Codigo == id).FirstOrDefault();

            if (entidade != null)
            {
                dbContext.Attach(entidade);
                dbContext.Remove(entidade);
                dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
