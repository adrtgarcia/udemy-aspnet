using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.DAL;
using SistemaVendas.Entities;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class CategoriaController : Controller
    {
        protected ApplicationDbContext dbContext;
        public CategoriaController(ApplicationDbContext context) 
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Categoria> listaCategorias = dbContext.Categoria.ToList();
            dbContext.Dispose();
            return View(listaCategorias);
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            CategoriaViewModel viewModel = new();

            if (id != null)
            {
                var entidade = dbContext.Categoria.Where(x => x.Codigo == id).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Descricao = entidade.Descricao;
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(CategoriaViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                Categoria objCategoria = new()
                {
                    Codigo = entidade.Codigo,
                    Descricao = entidade.Descricao 
                };

                if (entidade.Codigo == 0)
                {
                    dbContext.Categoria.Add(objCategoria);
                }
                else
                {
                    //dbContext.Entry(objCategoria).State = EntityState.Modified;
                    dbContext.Categoria.Update(objCategoria);
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
            //var entidade = new Categoria() { Codigo = id };
            var entidade = dbContext.Categoria.Where(x => x.Codigo == id).FirstOrDefault();

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
