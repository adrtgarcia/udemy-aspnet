using Microsoft.EntityFrameworkCore;
using SistemaVendas.Dominio.Entities;
using SistemaVendas.Dominio.Repositorio;
using SistemaVendas.Repositorio.Context;

namespace SistemaVendas.Repositorio.Entities
{
    public class RepositorioUsuario : Repositorio<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(ApplicationDbContext dbContext) : base(dbContext) { }

        public bool ValidarLogin(string email, string senha)
        {
            var usuario = DbSet.Where(u => (u.Email == email) && (u.Senha == senha)).FirstOrDefault();

            if (usuario == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
