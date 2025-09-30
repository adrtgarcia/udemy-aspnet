using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.DAL;
using SistemaVendas.Entities;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class ProdutoController : Controller
    {
        protected ApplicationDbContext dbContext;
       
        public ProdutoController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Produto> listaProdutos = dbContext.Produto.Include(p => p.Categoria).ToList();
            // dbContext.Dispose();
            return View(listaProdutos);
        }

        private IEnumerable<SelectListItem> ListarCategoria()
        {
            List<SelectListItem> lista =
                [
                    new SelectListItem() { Value = string.Empty,
                                           Text = string.Empty }
                ];

            foreach (var item in dbContext.Categoria.ToList())
            {
                lista.Add(new SelectListItem()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao
                });
            }

            return lista;
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ProdutoViewModel viewModel = new();
            viewModel.ListaCategorias = ListarCategoria();

            if (id != null)
            {
                var entidade = dbContext.Produto.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Descricao = entidade.Descricao;
                viewModel.ValorUnitario = entidade.ValorUnitario;
                viewModel.QuantidadeEstoque = entidade.QuantidadeEstoque;
                viewModel.CodigoCategoria = entidade.CodigoCategoria;
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(ProdutoViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                Produto objProduto = new()
                {
                    Codigo = entidade.Codigo,
                    Descricao = entidade.Descricao,
                    ValorUnitario = (decimal)entidade.ValorUnitario,
                    QuantidadeEstoque = entidade.QuantidadeEstoque,
                    CodigoCategoria = entidade.CodigoCategoria
                };

                if (entidade.Codigo == 0)
                {
                    dbContext.Produto.Add(objProduto);
                }
                else
                {
                    //dbContext.Entry(objProduto).State = EntityState.Modified;
                    dbContext.Produto.Update(objProduto);
                }

                dbContext.SaveChanges();
            }
            else
            {
                entidade.ListaCategorias = ListarCategoria();
                return View(entidade);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            // var entidade = new Produto() { Codigo = id };
            var entidade = dbContext.Produto.Where(x => x.Codigo == id).FirstOrDefault();

            if (entidade != null)
            {
                dbContext.Attach(entidade);
                dbContext.Remove(entidade);
                dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
