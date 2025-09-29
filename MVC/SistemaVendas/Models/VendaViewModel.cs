using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SistemaVendas.Models
{
    public class VendaViewModel
    {
        public int? Codigo { get; set; }

        [Required(ErrorMessage = "Informe a data da venda.")]
        public DateTime? DataVenda { get; set; }

        [Required(ErrorMessage = "Informe o cliente.")]
        public int? CodigoCliente { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> ListaClientes { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> ListaProdutos { get; set; }
        public string JsonProdutos { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
