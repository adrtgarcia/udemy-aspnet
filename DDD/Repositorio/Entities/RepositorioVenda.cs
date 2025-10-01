using SistemaVendas.Dominio.Repositorio;
using SistemaVendas.Dominio.Entities;
using SistemaVendas.Repositorio.Context;
using Microsoft.EntityFrameworkCore;

namespace SistemaVendas.Repositorio.Entities
{
    public class RepositorioVenda : Repositorio<Venda>, IRepositorioVenda
    {
        public RepositorioVenda(ApplicationDbContext dbContext) : base(dbContext) { }
        
        public override void Delete(int id)
        {
            DbSet<VendaProduto> DbSetAux = Db.Set<VendaProduto>();
            var produtosVenda = DbSetAux.Where(vp => vp.CodigoVenda == id).ToList();

            if (produtosVenda.Any())
            {
                DbSetAux.RemoveRange(produtosVenda);
                Db.SaveChanges();
            }

            var entidade = DbSetAux.FirstOrDefault(x => x.CodigoVenda == id);
            if (entidade != null)
            {
                DbSetAux.Remove(entidade);
                Db.SaveChanges();
            }
        }

        public override IEnumerable<Venda> Read()
        {
            return DbSet.Include(x => x.Cliente).AsNoTracking().ToList();
        }
    }
}
