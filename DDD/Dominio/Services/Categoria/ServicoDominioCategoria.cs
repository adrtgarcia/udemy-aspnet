using SistemaVendas.Dominio.Interfaces;
using SistemaVendas.Dominio.Entities;
using SistemaVendas.Dominio.Repositorio;

namespace SistemaVendas.Dominio.Services
{
    public class ServicoDominioCategoria : IServicoDominioCategoria
    {
        private readonly IRepositorioCategoria RepositorioCategoria;
        public ServicoDominioCategoria(IRepositorioCategoria repositorioCategoria)
        {
            RepositorioCategoria = repositorioCategoria;
        }
        public void CadastrarRegistro(Categoria categoria)
        {
            RepositorioCategoria.Create(categoria);
        }

        public Categoria CarregarRegistro(int id)
        {
            return RepositorioCategoria.Read(id);
        }

        public void ExcluirRegistro(int id)
        {
            RepositorioCategoria.Delete(id);
        }

        public IEnumerable<Categoria> ListarRegistro()
        {
            return RepositorioCategoria.Read();
        }
    }
}
