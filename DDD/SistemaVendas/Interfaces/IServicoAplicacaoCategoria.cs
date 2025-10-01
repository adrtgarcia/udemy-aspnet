using SistemaVendas.Aplicacao.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SistemaVendas.Aplicacao.Interfaces
{
    public interface IServicoAplicacaoCategoria
    {
        IEnumerable<CategoriaViewModel> ListarRegistro();
        IEnumerable<SelectListItem> CategoriaDropDownList();
        CategoriaViewModel CarregarRegistro(int id);
        void CadastrarRegistro(CategoriaViewModel registro);
        void ExcluirRegistro(int id);
    }
}
