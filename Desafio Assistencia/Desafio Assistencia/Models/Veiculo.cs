using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioAssistencia.Models
{
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public string Placa { get; set; }

        [ForeignKey("GrupoVeiculo")]
        public int GrupoId { get; set; }
        public GrupoVeiculo GrupoVeiculo { get; set; }
    }
}
