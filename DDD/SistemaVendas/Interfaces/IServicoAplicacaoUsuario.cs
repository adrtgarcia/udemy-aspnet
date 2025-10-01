using SistemaVendas.Dominio.Entities;

namespace SistemaVendas.Aplicacao.Interfaces
{
    public interface IServicoAplicacaoUsuario
    {
        public bool ValidarLogin(string email, string senha);
        public Usuario ObterDados(string email, string senha);
    }
}
