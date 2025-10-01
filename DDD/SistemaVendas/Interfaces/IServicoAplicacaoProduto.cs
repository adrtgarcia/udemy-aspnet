using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVendas.Aplicacao.Models;

namespace SistemaVendas.Aplicacao.Interfaces
{
    public interface IServicoAplicacaoProduto
    {
        IEnumerable<ProdutoViewModel> ListarRegistro();
        IEnumerable<SelectListItem> ProdutoDropDownList();
        ProdutoViewModel CarregarRegistro(int id);
        void CadastrarRegistro(ProdutoViewModel registro);
        void ExcluirRegistro(int id);
    }
}
