using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVendas.Aplicacao.Models;

namespace SistemaVendas.Aplicacao.Interfaces
{
    public interface IServicoAplicacaoCliente
    {
        IEnumerable<ClienteViewModel> ListarRegistro();
        IEnumerable<SelectListItem> ClienteDropDownList();
        ClienteViewModel CarregarRegistro(int id);
        void CadastrarRegistro(ClienteViewModel registro);
        void ExcluirRegistro(int id);
    }
}
