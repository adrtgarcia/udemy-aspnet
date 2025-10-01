using SistemaVendas.Dominio.Entities;
using SistemaVendas.Dominio.Interfaces;
using SistemaVendas.Dominio.Repositorio;

namespace SistemaVendas.Dominio.Services
{
    public class ServicoDominioProduto : IServicoDominioProduto
    {
        private readonly IRepositorioProduto RepositorioProduto;

        public ServicoDominioProduto(IRepositorioProduto repositorioProduto)
        {
            RepositorioProduto = repositorioProduto;
        }

        public void CadastrarRegistro(Produto produto)
        {
            RepositorioProduto.Create(produto);
        }

        public Produto CarregarRegistro(int id)
        {
            return RepositorioProduto.Read(id);
        }

        public void ExcluirRegistro(int id)
        {
            RepositorioProduto.Delete(id);
        }
        public IEnumerable<Produto> ListarRegistro()
        {
            return RepositorioProduto.Read();
        }
    }
}
