using SistemaVendas.Dominio.Entities;

namespace SistemaVendas.Dominio.Repositorio
{
    public interface IRepositorioProduto : IRepositorio<Produto> 
    {
        new public IEnumerable<Produto> Read();
    }
}
