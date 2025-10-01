namespace SistemaVendas.Dominio.Interfaces
{
    public interface IServicoDominioCRUD<TEntity>
        where TEntity : class
    {
        IEnumerable<TEntity> ListarRegistro();
        void CadastrarRegistro(TEntity registro);
        TEntity CarregarRegistro(int id);
        void ExcluirRegistro(int id);
    }
}
