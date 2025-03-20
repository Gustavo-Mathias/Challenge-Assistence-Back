using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        [JsonIgnore]  
        public GrupoVeiculo? GrupoVeiculo { get; set; }
    }
}
