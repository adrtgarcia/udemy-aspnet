using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Aplicacao.Models
{
    public class ClienteViewModel
    {
        public int? Codigo { get; set; }

        [Required(ErrorMessage = "Informe o nome do cliente.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o email do cliente.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o CFP/CNPJ do cliente.")]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "Informe o número de telefone do cliente.")]
        public string NumeroTelefone { get; set; }
    }
}
