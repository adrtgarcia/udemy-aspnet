using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Entities
{
    public class Cliente
    {
        [Key]
        public int? Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CpfCnpj { get; set; }
        public string NumeroTelefone { get; set; }
        public ICollection<Venda> Compras { get; set; }
    }
}
