using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Aplicacao.Interfaces;
using SistemaVendas.Helpers;
using SistemaVendas.Aplicacao.Models;

namespace SistemaVendas.Controllers
{
    public class LoginController : Controller
    {
        protected readonly IServicoAplicacaoUsuario ServicoAplicacaoUsuario;
        protected IHttpContextAccessor httpContextAccessor;

        public LoginController(IServicoAplicacaoUsuario servicoAplicacaoUsuario, IHttpContextAccessor accessor)
        {
            ServicoAplicacaoUsuario = servicoAplicacaoUsuario;
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
                bool login = ServicoAplicacaoUsuario.ValidarLogin(viewModel.Email, senha);
                
                if (login)
                {
                    var usuario = ServicoAplicacaoUsuario.ObterDados(viewModel.Email, senha);

                    httpContextAccessor.HttpContext.Session.SetString(Sessao.NOME_USUARIO, usuario.Nome);
                    httpContextAccessor.HttpContext.Session.SetString(Sessao.EMAIL_USUARIO, usuario.Email);
                    httpContextAccessor.HttpContext.Session.SetInt32(Sessao.CODIGO_USUARIO, (int)usuario.Codigo);
                    httpContextAccessor.HttpContext.Session.SetInt32(Sessao.LOGADO, 1);
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["ErroLogin"] = "Email ou senha incorretos.";
                    return View(viewModel);
                }
            }
            else
            {
                return View(viewModel);
            }
        }
    }
}
