using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SistemaVendas.Aplicacao.Models
{
    public class VendaViewModel
    { 
        public int? Codigo { get; set; }

        [Required(ErrorMessage = "Informe a data da venda.")]
        public DateTime? DataVenda { get; set; }

        [Required(ErrorMessage = "Informe o cliente.")]
        public int? CodigoCliente { get; set; }
        public decimal ValorTotal { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> ListaClientes { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> ListaProdutos { get; set; }
        public string JsonProdutos { get; set; }

        //[ValidateNever]
        public string? NomeCliente { get; set; }
    }
}
