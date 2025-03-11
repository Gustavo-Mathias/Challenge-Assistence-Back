using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioAssistencia.Models
{
    public class VeiculoAssistencia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Veiculo")]
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        [Required]
        [ForeignKey("PlanoAssistencia")]
        public int PlanoId { get; set; }
        public PlanoAssistencia PlanoAssistencia { get; set; }
    }
}
