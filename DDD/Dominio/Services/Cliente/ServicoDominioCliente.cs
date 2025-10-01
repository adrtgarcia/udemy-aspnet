using SistemaVendas.Dominio.Entities;
using SistemaVendas.Dominio.Interfaces;
using SistemaVendas.Dominio.Repositorio;

namespace SistemaVendas.Dominio.Services
{
    public class ServicoDominioCliente : IServicoDominioCliente
    {
        private readonly IRepositorioCliente RepositorioCliente;
        
        public ServicoDominioCliente(IRepositorioCliente repositorioCliente)
        {
            RepositorioCliente = repositorioCliente;
        }

        public void CadastrarRegistro(Cliente cliente)
        {
            RepositorioCliente.Create(cliente);
        }

        public Cliente CarregarRegistro(int id)
        {
            return RepositorioCliente.Read(id);
        }

        public void ExcluirRegistro(int id)
        {
            RepositorioCliente.Delete(id);
        }
        public IEnumerable<Cliente> ListarRegistro()
        {
            return RepositorioCliente.Read();
        }
    }
}
