namespace SistemaVendas.Dominio.Repositorio
{
    public interface IRepositorio<TEntity>
        where TEntity : class
    {
        public void Create(TEntity entity);
        public TEntity Read(int id);
        public void Delete(int id);
        public IEnumerable<TEntity> Read();
    }
}
