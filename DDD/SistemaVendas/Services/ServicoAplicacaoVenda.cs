using Newtonsoft.Json;
using SistemaVendas.Aplicacao.Interfaces;
using SistemaVendas.Aplicacao.Models;
using SistemaVendas.Dominio.DTOs;
using SistemaVendas.Dominio.Entities;
using SistemaVendas.Dominio.Interfaces;

namespace SistemaVendas.Aplicacao.Services
{
    public class ServicoAplicacaoVenda : IServicoAplicacaoVenda
    {
        private readonly IServicoDominioVenda ServicoDominioVenda;

        public ServicoAplicacaoVenda(IServicoDominioVenda servicoDominioVenda)
        {
            ServicoDominioVenda = servicoDominioVenda;
        }

        public IEnumerable<VendaViewModel> ListarRegistro()
        {
            var lista = ServicoDominioVenda.ListarRegistro();
            List<VendaViewModel> listaVenda = new();

            foreach (var item in lista)
            {
                VendaViewModel venda = new()
                {
                    Codigo = item.Codigo,
                    DataVenda = item.DataVenda,
                    CodigoCliente = item.CodigoCliente,
                    ValorTotal = item.ValorTotal,
                    NomeCliente = item.Cliente.Nome
                };

                listaVenda.Add(venda);
            }

            return listaVenda;
        }

        public VendaViewModel CarregarRegistro(int codigoVenda)
        {
            var registro = ServicoDominioVenda.CarregarRegistro(codigoVenda);
            VendaViewModel venda = new();

            if (registro != null)
            {
                venda.Codigo = registro.Codigo;
                venda.DataVenda = registro.DataVenda;
                venda.CodigoCliente = registro.CodigoCliente;
                venda.ValorTotal = registro.ValorTotal;
            }

            return venda;
        }

        public void CadastrarRegistro(VendaViewModel venda)
        {
            Venda novaVenda = new()
            {
                Codigo = venda.Codigo,
                DataVenda = (DateTime)venda.DataVenda,
                CodigoCliente = (int)venda.CodigoCliente,
                ValorTotal = venda.ValorTotal,
                Produtos = JsonConvert.DeserializeObject<ICollection<VendaProduto>>(venda.JsonProdutos)
            };

            ServicoDominioVenda.CadastrarRegistro(novaVenda);
        }

        public void ExcluirRegistro(int codigoVenda)
        {
            ServicoDominioVenda.ExcluirRegistro(codigoVenda);
        }

        public IEnumerable<GraficoDTO> ListaGrafico()
        {
            return ServicoDominioVenda.ListaGrafico();
        }
    }
}
