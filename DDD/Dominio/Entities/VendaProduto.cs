namespace SistemaVendas.Dominio.Entities
{
    public class VendaProduto
    {
        public int CodigoVenda { get; set; }
        public int CodigoProduto { get; set; }
        public int QuantidadeProduto { get; set; }
        public decimal ValorTotal { get; set; }
        public Produto Produto { get; set; }
        public Venda Venda { get; set; }
    }
}
