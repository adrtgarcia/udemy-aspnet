using SistemaVendas.Aplicacao.Models;
using SistemaVendas.Dominio.DTOs;
using SistemaVendas.Repositorio.Entities;

namespace SistemaVendas.Aplicacao.Interfaces
{
    public interface IServicoAplicacaoVenda
    {
        IEnumerable<VendaViewModel> ListarRegistro();
        VendaViewModel CarregarRegistro(int id);
        void CadastrarRegistro(VendaViewModel registro);
        void ExcluirRegistro(int id);
        IEnumerable<GraficoDTO> ListaGrafico();
    }
}
