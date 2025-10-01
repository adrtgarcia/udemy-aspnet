using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVendas.Aplicacao.Interfaces;
using SistemaVendas.Aplicacao.Models;
using SistemaVendas.Dominio.Entities;
using SistemaVendas.Dominio.Interfaces;

namespace SistemaVendas.Aplicacao.Services
{
    public class ServicoAplicacaoUsuario : IServicoAplicacaoUsuario
    {
        private readonly IServicoDominioUsuario ServicoDominioUsuario;

        public ServicoAplicacaoUsuario(IServicoDominioUsuario servicoDominioUsuario)
        {
            ServicoDominioUsuario = servicoDominioUsuario;
        }

        public bool ValidarLogin(string email, string senha)
        {
            return ServicoDominioUsuario.ValidarLogin(email, senha);
        }

        public Usuario ObterDados(string email, string senha)
        {
            var lista = ServicoDominioUsuario.ListarRegistro();
            var usuario = lista.Where(u => (u.Email == email) && (u.Senha == senha)).FirstOrDefault();
            return usuario;
        }
    }
}
