using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVendas.Dominio.Entities
{
    public class Venda : EntityBase
    {
        public DateTime DataVenda { get; set; }
        public decimal ValorTotal { get; set; }
        
        [ForeignKey("Cliente")]
        public int CodigoCliente { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<VendaProduto> Produtos { get; set; }
    }
}
