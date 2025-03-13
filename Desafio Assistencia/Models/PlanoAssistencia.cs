using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioAssistencia.Models
{
    public class PlanoAssistencia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("EmpresaAssistencia")]
        public int EmpresaId { get; set; }
        public EmpresaAssistencia EmpresaAssistencia { get; set; }

        public string Descricao { get; set; }
        public string Cobertura { get; set; }
    }
}
