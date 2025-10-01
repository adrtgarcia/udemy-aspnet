using SistemaVendas.Dominio.Repositorio;
using SistemaVendas.Dominio.Entities;
using SistemaVendas.Repositorio.Context;

namespace SistemaVendas.Repositorio.Entities
{
    public class RepositorioCliente : Repositorio<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
