using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Aplicacao.Interfaces;
using System.Text.Json;

namespace SistemaVendas.Aplicacao.Controllers
{
    public class RelatorioController : Controller
    {
        protected readonly IServicoAplicacaoVenda ServicoAplicacaoVenda;

        public RelatorioController(IServicoAplicacaoVenda servicoAplicacaoVenda)
        {
            ServicoAplicacaoVenda = servicoAplicacaoVenda;
        }

        public IActionResult Grafico()
        {
            var lista = ServicoAplicacaoVenda.ListaGrafico();

            if (!lista.Any())
            {
                ViewBag.Valores = "[]";
                ViewBag.Labels = "[]";
                ViewBag.Cores = "[]";
                ViewBag.MensagemSemDados = "Nenhuma venda encontrada para gerar o gráfico.";
                
                return View();
            }

            var rnd = new Random();
            
            ViewBag.Labels = JsonSerializer.Serialize(lista.Select(x => x.Descricao));
            ViewBag.Valores = JsonSerializer.Serialize(lista.Select(x => x.TotalVendido));
            ViewBag.Cores = JsonSerializer.Serialize(lista.Select(_ => $"#{rnd.Next(0x1000000):X6}"));

            return View();

        }
    }
}