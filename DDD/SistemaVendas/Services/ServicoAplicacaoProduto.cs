using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVendas.Aplicacao.Interfaces;
using SistemaVendas.Aplicacao.Models;
using SistemaVendas.Dominio.Entities;
using SistemaVendas.Dominio.Interfaces;
using SistemaVendas.Dominio.Services;

namespace SistemaVendas.Aplicacao.Services
{
    public class ServicoAplicacaoProduto : IServicoAplicacaoProduto
    {
        private readonly IServicoDominioProduto ServicoDominioProduto;

        public ServicoAplicacaoProduto(IServicoDominioProduto servicoDominioProduto)
        {
            ServicoDominioProduto = servicoDominioProduto;
        }

        public IEnumerable<ProdutoViewModel> ListarRegistro()
        {
            var lista = ServicoDominioProduto.ListarRegistro();
            List<ProdutoViewModel> listaProduto = new();

            foreach (var item in lista)
            {
                ProdutoViewModel produto = new()
                {
                    Codigo = item.Codigo,
                    Descricao = item.Descricao,
                    ValorUnitario = item.ValorUnitario,
                    QuantidadeEstoque = item.QuantidadeEstoque,
                    CodigoCategoria = item.CodigoCategoria,
                    DescricaoCategoria = item.Categoria.Descricao
                };

                listaProduto.Add(produto);
            }

            return listaProduto;
        }

        public IEnumerable<SelectListItem> ProdutoDropDownList()
        {
            var lista = ServicoDominioProduto.ListarRegistro();
            List<SelectListItem> listaProduto =
                [
                    new SelectListItem() { Value = string.Empty,
                                           Text = string.Empty }
                ];

            foreach (var item in lista)
            {
                SelectListItem produto = new()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao
                };

                listaProduto.Add(produto);
            }

            return listaProduto;
        }

        public ProdutoViewModel CarregarRegistro(int codigoProduto)
        {
            var registro = ServicoDominioProduto.CarregarRegistro(codigoProduto);
            ProdutoViewModel produto = new();

            if (registro != null)
            {
                produto.Codigo = registro.Codigo;
                produto.Descricao = registro.Descricao;
                produto.ValorUnitario = registro.ValorUnitario;
                produto.QuantidadeEstoque = registro.QuantidadeEstoque;
                produto.CodigoCategoria = registro.CodigoCategoria;
            }

            return produto;
        }

        public void CadastrarRegistro(ProdutoViewModel produto)
        {
            Produto novoProduto = new()
            {
                Codigo = produto.Codigo,
                Descricao = produto.Descricao,
                ValorUnitario = (decimal)produto.ValorUnitario,
                QuantidadeEstoque = produto.QuantidadeEstoque,
                CodigoCategoria = produto.CodigoCategoria
            };

            ServicoDominioProduto.CadastrarRegistro(novoProduto);
        }

        public void ExcluirRegistro(int codigoProduto)
        {
            ServicoDominioProduto.ExcluirRegistro(codigoProduto);
        }
    }
}
