using Microsoft.AspNetCore.Mvc;
using SistemaVendas.DAL;
using SistemaVendas.Helpers;
using SistemaVendas.Models;

namespace SistemaVendas.Controllers
{
    public class LoginController : Controller
    {
        protected ApplicationDbContext dbContext;
        protected IHttpContextAccessor httpContextAccessor;
        public LoginController(ApplicationDbContext context, IHttpContextAccessor accessor)
        {
            dbContext = context;
            httpContextAccessor = accessor;
        }
        public IActionResult Index(int? logoff)
        {
            if (logoff != null)
            {
                if (logoff == 0)
                {
                    httpContextAccessor.HttpContext.Session.Clear();
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel viewModel)
        {
            ViewData["ErroLogin"] = string.Empty;

            if (ModelState.IsValid)
            {
                var senha = Criptografia.GetMd5Hash(viewModel.Senha);
                var usuario = dbContext.Usuario.Where(u => (u.Email == viewModel.Email) && (u.Senha == senha)).FirstOrDefault();

                if (usuario == null)
                {
                    ViewData["ErroLogin"] = "Email ou senha incorretos.";
                    return View(viewModel);
                }
                else
                {
                    httpContextAccessor.HttpContext.Session.SetString(Sessao.NOME_USUARIO, usuario.Nome);
                    httpContextAccessor.HttpContext.Session.SetString(Sessao.EMAIL_USUARIO, usuario.Email);
                    httpContextAccessor.HttpContext.Session.SetInt32(Sessao.CODIGO_USUARIO, (int)usuario.Codigo);
                    httpContextAccessor.HttpContext.Session.SetInt32(Sessao.LOGADO, 1);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View(viewModel);
            }
        }
    }
}
