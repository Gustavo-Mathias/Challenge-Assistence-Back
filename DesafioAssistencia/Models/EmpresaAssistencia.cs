using System.ComponentModel.DataAnnotations;

namespace DesafioAssistencia.Models
{
    public class EmpresaAssistencia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Endereco { get; set; }
    }
}
