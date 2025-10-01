using SistemaVendas.Dominio.Entities;

namespace SistemaVendas.Dominio.Interfaces
{
    public interface IServicoDominioUsuario : IServicoDominioCRUD<Usuario> 
    {
        public bool ValidarLogin(string email, string senha);
    }
}
