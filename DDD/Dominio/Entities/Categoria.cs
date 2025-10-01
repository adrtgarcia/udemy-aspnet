namespace SistemaVendas.Dominio.Entities
{
    public class Categoria : EntityBase
    {        
        public string Descricao { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}

