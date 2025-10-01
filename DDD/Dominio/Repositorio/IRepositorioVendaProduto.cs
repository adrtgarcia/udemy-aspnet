using SistemaVendas.Dominio.DTOs;

namespace SistemaVendas.Dominio.Repositorio
{
    public interface IRepositorioVendaProduto
    {
        public IEnumerable<GraficoDTO> ListaGrafico();
    }
}
