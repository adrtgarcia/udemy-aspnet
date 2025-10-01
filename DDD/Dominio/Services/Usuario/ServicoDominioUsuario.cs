using SistemaVendas.Dominio.Interfaces;
using SistemaVendas.Dominio.Entities;
using SistemaVendas.Dominio.Repositorio;

namespace SistemaVendas.Dominio.Services
{
    public class ServicoDominioUsuario : IServicoDominioUsuario
    {
        private readonly IRepositorioUsuario RepositorioUsuario;
        public ServicoDominioUsuario(IRepositorioUsuario repositorioUsuario)
        {
            RepositorioUsuario = repositorioUsuario;
        }
        public void CadastrarRegistro(Usuario usuario)
        {
            RepositorioUsuario.Create(usuario);
        }

        public Usuario CarregarRegistro(int id)
        {
            return RepositorioUsuario.Read(id);
        }

        public void ExcluirRegistro(int id)
        {
            RepositorioUsuario.Delete(id);
        }

        public IEnumerable<Usuario> ListarRegistro()
        {
            return RepositorioUsuario.Read();
        }

        public bool ValidarLogin(string email, string senha)
        {
            return RepositorioUsuario.ValidarLogin(email, senha);
        }
    }
}
