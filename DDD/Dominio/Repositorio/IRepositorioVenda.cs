using SistemaVendas.Dominio.Entities;

namespace SistemaVendas.Dominio.Repositorio
{
    public interface IRepositorioVenda : IRepositorio<Venda> 
    {
        new public void Delete(int id);
        new public IEnumerable<Venda> Read();
    }
}
