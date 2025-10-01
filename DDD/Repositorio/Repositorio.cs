using Microsoft.EntityFrameworkCore;
using SistemaVendas.Dominio.Repositorio;
using SistemaVendas.Dominio.Entities;

namespace SistemaVendas.Repositorio
{
    public abstract class Repositorio<TEntity> : DbContext, IRepositorio<TEntity>
        where TEntity : EntityBase, new()
    {
        protected readonly DbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repositorio(DbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }
        
        public void Create(TEntity entity)
        {
            if (entity.Codigo == 0)
            {
                DbSet.Add(entity);
            }
            else
            {
                DbSet.Update(entity);
            }
        
            Db.SaveChanges();
        }
        
        public virtual void Delete(int id)
        {
            var registro = DbSet.Where(x => x.Codigo == id).FirstOrDefault();

            if (registro != null)
            {
                DbSet.Attach(registro);
                DbSet.Remove(registro);
                Db.SaveChanges();
            }
        }
        
        public TEntity Read(int id)
        {
            return DbSet.Where(x => x.Codigo == id).FirstOrDefault();
        }

        public virtual IEnumerable<TEntity> Read()
        {
            return DbSet.AsNoTracking().ToList();
        }
    }
}
