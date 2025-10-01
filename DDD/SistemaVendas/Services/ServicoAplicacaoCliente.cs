using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVendas.Aplicacao.Interfaces;
using SistemaVendas.Aplicacao.Models;
using SistemaVendas.Dominio.Entities;
using SistemaVendas.Dominio.Interfaces;
using SistemaVendas.Dominio.Services;

namespace SistemaVendas.Aplicacao.Services
{
    public class ServicoAplicacaoCliente : IServicoAplicacaoCliente
    {
        private readonly IServicoDominioCliente ServicoDominioCliente;

        public ServicoAplicacaoCliente(IServicoDominioCliente servicoDominioCliente)
        {
            ServicoDominioCliente = servicoDominioCliente;
        }
        
        public IEnumerable<ClienteViewModel> ListarRegistro()
        {
            var lista = ServicoDominioCliente.ListarRegistro();
            List<ClienteViewModel> listaCliente = new();

            foreach (var item in lista)
            {
                ClienteViewModel cliente = new()
                {
                    Codigo = item.Codigo,
                    Nome = item.Nome,
                    Email = item.Email,
                    CpfCnpj = item.CpfCnpj,
                    NumeroTelefone = item.NumeroTelefone
                };

                listaCliente.Add(cliente);
            }

            return listaCliente;
        }
        public IEnumerable<SelectListItem> ClienteDropDownList()
        {
            var lista = ServicoDominioCliente.ListarRegistro();
            List<SelectListItem> listaCliente =
                [
                    new SelectListItem() { Value = string.Empty,
                                           Text = string.Empty }
                ];

            foreach (var item in lista)
            {
                SelectListItem cliente = new()
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Nome
                };

                listaCliente.Add(cliente);
            }

            return listaCliente;
        }

        public ClienteViewModel CarregarRegistro(int codigoCliente)
        {
            var registro = ServicoDominioCliente.CarregarRegistro(codigoCliente);
            ClienteViewModel cliente = new();

            if (registro != null)
            {
                cliente.Codigo = registro.Codigo;
                cliente.Nome = registro.Nome;
                cliente.Email = registro.Email;
                cliente.CpfCnpj = registro.CpfCnpj;
                cliente.NumeroTelefone = registro.NumeroTelefone;
            }

            return cliente;
        }

        public void CadastrarRegistro(ClienteViewModel cliente)
        {
            Cliente novoCliente = new()
            {
                Codigo = cliente.Codigo,
                Nome = cliente.Nome,
                Email = cliente.Email,
                CpfCnpj = cliente.CpfCnpj,
                NumeroTelefone = cliente.NumeroTelefone
            };

            ServicoDominioCliente.CadastrarRegistro(novoCliente);
        }

        public void ExcluirRegistro(int codigoCliente)
        {
            ServicoDominioCliente.ExcluirRegistro(codigoCliente);
        }
    }
}
