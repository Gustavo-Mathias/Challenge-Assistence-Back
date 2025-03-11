using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesafioAssistencia.Models
{
    public class GrupoVeiculo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Descricao { get; set; }
        public ICollection<Veiculo> Veiculos { get; set; }
    }
}
