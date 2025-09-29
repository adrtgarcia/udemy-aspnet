using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVendas.Entities
{
    public class Venda
    {
        [Key]
        public int? Codigo { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorTotal { get; set; }
        
        [ForeignKey("Cliente")]
        public int CodigoCliente { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<VendaProduto> Produtos { get; set; }
    }
}
