using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Models;
using SistemaVendas.Helpers;

namespace SistemaVendas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IHttpContextAccessor _httpContextAccessor;

        
         
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        } 

        
        /*
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }
        */
        
        
        public IActionResult Index()
        {
            return View();
        } 
        
        
        
        /*
        public IActionResult Index()
        {
            // DEBUG: Verificar se a sessão está ativa
            var logado = _httpContextAccessor.HttpContext.Session.GetInt32(Sessao.LOGADO);
            var nomeUsuario = _httpContextAccessor.HttpContext.Session.GetString(Sessao.NOME_USUARIO);
            var emailUsuario = _httpContextAccessor.HttpContext.Session.GetString(Sessao.EMAIL_USUARIO);

            System.Console.WriteLine($"=== HOME CONTROLLER ===");
            System.Console.WriteLine($"Usuario logado: {logado}");
            System.Console.WriteLine($"Nome do usuario: {nomeUsuario}");
            System.Console.WriteLine($"Email do usuario: {emailUsuario}");

            // Verificar se o usuário está logado
            if (logado != 1)
            {
                System.Console.WriteLine("Usuario nao logado, redirecionando para Login");
                return RedirectToAction("Index", "Login");
            }

            // Passar dados do usuário para a view
            ViewBag.NomeUsuario = nomeUsuario;
            ViewBag.EmailUsuario = emailUsuario;
            ViewBag.UsuarioLogado = true;

            return View();
        } */
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
