using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVendas.Aplicacao.Interfaces;
using SistemaVendas.Aplicacao.Models;
using SistemaVendas.Dominio.Entities;
using SistemaVendas.Dominio.Interfaces;

namespace SistemaVendas.Aplicacao.Services
{
    public class ServicoAplicacaoCategoria : IServicoAplicacaoCategoria
    {
        private readonly IServicoDominioCategoria ServicoDominioCategoria;

        public ServicoAplicacaoCategoria(IServicoDominioCategoria servicoDominioCategoria)
        {
            ServicoDominioCategoria = servicoDominioCategoria;
        }
        
        public IEnumerable<CategoriaViewModel> ListarRegistro()
        {
            var lista = ServicoDominioCategoria.ListarRegistro();
            List<CategoriaViewModel> listaCategoria = new();

            foreach (var item in lista)
            {
                CategoriaViewModel categoria = new()
                {
                    Codigo = item.Codigo,
                    Descricao = item.Descricao
                };

                listaCategoria.Add(categoria);
            }

            return listaCategoria;
        }
        
        public IEnumerable<SelectListItem> CategoriaDropDownList()
        {
            var lista = ServicoDominioCategoria.ListarRegistro();
            List<SelectListItem> listaCategoria =
                [
                    new SelectListItem() { Value = string.Empty,
                                           Text = string.Empty }
                ];

            foreach (var item in lista)
            {
                SelectListItem categoria = new()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao
                };

                listaCategoria.Add(categoria);
            }

            return listaCategoria;
        }

        public CategoriaViewModel CarregarRegistro(int codigoCategoria)
        {
            var registro = ServicoDominioCategoria.CarregarRegistro(codigoCategoria);
            CategoriaViewModel categoria = new();

            if (registro != null)
            {
                categoria.Codigo = registro.Codigo;
                categoria.Descricao = registro.Descricao;
            }

            return categoria;
        }

        public void CadastrarRegistro(CategoriaViewModel categoria)
        {
            Categoria novaCategoria = new()
            {
                Codigo = categoria.Codigo,
                Descricao = categoria.Descricao
            };

            ServicoDominioCategoria.CadastrarRegistro(novaCategoria);
        }

        public void ExcluirRegistro(int codigoCategoria)
        {
            ServicoDominioCategoria.ExcluirRegistro(codigoCategoria);
        }
    }
}
