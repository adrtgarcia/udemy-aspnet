using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Dominio.Entities
{
    public class EntityBase
    {
        [Key]
        public int? Codigo { get; set; }
    }
}
