namespace SistemaVendas.Dominio.Entities
{
    public class Cliente : EntityBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CpfCnpj { get; set; }
        public string NumeroTelefone { get; set; }
        public ICollection<Venda> Compras { get; set; }
    }
}
