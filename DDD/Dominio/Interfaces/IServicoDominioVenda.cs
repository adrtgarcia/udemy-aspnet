using SistemaVendas.Dominio.DTOs;
using SistemaVendas.Dominio.Entities;

namespace SistemaVendas.Dominio.Interfaces
{
    public interface IServicoDominioVenda : IServicoDominioCRUD<Venda>
    {
        public IEnumerable<GraficoDTO> ListaGrafico();
    }
}
