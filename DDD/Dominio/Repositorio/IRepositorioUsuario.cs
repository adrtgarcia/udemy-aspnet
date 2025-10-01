using SistemaVendas.Dominio.Entities;

namespace SistemaVendas.Dominio.Repositorio
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        public bool ValidarLogin(string email, string senha);
    }
}
