using Microsoft.EntityFrameworkCore;
using SistemaVendas.Dominio.Entities;
using SistemaVendas.Dominio.Repositorio;
using SistemaVendas.Repositorio.Context;

namespace SistemaVendas.Repositorio.Entities
{
    public class RepositorioCategoria : Repositorio<Categoria>, IRepositorioCategoria
    {
        public RepositorioCategoria(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
