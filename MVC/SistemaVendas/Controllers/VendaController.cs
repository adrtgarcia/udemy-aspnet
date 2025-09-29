using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SistemaVendas.DAL;
using SistemaVendas.Entities;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class VendaController : Controller
    {
        protected ApplicationDbContext dbContext;

        public VendaController(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            // IEnumerable<Venda> listaVendas = dbContext.Venda.ToList();
            // dbContext.Dispose();

            IEnumerable<Venda> listaVendas = dbContext.Venda.Include(v => v.Cliente)
                                                            .Include(v => v.Produtos)
                                                            .ToList();
            return View(listaVendas);
        }

        private IEnumerable<SelectListItem> ListarProdutos()
        {
            List<SelectListItem> lista =
               [
                   new SelectListItem() { Value = string.Empty,
                                           Text = string.Empty }
               ];

            foreach (var item in dbContext.Produto.ToList())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao
                });
            }

            return lista;
        }
        private IEnumerable<SelectListItem> ListarClientes()
        {
            List<SelectListItem> lista =
               [
                   new SelectListItem() { Value = string.Empty,
                                           Text = string.Empty }
               ];

            foreach (var item in dbContext.Cliente.ToList())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Nome
                });
            }

            return lista;
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            VendaViewModel viewModel = new();
            viewModel.ListaClientes = ListarClientes();
            viewModel.ListaProdutos = ListarProdutos();

            if (id != null)
            {
                var entidade = dbContext.Venda.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.DataVenda = entidade.DataVenda;
                viewModel.CodigoCliente = entidade.CodigoCliente;
                viewModel.ValorTotal = entidade.ValorTotal;
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(VendaViewModel entidade)
        {
            Console.WriteLine("=== JSON RECEBIDO ===");
            Console.WriteLine($"JsonProdutos: '{entidade.JsonProdutos}'");

            if (ModelState.IsValid)
            {
                Venda objVenda = new()
                {
                    Codigo = entidade.Codigo,
                    DataVenda = (DateTime)entidade.DataVenda,
                    CodigoCliente = (int)entidade.CodigoCliente,
                    ValorTotal = entidade.ValorTotal,
                    Produtos = JsonConvert.DeserializeObject<ICollection<VendaProduto>>(entidade.JsonProdutos)
                };

                if (entidade.Codigo == 0)
                {
                    dbContext.Venda.Add(objVenda);
                }
                else
                {
                    //dbContext.Entry(objVenda).State = EntityState.Modified;
                    dbContext.Venda.Update(objVenda);
                }

                dbContext.SaveChanges();
            }
            else
            {
                entidade.ListaClientes = ListarClientes();
                entidade.ListaProdutos = ListarProdutos();
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            // var entidade = new Venda() { Codigo = id };

            var produtosDaVenda = dbContext.VendaProduto
                .Where(vp => vp.CodigoVenda == id)
                .ToList();

            if (produtosDaVenda.Any())
            {
                dbContext.VendaProduto.RemoveRange(produtosDaVenda);
                dbContext.SaveChanges();
            }

            var entidade = dbContext.Venda.FirstOrDefault(x => x.Codigo == id);
            if (entidade != null)
            {
                dbContext.Venda.Remove(entidade);
                dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet("LerValorProduto/{CodigoProduto}")] 
        public decimal LerValorProduto(int CodigoProduto)
        {
            return dbContext.Produto.Where(p => p.Codigo == CodigoProduto).Select(p => p.ValorUnitario).FirstOrDefault();
        }
    }
}