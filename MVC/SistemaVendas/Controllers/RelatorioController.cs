using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.DAL;
using SistemaVendas.Models;
using System.Text.Json;

namespace SistemaVendas.Controllers
{
    public class RelatorioController : Controller
    {
        protected ApplicationDbContext dbContext;

        public RelatorioController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Grafico()
        {
            var vendas = dbContext.VendaProduto.Include(vp => vp.Produto).ToList();

            if (!vendas.Any())
            {
                ViewBag.Valores = "[]";
                ViewBag.Labels = "[]";
                ViewBag.Cores = "[]";
                ViewBag.MensagemSemDados = "Nenhuma venda encontrada para gerar o gráfico.";
                
                return View();
            }

            var grupos = vendas.GroupBy(vp => vp.CodigoProduto).ToList();
            var lista = vendas.GroupBy(vp => vp.CodigoProduto)
                              .Select(g => new GraficoViewModel
                                    {
                                        CodigoProduto = g.Key,
                                        Descricao = g.FirstOrDefault()?.Produto?.Descricao ?? $"Produto {g.Key}",
                                        TotalVendido = g.Sum(vp => vp.QuantidadeProduto)
                                    })
                              .ToList();

            var rnd = new Random();
            
            ViewBag.Labels = JsonSerializer.Serialize(lista.Select(x => x.Descricao));
            ViewBag.Valores = JsonSerializer.Serialize(lista.Select(x => x.TotalVendido));
            ViewBag.Cores = JsonSerializer.Serialize(lista.Select(_ => $"#{rnd.Next(0x1000000):X6}"));

            return View();

        }
    }
}