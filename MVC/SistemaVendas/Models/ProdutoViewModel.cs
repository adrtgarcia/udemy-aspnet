using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SistemaVendas.Models
{
    public class ProdutoViewModel
    {
        public int? Codigo { get; set; }

        [Required(ErrorMessage = "Informe a descrição do produto.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o valor unitário do produto.")]
        [Range(0.1, Double.PositiveInfinity)]
        public decimal? ValorUnitario { get; set; }

        [Required(ErrorMessage = "Informe a quantidade de estoque do produto.")]
        public int QuantidadeEstoque { get; set; }

        [Required(ErrorMessage = "Informe a categoria do produto.")]
        public int CodigoCategoria { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ListaCategorias { get; set; }
    }
}
