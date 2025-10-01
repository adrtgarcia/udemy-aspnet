using SistemaVendas.Dominio.DTOs;
using SistemaVendas.Dominio.Entities;
using SistemaVendas.Dominio.Interfaces;
using SistemaVendas.Dominio.Repositorio;

namespace SistemaVendas.Dominio.Services
{
    public class ServicoDominioVenda : IServicoDominioVenda
    {
        private readonly IRepositorioVenda RepositorioVenda;
        private readonly IRepositorioVendaProduto RepositorioVendaProduto;

        public ServicoDominioVenda(IRepositorioVenda repositorioVenda, IRepositorioVendaProduto repositorioVendaProduto)
        {
            RepositorioVenda = repositorioVenda;
            RepositorioVendaProduto = repositorioVendaProduto;
        }

        public void CadastrarRegistro(Venda venda)
        {
            RepositorioVenda.Create(venda);
        }

        public Venda CarregarRegistro(int id)
        {
            return RepositorioVenda.Read(id);
        }

        public void ExcluirRegistro(int id)
        {
            RepositorioVenda.Delete(id);
        }
        
        public IEnumerable<Venda> ListarRegistro()
        {
            return RepositorioVenda.Read();
        }

        public IEnumerable<GraficoDTO> ListaGrafico()
        {
            return RepositorioVendaProduto.ListaGrafico();
        }
    }
}
