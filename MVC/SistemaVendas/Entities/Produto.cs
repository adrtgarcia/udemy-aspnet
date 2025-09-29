using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVendas.Entities
{
    public class Produto
    {
        [Key]
        public int? Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }
        public int QuantidadeEstoque { get; set; }
        
        [ForeignKey("Categoria")]
        public int CodigoCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public ICollection<VendaProduto> Vendas { get; set; }
    }
}
