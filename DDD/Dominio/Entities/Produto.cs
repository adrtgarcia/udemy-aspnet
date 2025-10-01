using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVendas.Dominio.Entities
{
    public class Produto : EntityBase
    {
        public string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }
        public int QuantidadeEstoque { get; set; }
        
        [ForeignKey("Categoria")]
        public int CodigoCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public ICollection<VendaProduto> Vendas { get; set; }
    }
}
