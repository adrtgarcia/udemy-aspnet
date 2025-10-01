using SistemaVendas.Dominio.Repositorio;
using SistemaVendas.Dominio.Entities;
using SistemaVendas.Repositorio.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SistemaVendas.Repositorio.Entities
{
    public class RepositorioProduto : Repositorio<Produto>, IRepositorioProduto
    {
        public RepositorioProduto(ApplicationDbContext dbContext) : base(dbContext) { }
        public override IEnumerable<Produto> Read()
        {
            return DbSet.Include(x => x.Categoria).AsNoTracking().ToList();
        }
    }
}
